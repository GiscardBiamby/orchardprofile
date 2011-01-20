using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;

namespace Contrib.Profile {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterTypeDefinition("User",
                cfg => cfg
                    .WithPart("ProfilePart", part => part.WithSetting("Stereotype", "Profile"))
                );

            return 1;
        }
    }
}