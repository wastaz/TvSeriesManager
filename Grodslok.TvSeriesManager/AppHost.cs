using System.Web.Mvc;
using Funq;
using Grodslok.TvSeriesManager.Model.Database;
using Grodslok.TvSeriesManager.Services;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Database.Server;
using ServiceStack;
using ServiceStack.Mvc;

namespace Grodslok.TvSeriesManager {
    public class AppHost : AppHostBase {
        private IDocumentStore ravenInstance;

        public AppHost() : base("MVC 4", typeof(AppHost).Assembly) { }

        public override void Configure(Container container) {
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
            SetupRaven();
            SetupContainer(container);
        }

        private void SetupRaven() {
            NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8080);
            ravenInstance = new EmbeddableDocumentStore { DataDirectory = "App_Data" };
            ravenInstance.Initialize();

            ravenInstance.Conventions.RegisterIdConvention<User>((dbName, commands, user) => "users/" + user.Name);
        }

        private void SetupContainer(Container container) {
            container.Register<IDocumentStore>(ravenInstance);
            container.Register<IDocumentSession>(c => c.Resolve<IDocumentStore>().OpenSession()).ReusedWithin(ReuseScope.Request);
        } 
    }
}