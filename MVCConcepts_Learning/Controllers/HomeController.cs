using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MVCConcepts_Learning;
using MVCConcepts_Learning.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCConcepts_Learning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuation;
        //and also Mentioned in startup class also.
        private  IOptions<EmailDetails> _options;

        private readonly IHubContext<Chat> _hubContext;
        

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration,IOptions<EmailDetails> options,IHubContext<Chat> hubContext)
        {
            _logger = logger;
            _configuation = configuration;
            _options = options;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            //way 1 To access appsetting value by using GetValue,GetSection ane we can use To inject IOption in constructor.
            string UserIdByGetvalue = _configuation.GetValue<string>("ConnectionStrings:UserId");
            string UserIdByGetSection = _configuation.GetSection("ConnectionStrings").GetSection("UserId").Value;
            string EamilIdByOptions=DisplayAppsettingValues();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private string DisplayAppsettingValues()
        {
            //To Read EmailDetails from appsetiong.json by using IOptions Inject.
            string MailId = _options.Value.EmailId;
            return MailId;
        }
        public JsonResult DisplayMessage()
        {
             return Json(new { id = 1, name = "veerababu" });
        }
       
        public async Task<ActionResult> SignalRMessage(Notifications notifications)
        {
            await _hubContext.Clients.All.SendAsync("sendToUser", notifications.MessageTitle, notifications.MessageBody);
            return View();
        }
    }

}
