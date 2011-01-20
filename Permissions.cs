using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;

namespace Contrib.Profile {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageProfiles = new Permission { Description = "Manage profiles", Name = "ManageProfiles" };

        public virtual Feature Feature { get; set; }

        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                ManageProfiles
            };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] { ManageProfiles }
                }
            };
        }

    }
}


