using System.Linq;
using Raven.Client;
using ServiceStack;

namespace Grodslok.TvSeriesManager.Services {
    public class HelloService : Service {
        public object Any(HelloRequest r) {
            var docStore = ServiceStackHost.Instance.Resolve<IDocumentStore>();
            using(var session = docStore.OpenSession()) {
                session.Store(new AppHost.Test { Firstname = "Morris", Lastname = "Hund" });
                session.SaveChanges();
            }

            using(var session = docStore.OpenSession()) {
                var theDog = from dog in session.Query<AppHost.Test>()
                             where dog.Firstname == "Morris"
                             select dog;
                foreach(var dog in theDog) {
                    return string.Format("The dog is named {0} {1}", dog.Firstname, dog.Lastname);
                }
            }

            return "No dog!";
        }
    }

    [Route("/hello/{Name}")]
    public class HelloRequest {
        public string Name { get; set; }
    }
}
