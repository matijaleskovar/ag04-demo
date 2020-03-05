using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccessLayer.Interfaces;
using BusinessAccessLayer.Services;
using DTO;
using DTO.Player.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ag04_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerService _playerService;

        public PlayerController(ILogger<PlayerController> logger, IPlayerService playerService)
        {
            _logger = logger;
            _playerService = playerService;
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult GetPlayer(int id)
        {
            var result = _playerService.GetPlayerProfile(id);

            if (result.Id == 0)
            {
                //It would be better 204 No Content, 404 is for missing endpoint
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult SignInPlayer(PlayerSignInReqModel playerData)
        {
            var result = _playerService.PlayerSignUp(playerData);

            if(result.PlayerAlreadyExist)
            {
                return Conflict(result.Error);
            }

            return Created(new Uri($"/player/{result.PlayerId.ToString()}", UriKind.Relative), result.PlayerId);
        }

        [Route("list")]
        [HttpGet]
        public ActionResult GetPlayers()       
        {
            var result = _playerService.GetAllPlayerProfiles();

            return Ok(result);

        }
        [Route("{opponent_id}/game")]
        [HttpPost]
        public ActionResult ChallengePlayer([FromRoute]int opponent_id, [FromBody]PlayerChallengeReqModel challengeData)
        {
            challengeData.OpponentId = opponent_id;

            var result = _playerService.ChallengePlayer(challengeData);

            if (result.Data == null)
            {
                //It would be better 204 No Content, 404 is for missing endpoint
                return NotFound(result.Error);
            }

            return Created(new Uri($"/game/{result.Data.GameId.ToString()}", UriKind.Relative), result.Data);
        }
    }
}
