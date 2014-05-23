using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Grodslok.TvSeriesManager.Model.Database;
using Raven.Client;
using ServiceStack;

namespace Grodslok.TvSeriesManager.Services {
    public class SeriesService : Service {
        
        private IDocumentSession session;

        public SeriesService(IDocumentSession session) {
            this.session = session;
        }

        public object Get() {
            return null;
        }

        public object Post() {
            return null;
        }

        public object Put() {
            return null;
        }
    }
}