using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;

namespace Contrib.Profile {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ViewProfiles = new Permission { Description = "View profiles", Name = "ViewProfiles" };
        public virtual Feature Feature { get; set; }

        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                ViewProfiles
            };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Anonymous",
                    Permissions = new[] {ViewProfiles}
                },
                new PermissionStereotype {
                    Name = "Authenticated",
                    Permissions = new[] {ViewProfiles}
                },
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {ViewProfiles}
                },
                new PermissionStereotype {
                    Name = "Editor",
                    Permissions = new[] {ViewProfiles}
                },
                new PermissionStereotype {
                    Name = "Moderator",
                    Permissions = new[] {ViewProfiles}
                },
                new PermissionStereotype {
                    Name = "Author",
                    Permissions = new[] {ViewProfiles}
                },
                new PermissionStereotype {
                    Name = "Contributor",
                    Permissions = new[] {ViewProfiles}
                },
            };
        }

    }
}


