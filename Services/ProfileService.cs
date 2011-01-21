using System;
using System.Linq;
using Contrib.Profile.Models;
using Orchard;
using Orchard.ContentManagement;

namespace Contrib.Profile.Services {
    public class ProfileService : IProfileService {
        private readonly IOrchardServices Services;

        public ProfileService(IOrchardServices services) {
            Services = services;
        }

        public ProfilePart GetProfile(string username) {
            throw new NotImplementedException();
        }

        public dynamic BuildProfileDisplay(IContent content) {
            ContentItem contentItem = new ContentItem();
            foreach (ContentPart part in content.ContentItem.Parts) {
                if (part.Settings.Any(entry => entry.Key == "Stereotype" && entry.Value == "Profile")) {
                    contentItem.Weld(part);
                }
            }

            return Services.ContentManager.BuildDisplay(contentItem);
        }
    }
}