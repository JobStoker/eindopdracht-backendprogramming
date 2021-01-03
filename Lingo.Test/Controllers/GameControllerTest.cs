using Lingo.Controllers;
using Lingo.Models;
using Lingo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lingo.Test.Controllers
{
    [TestClass]
    public class GameControllerTest
    {

        private readonly GamesController _gamesController;
        private readonly Mock<IGameRepository> _gameRepositoryMock = new Mock<IGameRepository>();
        private readonly Mock<ILogger<GamesController>> _loggerMock  = new Mock<ILogger<GamesController>>();

        //Mock data
        private Game game = new Game();
        private Word word = new Word();
        private Round round = new Round();
        private Turn turn = new Turn();

        public GameControllerTest()
        {
            _gamesController = new GamesController(_gameRepositoryMock.Object, _loggerMock.Object);

            game.Id = new int();
            game.AuthToken = "testtoken";

            word.Id = new int();
            word.Name = "hallo";

            round.Id = new int();
            round.GameId = game.Id;
            round.WordId = word.Id;
            round.Correct = true;
            round.Game = game;
            round.Word = word;

            turn.Id = new int();
            turn.RoundId = round.Id;
            turn.GuessedWord = "hallo";
        }

        [TestMethod]
        public void TestFindGameByIdWhenGameExists() {
            // arrange
            _gameRepositoryMock.Setup(g => g.GetGame(game.Id)).Returns(game);

            // act
            var result = _gamesController.Games(game.Id);
            
            // assert
            dynamic resultData = new JsonResultDynamicWrapper(result);
            Assert.AreEqual(game.Id, resultData.Id);
            Assert.AreEqual(game.AuthToken, resultData.AuthToken);
        }

        [TestMethod]
        public void TestFindGameByIdWhenNull()
        {
            // arrange
            _gameRepositoryMock.Setup(g => g.GetGame(It.IsAny<int>())).Returns(() => null);

            // act
            var result = _gamesController.Games(new int());

            // assert
            dynamic resultData = new JsonResultDynamicWrapper(result);
            Assert.AreEqual(null, result.Value);    
        }

        [TestMethod]
        public void TestCreateGame()
        {
            // arrange
            _gameRepositoryMock.Setup(g => g.CreateGame(game)).Returns(game);

            // act
            var result = _gamesController.Create(game);

            // assert
            dynamic resultData = new JsonResultDynamicWrapper(result);
            Assert.AreEqual(game.Id, resultData.Id);
            Assert.AreEqual(game.AuthToken, resultData.AuthToken);
        }

        [TestMethod]
        public void TestCreateRound()
        {
            // arrange
            _gameRepositoryMock.Setup(g => g.CreateRound(round)).Returns(round);

            // act
            var result = _gamesController.Round(round);

            // assert
            dynamic resultData = new JsonResultDynamicWrapper(result);
            Assert.AreEqual(round.Id, resultData.Id);
            Assert.IsTrue(resultData.Correct);
        }

        [TestMethod]
        public void TestCreateRoundWhenGameNull()
        {
            round.Game = null;
            // arrange
            _gameRepositoryMock.Setup(g => g.CreateRound(round)).Returns(round);

            // act
            var result = _gamesController.Round(round);

            // assert
            dynamic resultData = new JsonResultDynamicWrapper(result);
            Assert.AreEqual(0, resultData.Id);
            Assert.AreEqual(null, resultData.Game);
           // Assert.AreEqual(null, resultData.Word);
        }

        [TestMethod]
        public void TestNewTurn()
        {
            // arrange
            _gameRepositoryMock.Setup(g => g.NewTurn(turn)).Returns(turn);

            // act
            var result = _gamesController.Turn(turn);

            // assert
            dynamic resultData = new JsonResultDynamicWrapper(result);
            Assert.AreEqual(turn.Id, resultData.Id);
            Assert.AreEqual(turn.GuessedWord, resultData.GuessedWord);
        }
    }
}
