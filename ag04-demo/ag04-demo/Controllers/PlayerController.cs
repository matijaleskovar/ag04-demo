using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccessLayer.Interfaces;
using BusinessAccessLayer.Services;
using DTO;
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

        [HttpGet]
        public ActionResult GetPlayer(int id)
        {
            var result = _playerService.GetPlayerProfile(id);

            if (result.Id == 0)
            {
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

            return Created(new Uri($"/player/player-{result.PlayerId.ToString()}", UriKind.Relative), result.PlayerId);
        }
    }
}
