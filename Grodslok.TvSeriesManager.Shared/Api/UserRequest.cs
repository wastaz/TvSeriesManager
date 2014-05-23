using System;
using System.Collections.Generic;
using ServiceStack;

namespace Grodslok.TvSeriesManager.Services {
    [Route("/users/{Name}")]
    public class UserRequest : IReturn<UserResponse> {
        public string Name { get; set; }
    }

    public class UserResponse {
        public string Name { get; set; }
        public IList<UserSeenEpisode> SeenEpisodes { get; set; }
    }

    public class UserSeenEpisode {
        public DateTime SeenDate { get; set; }
        public Guid SeriesId { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }

        public string SeriesName { get; set; }
        public string EpisodeName { get; set; }
    }
}