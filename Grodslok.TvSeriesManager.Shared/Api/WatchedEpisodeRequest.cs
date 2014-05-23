using System;
using ServiceStack;

namespace Grodslok.TvSeriesManager.Services {
    [Route("/seenepisode")]
    [Route("/user/{Name}/Seen/")]
    public class WatchedEpisodeRequest : IReturn<WatchedEpisodeResponse> {
        public string Name { get; set; }

        public Guid SeriesId { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
    }

    public class WatchedEpisodeResponse {
        public string Name { get; set; }

        public Guid SeriesId { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
    }
}