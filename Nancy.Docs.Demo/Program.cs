using System;
using Nancy.Hosting.Self;

namespace Nancy.Docs.Demo
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:1234")))
            {
                host.Start();
                Console.WriteLine("Listening on http://localhost:1234");
                Console.ReadLine();
            }
        }
    }

    public class MyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            ServiceStack.Text.JsConfig.ExcludeTypeInfo = true;

            pipelines.OnError += (ctx, ex) => {
                return null;
            };
        }
    }
}
