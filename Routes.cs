using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Contrib.Profile {
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes() {
            return new[] {
                             new RouteDescriptor {   Priority = 5,
                                                     Route = new Route(
                                                         "Profile/{username}",
                                                         new RouteValueDictionary {
                                                                                      {"area", "Contrib.Profile"},
                                                                                      {"controller", "Home"},
                                                                                      {"action", "Index"}
                                                         },
                                                         new MvcRouteHandler())
                             }
                         };
        }
    }
}