using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lingo.Test.Repositories
{
    [TestClass]
    public class GameRepositoryTest
    {
        private readonly Mock<ILogger<GamesController>> _loggerMock = new Mock<ILogger<GamesController>>();

        [TestMethod]
        public void FindGameByIdTest()
        {

        }
    }
}
