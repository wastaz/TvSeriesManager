using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace Grodslok.TvSeriesManager.Services {
    public class HelloService : Service {
        public object Any(HelloRequest r) {
            return DateTime.Now;
        }
    }

    [Route("/hello/{Name}")]
    public class HelloRequest {
        public string Name { get; set; }
    }
}
