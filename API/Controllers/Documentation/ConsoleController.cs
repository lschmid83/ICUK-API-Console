using API.Core;
using System.Web.Mvc;

namespace API.Controllers.Documentation {

    /// <summary>
    /// Provides methods that respond to HTTP requests.
    /// </summary>
    public class ConsoleController : Controller {

        /// <summary>
        /// Index action method.
        /// </summary>
        /// <returns>The result of an action method.</returns>    
        public ActionResult Index() {          
            ApiConsole apiConsole = new ApiConsole();
            return Content(apiConsole.Index());
        
        }
    }
}
