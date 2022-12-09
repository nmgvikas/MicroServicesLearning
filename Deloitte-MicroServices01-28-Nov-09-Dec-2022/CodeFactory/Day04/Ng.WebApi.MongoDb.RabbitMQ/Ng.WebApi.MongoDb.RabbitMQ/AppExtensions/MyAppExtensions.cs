using Ng.WebApi.MongoDb.RabbitMQ.ServiceListeners;

namespace Ng.WebApi.MongoDb.RabbitMQ.AppExtensions
{
    public static class MyAppExtensions
    {

        //Types that you want to manage
        public static RabbitMQNewCustomersListener _QListener { get; set; }

        //Extension Method 
        public static IApplicationBuilder UseRabbitMQNewCustomersListener(this IApplicationBuilder app)
        {
            //Get the instance of the Injected RabbitMQNewCustomersListener object
            _QListener = app.ApplicationServices.GetRequiredService<RabbitMQNewCustomersListener>();
            //get a reference to this Lifetime service
            var appLifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);

            return app;



        }
        private static void OnStarted()
        {
            _QListener.Register();
        }
        private static void OnStopping() {
            _QListener.UnRegister();
        }

    }
}
