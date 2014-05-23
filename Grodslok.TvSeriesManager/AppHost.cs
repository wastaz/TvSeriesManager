using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Funq;
using Grodslok.TvSeriesManager.Services;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Database.Server;
using ServiceStack;
using ServiceStack.Mvc;

namespace Grodslok.TvSeriesManager {
    public class AppHost : AppHostBase {
        public AppHost() : base("MVC 4", typeof(HelloService).Assembly) { }

        public override void Configure(Container container) {
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
            SetupContainer(container);
        }

        private void SetupContainer(Container container) {
            NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8080);
            var ravenInstance = new EmbeddableDocumentStore { DataDirectory = "App_Data" };
            ravenInstance.Initialize();
            container.Register<IDocumentStore>(ravenInstance);
        } 

        public class Test {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
        }
    }
}