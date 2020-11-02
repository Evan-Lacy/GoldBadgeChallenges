using System;
using System.Collections.Generic;
using Badges_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badges_Tests
{
    [TestClass]
    public class Badges_Tests
    {
        Badge badges = new Badge(007, new List<string>{"A1", "B3", "C2"});
        Badge newbie = new Badge(007, new List<string>{"A1", "B3"});
        Badges_Repository _repo = new Badges_Repository();

        [TestMethod]
        public void AddBadge_ShouldReturnTrue()
        {
            //Triple AAA

            //Arrange

            Badge badge = new Badge(69);
            Badges_Repository repo = new Badges_Repository();

            //Act

            bool wasMade = repo.CreateNewBadge(badge);

            //Assert
            Assert.IsTrue(wasMade);
        }

        [TestMethod]
        public void GetAllBadges_ShouldReturnRightList()
        {
            //Arrange

            _repo.CreateNewBadge(badges);

            //Act
            //since ListAllBadges is of return type Dictionary, need a dictionary variable
            Dictionary<int, List<string>> dict = _repo.ListAllBadges();
            bool containsThem = dict.ContainsKey(badges.BadgeID);
            //Assert
            Assert.IsTrue(containsThem);
        }

        [TestMethod]
        public void GetBadgeByID_ShouldReturnRightList()
        {
            //Arrange
            _repo.CreateNewBadge(badges);
            int id = 007;
            //Act
            Badge result = _repo.GetBadgeByID(id);

            //Assert
            Assert.AreEqual(result.BadgeID, badges.BadgeID);
        }

        [TestMethod]
        public void UpdateBadge_ShouldReturnTrue()
        {
            //Arrange
            _repo.CreateNewBadge(badges);

            //Act

            bool wasChanged = _repo.UpdateBadge(badges.BadgeID, newbie);
            //Assert
            Assert.IsTrue(wasChanged);
        }

        [TestMethod]
        public void DeleteBadge_ShouldReturnTrue()
        {
            //Arrange
            _repo.CreateNewBadge(badges);
            //Act
            //damn similar to my update... huh
            bool wasDeleted = _repo.DeletingBadge(badges);

            //Assert
            Assert.IsTrue(wasDeleted);
        }
    }
}
