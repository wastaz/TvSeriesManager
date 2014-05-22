using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Funq;
using Grodslok.TvSeriesManager.Services;
using Raven.Client.Document;
using ServiceStack;
using ServiceStack.Mvc;

namespace Grodslok.TvSeriesManager {
    public class AppHost : AppHostBase {
        public AppHost() : base("MVC 4", typeof(HelloService).Assembly) { }

        public override void Configure(Container container) {
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));

            var documentStore = new DocumentStore { ConnectionStringName = "ravenDB" };
            documentStore.Initialize();
            using(var session = documentStore.OpenSession()) {
                session.Store(new Test { Firstname = "Morris", Lastname = "Hund" });
                session.SaveChanges();
            }
        }

        public class Test {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
        }
    }
}