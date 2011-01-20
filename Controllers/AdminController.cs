using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Localization;
using Orchard.Mvc;
using Orchard.Security;

namespace Contrib.Profile.Controllers {
    public class AdminController : Controller, IUpdateModel {

        private readonly IMembershipService _membershipService;

        public AdminController(IOrchardServices services,
            IMembershipService membershipService) {

            Services = services;

            _membershipService = membershipService;
        }

        private IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public ActionResult Details(string username) {
            if (!Services.Authorizer.Authorize(Permissions.ManageProfiles, T("Not allowed to manage profiles")))
                return new HttpUnauthorizedResult();

            IUser user = _membershipService.GetUser(username);
            IList<dynamic> parts = user.ContentItem.Parts
                .Where(part => part.Settings.Any(anyPart => anyPart.Key == "Stereotype" && anyPart.Value == "Profile"))
                .Select(part => Services.ContentManager.BuildDisplay(part)).ToList();

            dynamic shape = Services.New.Details().AddRange(parts);

            return new ShapeResult(this, shape); 
        }

        public ActionResult EditProfile(string username) {
            if (!Services.Authorizer.Authorize(Permissions.ManageProfiles, T("Not allowed to manage profiles")))
                return new HttpUnauthorizedResult();

            IUser user = _membershipService.GetUser(username);
            IList<dynamic> parts = user.ContentItem.Parts
                .Where(part => part.Settings.Any(anyPart => anyPart.Key == "Stereotype" && anyPart.Value == "Profile"))
                .Select(part => Services.ContentManager.BuildEditor(part)).ToList();

            return View((object) parts);
        }

        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        }

        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage) {
            ModelState.AddModelError(key, errorMessage.ToString());
        }
    }
}