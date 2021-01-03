using Lingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lingo.Repositories
{
    public interface IGameRepository
    {
        Game GetGame(int id);
        Game CreateGame(Game game);
        IEnumerable<Game> GetGames();
        Round CreateRound(Round round);
        Turn NewTurn(Turn turn);
    }
}
