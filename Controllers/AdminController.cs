using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Contrib.Profile.Services;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;
using Orchard.Mvc;
using Orchard.Security;

namespace Contrib.Profile.Controllers {
    public class AdminController : Controller, IUpdateModel {

        private readonly IMembershipService _membershipService;
        private readonly IProfileService _profileService;

        public AdminController(IOrchardServices services,
            IMembershipService membershipService,
            IProfileService profileService) {

            _membershipService = membershipService;
            _profileService = profileService;

            Services = services;
        }

        private IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public ActionResult Details(string username) {
            if (!Services.Authorizer.Authorize(Permissions.ManageProfiles, T("Not allowed to manage profiles")))
                return new HttpUnauthorizedResult();

            IUser user = _membershipService.GetUser(username);

            dynamic shape = Services.ContentManager.BuildDisplay(user);

            return new ShapeResult(this, shape); 
        }

        public ActionResult EditProfile(string username) {
            if (!Services.Authorizer.Authorize(Permissions.ManageProfiles, T("Not allowed to manage profiles")))
                return new HttpUnauthorizedResult();

            IUser user = _membershipService.GetUser(username);
            dynamic shape = Services.ContentManager.BuildEditor(user);

            return new ShapeResult(this, shape);
        }

        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        }

        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage) {
            ModelState.AddModelError(key, errorMessage.ToString());
        }
    }
}