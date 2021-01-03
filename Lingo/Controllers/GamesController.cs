using System;
using Microsoft.AspNetCore.Mvc;
using Lingo.Models;
using Microsoft.Extensions.Logging;
using Lingo.Repositories;


namespace Lingo.Controllers
{
    public class GamesController : Controller
    {

        private readonly ILogger<GamesController> _logger;
        private readonly IGameRepository _repository;

        public GamesController(IGameRepository repository, ILogger<GamesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public JsonResult Games(int id)
        {
            var result = Json(_repository.GetGame(id));

            if (result == null)
            {
                _logger.LogInformation("Repository returned Null for: Game");
                return null;
            }

            return result;
        }

        [HttpPost]
        public JsonResult Create([FromBody] Game game)
        {
            var result = Json(_repository.CreateGame(game));

            return result;
        }

        [HttpPost]
        public JsonResult Round([FromBody] Round round)
        {
            var result = Json(_repository.CreateRound(round));

            if (result == null)
            {
                _logger.LogInformation("Repository returned Null for: Round");
                return null;
            }

            return result;
        }

        [HttpPost]
        public JsonResult Turn([FromBody] Turn turn)
        {
            var result = Json(_repository.NewTurn(turn)); 

            if(result == null)
            {
                _logger.LogInformation("Repository returned Null for: Turn");
                return null;
            }

            return result;    
        }
    }
}
