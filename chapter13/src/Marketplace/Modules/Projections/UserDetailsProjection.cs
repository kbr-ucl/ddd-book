using System;
using System.Threading.Tasks;
using Marketplace.Infrastructure.RavenDb;
using Raven.Client.Documents.Session;
using static Marketplace.Ads.Messages.UserProfile.Events;
using static Marketplace.Modules.Projections.ReadModels;

namespace Marketplace.Modules.Projections
{
    public static class UserDetailsProjection
    {
        public static Func<Task> GetHandler(
            IAsyncDocumentSession session,
            object @event)
        {
            Func<Guid, string> getDbId = UserDetails.GetDatabaseId;

            return @event switch
            {
                UserRegistered e => 
                    () => Create(e.UserId, e.FullName),
                UserDisplayNameUpdated e =>
                    () => Update(e.UserId, x => x.DisplayName = e.DisplayName),
                ProfilePhotoUploaded e =>
                    () => Update(e.UserId, x => x.PhotoUrl = e.PhotoUrl),
                _ => (Func<Task>) null
            };

            Task Update(Guid id, Action<UserDetails> update)
                => session.UpdateItem(getDbId(id), update);

            Task Create(Guid userId, string displayName)
                => session.StoreAsync(
                    new UserDetails
                    {
                        Id = getDbId(userId),
                        DisplayName = displayName
                    }
                );
        }
    }
}