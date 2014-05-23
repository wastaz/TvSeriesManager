using System;
using System.Collections.Generic;

namespace Grodslok.TvSeriesManager.Model.Database {
    public class User {
        public User() { }
        public User(string name) {
            Name = name;
            EpisodesSeen = new List<SeenEpisode>();
        }

        public string Name { get; set; }
        public IList<SeenEpisode> EpisodesSeen { get; set; }
    }

    public class SeenEpisode {
        public DateTime SeenDate { get; set; }
        public Guid SeriesId { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }

        public string SeriesName { get; set; }
        public string EpisodeName { get; set; }
    }
}