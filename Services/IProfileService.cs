using Contrib.Profile.Models;
using Orchard;
using Orchard.ContentManagement;

namespace Contrib.Profile.Services {
    public interface IProfileService : IDependency {
        ProfilePart GetProfile(string username);
        dynamic BuildProfileDisplay(IContent content);
    }
}