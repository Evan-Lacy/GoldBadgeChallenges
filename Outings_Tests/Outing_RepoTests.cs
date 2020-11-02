using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outings_Repo;

namespace Outings_Tests
{
    [TestClass]
    public class Outing_RepoTests
    {
        Outing _outingOne = new Outing(20, EventType.Bowling, new DateTime(2020, 11, 18), 1234.56m);
        Outing _outingTwo = new Outing(50, EventType.Bowling, new DateTime(2020, 09, 20), 1478.29m);
        Outing_Repository _repo = new Outing_Repository();

        [TestMethod]
        public void AddOutings_ShouldReturnTrue()
        {
            //Arrange
            
            //Act
            bool wasAdded = _repo.AddNewOuting(_outingOne);
            //Assert
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void GetAllOutings_ShouldRightCollection()
        {
            //Arrange
            _repo.AddNewOuting(_outingOne);
            _repo.AddNewOuting(_outingTwo);

            //Act
            List<Outing> contents = _repo.GetOutings();
            bool hasOutingOne = contents.Contains(_outingOne);
            bool hasOutingTwo = contents.Contains(_outingTwo);

            //Assert
            Assert.IsTrue(hasOutingOne);
            Assert.IsTrue(hasOutingTwo);
        }

        [TestMethod]
        public void CombineCosts_ShouldBeEqual()
        {
            //Arrange
            _repo.AddNewOuting(_outingOne);
            _repo.AddNewOuting(_outingTwo);

            decimal total = 2712.85m;
            //Act

            //Assert
            Assert.AreEqual(_repo.CombinedCost(), total);
        }

        [TestMethod]
        public void GetCostsByType_ShouldReturn()
        {
            //Arrange
            _repo.AddNewOuting(_outingOne);
            _repo.AddNewOuting(_outingTwo);
            decimal total = 2712.85m;
            //Act

            //Assert
            Assert.AreEqual(_repo.CostsByType(EventType.Bowling), total);

        }

    }
}
