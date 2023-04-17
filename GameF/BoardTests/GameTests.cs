using Microsoft.VisualStudio.TestTools.UnitTesting;
using Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void GameTest()
        {

        }

        [TestMethod()]
        public void StartTest()
        {
            Game game = new Game(4);
            game.Start();
            Assert.AreEqual(1, game.GetDijitAt(0, 0));
            Assert.AreEqual(2, game.GetDijitAt(1, 0));
            Assert.AreEqual(5, game.GetDijitAt(0, 1));
            Assert.AreEqual(15, game.GetDijitAt(2, 3));
        }

        [TestMethod()]
        public void PressAtTest()
        {
            Game game = new Game(4);
            game.Start();
            game.PressAt(2, 3);
            Assert.AreEqual(15, game.GetDijitAt(3, 3));
            Assert.AreEqual(0, game.GetDijitAt(2, 3));
            game.PressAt(2, 2);
            Assert.AreEqual (0, game.GetDijitAt(2, 2));
            Assert.AreEqual(11, game.GetDijitAt(2, 3));
        }

        [TestMethod()]
        public void GetDijitAtTest()
        {
            Game game = new Game(4);
            game.Start();
            Assert.AreEqual(0, game.GetDijitAt(-5, -34));
            Assert.AreEqual(0, game.GetDijitAt(15, 6));
        }

        [TestMethod()]
        public void SolvedTest()
        {
            Game game = new Game(4);
            game.Start();
            Assert.IsTrue(game.Solved());
            game.PressAt(2, 3);
            Assert.IsFalse(game.Solved());
            game.PressAt(3, 3);
            Assert.IsTrue(game.Solved());
        }
    }
}