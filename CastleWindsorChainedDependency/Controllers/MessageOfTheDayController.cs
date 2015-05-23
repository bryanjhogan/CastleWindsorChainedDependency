using System.Web.Mvc;
using CastleWindsorChainedDependency.Contracts;
using CastleWindsorChainedDependency.Models;

namespace CastleWindsorChainedDependency.Controllers
{
    public class MessageOfTheDayController : Controller
    {
        private readonly IMessageOfTheDayService _messageOfTheDayService;
        public MessageOfTheDayController(IMessageOfTheDayService messageOfTheDayService)
        {
            _messageOfTheDayService = messageOfTheDayService;
        }

        public ActionResult Index()
        {
            var motd = new MessageOfTheDay(_messageOfTheDayService.GetMessageOfTheDay());
            
            //string[] parts = _messageOfTheDayService.GetMessageOfTheDay().Split(':');
            //motd.MOTD = parts[0];
            //motd.LoaderUsed= parts[1];
            //motd.SerivceUsed = parts[2];

            return View(motd);
        }
    }
}
