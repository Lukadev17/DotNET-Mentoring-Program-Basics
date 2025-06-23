using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace BrainstormSessions.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        private readonly ILogger<HomeController> _logger;
        public HomeController(IBrainstormSessionRepository sessionRepository, ILogger<HomeController> logger)
        {
            _sessionRepository = sessionRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index GET called - listing all sessions");

            var sessionList = await _sessionRepository.ListAsync();

            var model = sessionList.Select(session => new StormSessionViewModel()
            {
                Id = session.Id,
                DateCreated = session.DateCreated,
                Name = session.Name,
                IdeaCount = session.Ideas.Count
            });

            _logger.LogInformation("Returning {Count} sessions", model.Count());

            return View(model);
        }

        public class NewSessionModel
        {
            [Required]
            public string SessionName { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Index(NewSessionModel model)
        {
            _logger.LogInformation("Index POST called to create new session with name: {SessionName}", model.SessionName);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state in POST Index: {@ModelState}", ModelState);

                return BadRequest(ModelState);
            }
            else
            {
                await _sessionRepository.AddAsync(new BrainstormSession()
                {
                    DateCreated = DateTimeOffset.Now,
                    Name = model.SessionName
                }); 

                _logger.LogInformation("New session created successfully: {SessionName}", model.SessionName);

            }

            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
