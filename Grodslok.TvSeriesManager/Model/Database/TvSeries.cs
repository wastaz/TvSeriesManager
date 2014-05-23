using System;
using System.Collections.Generic;

namespace Grodslok.TvSeriesManager.Model.Database {
    public class TvSeries {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int TvRageShowId { get; set; }

        public IList<Season> Seasons { get; set; } 
    }

    public class Season {
        public int Number { get; set; }

        public IList<Episode> Episodes { get; set; } 
    }

    public class Episode {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}