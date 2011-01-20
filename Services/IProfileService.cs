using Contrib.Profile.Models;

namespace Contrib.Profile.Services {
    public interface IProfileService {
        ProfilePart GetProfile(string username);
    }
}