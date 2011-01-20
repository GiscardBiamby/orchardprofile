using System.Web.Mvc;
using Orchard.ContentManagement;
using Orchard.Localization;

namespace Contrib.Profile.Controllers {
    public class HomeController : Controller, IUpdateModel {

        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        }

        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage) {
            ModelState.AddModelError(key, errorMessage.ToString());
        }
    }
}