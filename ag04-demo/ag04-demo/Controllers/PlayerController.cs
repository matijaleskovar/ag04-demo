using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccessLayer.Interfaces;
using BusinessAccessLayer.Services;
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
        public bool Get()
        {
            throw new NotImplementedException();

        }
    }
}
