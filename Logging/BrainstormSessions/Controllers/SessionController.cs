using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace BrainstormSessions.Controllers
{
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        private readonly ILogger<SessionController> _logger;

        public SessionController(IBrainstormSessionRepository sessionRepository, ILogger<SessionController> logger)
        {
            _sessionRepository = sessionRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? id)
        {
            _logger.LogInformation("SessionController Index called with id: {SessionId}", id);

            if (!id.HasValue)
            {
                _logger.LogWarning("Session id was not provided. Redirecting to Home/Index.");

                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            var session = await _sessionRepository.GetByIdAsync(id.Value);
            if (session == null)
            {
                _logger.LogWarning("Session with id {SessionId} not found.", id.Value);

                return Content("Session not found.");
            }

            var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id
            };

            _logger.LogInformation("Returning view model for session {SessionId} named '{SessionName}'", session.Id, session.Name);

            return View(viewModel);
        }
    }
}
