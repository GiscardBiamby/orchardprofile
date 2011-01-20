using Contrib.Profile.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Localization;

namespace Contrib.Profile.Drivers {
    public class FeedPartDriver : ContentPartDriver<ProfilePart> {
        public FeedPartDriver() {
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }
        protected override string Prefix { get { return "ProfilePart"; } }

        protected override DriverResult Display(ProfilePart profilePart, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_Profile_ProfilePart",
                                () => shapeHelper.EditorTemplate(TemplateName: "Parts.Profile.ProfilePart", Model: profilePart, Prefix: Prefix));
        }

        protected override DriverResult Editor(ProfilePart profilePart, dynamic shapeHelper) {
            return ContentShape("Parts_Profile_ProfilePart",
                                () => shapeHelper.EditorTemplate(TemplateName: "Parts.Profile.ProfilePart", Model: profilePart, Prefix: Prefix));
        }

        protected override DriverResult Editor(ProfilePart profilePart, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(profilePart, Prefix, null, null);
            return Editor(profilePart, shapeHelper);
        }
    }
}