namespace Categorizer.Services
{
    using System;
    using System.Web;

    using Autofac;
    using Autofac.Integration.Wcf;

    using Categorizer.Data;
    using Categorizer.Domain.Interfaces;
    using Categorizer.Domain.Logic;
    using Categorizer.Services.Support;

    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Database.Initialize();

            var builder = new ContainerBuilder();

            builder.RegisterType<CategorizerService>().AsSelf();
            builder.RegisterType<DataSource>().As<IDataSource>();
            builder.RegisterType<RegexTextAnalizer>().As<ITextAnalizer>();

            AutofacHostFactory.Container = builder.Build();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();

            EnableCrossDmainAjaxCall();
        }

        private void EnableCrossDmainAjaxCall()
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }
    }
}