using Topshelf;

namespace RemotePcControl.OwinService
{
    class ServiceInit
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<OwinWebApiService>(s =>
                {
                    s.ConstructUsing(name => new OwinWebApiService("http://localhost:9000/"));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDisplayName("RemoteMedia Service");
                x.SetServiceName("RemoteMedia");
            });
        }
    }
}