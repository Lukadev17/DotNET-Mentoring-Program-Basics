using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.ClientModels;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BrainstormSessions.Api
{
    public class IdeasController : ControllerBase
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        private readonly ILogger<IdeasController> _logger;
        public IdeasController(IBrainstormSessionRepository sessionRepository, ILogger<IdeasController> logger)
        {
            _sessionRepository = sessionRepository;
            _logger = logger;
        }

        #region snippet_ForSessionAndCreate
        [HttpGet("forsession/{sessionId}")]
        public async Task<IActionResult> ForSession(int sessionId)
        {
            _logger.LogInformation("ForSession called with sessionId {SessionId}", sessionId);

            var session = await _sessionRepository.GetByIdAsync(sessionId);
            if (session == null)
            {
                _logger.LogWarning("Session with id {SessionId} not found", sessionId);
                return NotFound(sessionId);
            }

            var result = session.Ideas.Select(idea => new IdeaDTO()
            {
                Id = idea.Id,
                Name = idea.Name,
                Description = idea.Description,
                DateCreated = idea.DateCreated
            }).ToList();

            _logger.LogInformation("Returning {Count} ideas for session {SessionId}", result.Count, sessionId);


            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]NewIdeaModel model)
        {
            _logger.LogInformation("Create called for session {SessionId} with idea name {IdeaName}", model.SessionId, model.Name);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for Create: {@ModelState}", ModelState);
                return BadRequest(ModelState);
            }

            var session = await _sessionRepository.GetByIdAsync(model.SessionId);
            if (session == null)
            {
                _logger.LogWarning("Session with id {SessionId} not found", model.SessionId);
                return NotFound(model.SessionId);
            }

            var idea = new Idea()
            {
                DateCreated = DateTimeOffset.Now,
                Description = model.Description,
                Name = model.Name
            };
            session.AddIdea(idea);

            await _sessionRepository.UpdateAsync(session);

            _logger.LogInformation("Idea '{IdeaName}' added to session {SessionId}", model.Name, model.SessionId);


            return Ok(session);
        }
        #endregion

        #region snippet_ForSessionActionResult
        [HttpGet("forsessionactionresult/{sessionId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<IdeaDTO>>> ForSessionActionResult(int sessionId)
        {
            _logger.LogInformation("ForSessionActionResult called with sessionId {SessionId}", sessionId);

            var session = await _sessionRepository.GetByIdAsync(sessionId);

            if (session == null)
            {
                _logger.LogWarning("Session with id {SessionId} not found", sessionId);
                return NotFound(sessionId);
            }

            var result = session.Ideas.Select(idea => new IdeaDTO()
            {
                Id = idea.Id,
                Name = idea.Name,
                Description = idea.Description,
                DateCreated = idea.DateCreated
            }).ToList();

            _logger.LogInformation("Returning {Count} ideas for session {SessionId}", result.Count, sessionId);

            return result;
        }
        #endregion

        #region snippet_CreateActionResult
        [HttpPost("createactionresult")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BrainstormSession>> CreateActionResult([FromBody]NewIdeaModel model)
        {
            _logger.LogInformation("CreateActionResult called for session {SessionId} with idea name {IdeaName}", model.SessionId, model.Name);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for CreateActionResult: {@ModelState}", ModelState);
                return BadRequest(ModelState);
            }

            var session = await _sessionRepository.GetByIdAsync(model.SessionId);

            if (session == null)
            {
                _logger.LogWarning("Session with id {SessionId} not found", model.SessionId);
                return NotFound(model.SessionId);
            }

            var idea = new Idea()
            {
                DateCreated = DateTimeOffset.Now,
                Description = model.Description,
                Name = model.Name
            };
            session.AddIdea(idea);

            await _sessionRepository.UpdateAsync(session);

            _logger.LogInformation("Idea '{IdeaName}' created and added to session {SessionId}", model.Name, model.SessionId);

            return CreatedAtAction(nameof(CreateActionResult), new { id = session.Id }, session);
        }
        #endregion
    }
}
