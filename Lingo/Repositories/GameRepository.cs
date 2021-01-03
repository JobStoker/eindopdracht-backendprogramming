using Lingo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lingo.Repositories
{
    public class GameRepository : IGameRepository
    {

        private readonly lingoContext _context;
        private readonly ILogger<IGameRepository> _logger;

        public GameRepository(lingoContext context, ILogger<IGameRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Creates a game and adds it to database
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public Game CreateGame(Game game)
        {
            try
            {
                _context.Games.Add(game);
                _context.SaveChanges();
            }
            catch (SqlException exc)
            {
                _logger.LogInformation("Unable to create game: " + exc);
            }
            return game;
        }

        public Game GetGame(int gameId)
        {
            var game = _context.Games.Find(gameId);

            if (game == null)
            {
                _logger.LogInformation("Unable to find game with id: " + gameId);
                return null;
            }
            return game;
        }

        public IEnumerable<Game> GetGames()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new round with a word based on previous rounds
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public Round CreateRound(Round round)
        {

            var game = _context.Games.Find(round.GameId);

            if (game == null)
            {
                _logger.LogInformation("Unable to find game with id: " + round.GameId);
                return null;
            }

            try
            {
                int rounds = _context.Rounds.Where(r => r.GameId == round.GameId).Count();
                round.WordId = FindRandomWordByLength(game.GetWordLengthFromRound(rounds)).Id;
                _context.Rounds.Add(round);
                _context.SaveChanges();
            }
            catch (SqlException exc)
            {
                _logger.LogInformation("Unable to create new round: " + exc);
            }

            return round;
        }

        /// <summary>
        /// New turn within round. Returns the guessed turn
        /// </summary>
        /// <param name="roundId"></param>
        /// <param name="guessedWord"></param>
        /// <returns></returns>
        public Turn NewTurn(Turn turn)
        {
            //TODO CHECK TIMESTAMPS
            //TODO CHECK TURNS = max 5
            var round = _context.Rounds.Find(turn.RoundId);
            if(round == null)
            {
                _logger.LogInformation("Unable to find round with id: " + turn.RoundId);
                return null;
            }
            try
            {
                round.Word.CompareWord(turn);
                _context.Turns.Add(turn);
                _context.SaveChanges();
            }
            catch(SqlException exc)
            {
                _logger.LogInformation("Could not create turn: " + exc);
            }

            return turn;
        }

        /// <summary>
        /// Returns a random word from words table with certain length
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private Word FindRandomWordByLength(int length)
        {
            int total = _context.Words.Count();
            Random r = new Random();
            int offset = r.Next(0, total);
            var word = _context.Words.Where(w => w.Name.Length == length).OrderBy(w => w.Id).Skip(offset).Take(1).FirstOrDefault();
            if (word == null)
            {
                _logger.LogInformation("Unable to find random word with: " + length + " length");
                return null;
            }
            return word;
        }
    }
}
