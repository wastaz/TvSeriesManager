using System;
using System.Collections.Generic;
using System.Linq;
using Grodslok.TvSeriesManager.Model.Database;
using Raven.Client;
using Raven.Client.Linq;
using ServiceStack;

namespace Grodslok.TvSeriesManager.Services {
    public class UserService : Service {
        private readonly IDocumentSession session;

        public UserService(IDocumentSession session) {
            this.session = session;
        }

        public UserResponse Post(UserRequest request) {
            var user = new User(request.Name) {
                                                  EpisodesSeen = new List<SeenEpisode>()
                                              };
            session.Store(user);
            session.SaveChanges();
            return user.ConvertTo<UserResponse>();
        }

        public UserResponse Get(UserRequest request) {
            var myUser =
                (from user in session.Query<User>()
                 where user.Name == request.Name
                 select user).SingleOrDefault();
            if(myUser == null) {
                throw HttpError.NotFound("User {0} does not exist!".Fmt(request.Name));
            }
            return myUser.ConvertTo<UserResponse>();
        }

        public WatchedEpisodeResponse Post(WatchedEpisodeRequest request) {
            return request.ConvertTo<WatchedEpisodeResponse>();
        }
    }

}