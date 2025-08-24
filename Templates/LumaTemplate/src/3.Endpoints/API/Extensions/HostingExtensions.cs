using Luma.Infra.Data.Sql.Commands.Interceptors;
using Luma.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Steeltoe.Discovery.Client;
using LumaTemplate.Endpoints.API.Extensions.HealthCheck;
using LumaTemplate.Infra.Data.Sql.Commands.Common;
using LumaTemplate.Infra.Data.Sql.Queries.Common;
using LumaTemplate.Core.Contracts.Common;
using Luma.EndPoints.Web.Extensions.DependencyInjection;
using Luma.EndPoints.Web.Extensions.ModelBinding;


namespace LumaTemplate.Endpoints.API.Extensions;
public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;

        builder.Services.AddLumaObservabilitySupport(configuration, "OpenTeletmetry");
        builder.Services.AddLumaApiCore("Luma", "LumaTemplate");
        builder.Services.AddLumaDefaultApiVersioning();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddLumaInMemoryCaching();
        builder.Services.AddNonValidatingValidator();
        builder.Services.AddLumaNewtonSoftSerializer();
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddLumaWebUserInfoService(configuration, "WebUserInfo", false);
        builder.Services.AddLumaParrotTranslator(configuration, "ParrotTranslator");
        builder.Services.AddLumaScalar(configuration, "Scalar");
        builder.Services.AddLumaAutoMapperProfiles(configuration, "AutoMapper");

        builder.Services.AddDiscoveryClient();

        builder.Services.AddLumaBasicHealthChecks(builder.Configuration);
        builder.Services.AddLumaApiAuthentication(configuration, "ApiAuthentication");
        builder.Services.AddSoftwarePartDetector(configuration, "SoftwarePart");



        #region ChangeData

        builder.Services.AddLumaChangeDatalogDalSql(c =>
        {
            c.ConnectionString = configuration.GetConnectionString("CommandDb_ConnectionString");
        });

        builder.Services.AddLumaHamsterChangeDatalog(c =>
        {
            c.BusinessIdFieldName = "BusinessId";
        });

        #endregion


        #region DbContext

        builder.Services.AddDbContext<DbContextNameCommandDbContext>(c =>
                        c.UseSqlServer(configuration.GetConnectionString("CommandDb_ConnectionString"))
                       .AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor())
                       .AddInterceptors(new AddChangeDataLogInterceptor()));

        builder.Services.AddDbContext<DbContextNameQueryDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("QueryDb_ConnectionString")));

        builder.Services.AddScoped<ILumaTemplateUnitOfWork, LumaTemplateUnitOfWork>(); // This is for UOW, in the next version it not needed to be here.

        #endregion



        #region Messaging

        builder.Services.AddLumaPollingPublisherDalSql(configuration, "PollingPublisherSqlStore");
        builder.Services.AddLumaPollingPublisher(configuration, "PollingPublisher");

        builder.Services.AddLumaMessageInboxDalSql(configuration, "MessageInboxSqlStore");
        builder.Services.AddLumaMessageInbox(configuration, "MessageInbox");

        builder.Services.AddLumaRabbitMqMessageBus(configuration, "RabbitMq");

        // builder.Services.AddScoped<IMessageConsumer, FakeMessageConsumer>();
        // builder.Services.AddScoped<ISendMessageBus, FakeSendMessageBus>();
        // builder.Services.AddScoped<IReceiveMessageBus, FakeReceiveMessageBus>();

        #endregion



        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {


        app.UseLumaObservabilityMiddlewares();
        app.UseLumaScalar();
        app.UseLumaApiExceptionHandler();
        app.UseSerilogRequestLogging();
        app.UseStatusCodePages();

        #region UseCors

        app.UseCors(delegate (CorsPolicyBuilder builder)
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });

        #endregion


        app.UseHttpsRedirection();


        #region Receive Events/Commands

        //  app.Services.ReceiveEventFromRabbitMqMessageBus(new KeyValuePair<string, string>("LumaTemplate", "UserMobileChanged"));
        //  app.Services.ReceiveCommandFromRabbitMqMessageBus("PersonCommand");

        #endregion


        app.MapHealthEnpoints();

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();/*.RequireAuthorization();*/

        // app.Services.GetService<SoftwarePartDetectorService>()?.Run();


        return app;
    }
}
