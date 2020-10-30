using System;
using System.Collections.Generic;
using Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Tests
{
    [TestClass]
    public class Cafe_RepoTests
    {
        Menu_Repository repository = new Menu_Repository();
        Menu menu = new Menu(1, "Biscuits and Gravy", "Fresh made biscuits covered in delicious sausage gravy with a side of hash browns",
            "Biscuits, Sage sausage, milk, flour, potatoes", 8.59);

        [TestMethod]
        public void AddMenuItem_ShouldBeTrue()
        {
            //Triple AAA testing

            //Arrange - setup the testing objects and prepare the prereqs for your test
            Menu menu = new Menu();
            Menu_Repository repository = new Menu_Repository();

            //Act - perform the actual work of the test
            bool wasAdded = repository.AddMenuItem(menu);

            //Assert - verify the result
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void GetWholeMenu_ShouldReturnRightCollection()
        {
            //Arrange
            repository.AddMenuItem(menu);
            //Act
            List<Menu> meals = repository.GetMenu();

            bool fullDirectory = meals.Contains(menu);

            //Assert
            Assert.IsTrue(fullDirectory);
        }

        [TestMethod]
        public void GetMenuByNumber_ShouldReturnTrue()
        {
            //Arrange
            repository.AddMenuItem(menu);
            int number = 1;

            //Act
            Menu meal = repository.GetMealByNumber(number);

            //Assert
            Assert.AreEqual(meal.MealNumber, number);
        }

        [TestMethod]
        public void GetItemByName_ShouldReturnTrue()
        {
            //Arrange
            Menu_Repository repository = new Menu_Repository();
            Menu menu = new Menu(1, "Biscuits and Gravy", "Fresh made biscuits covered in delicious sausage gravy with a side of hash browns",
                "Biscuits, Sage sausage, milk, flour, potatoes", 8.59);
            repository.AddMenuItem(menu);

            string name = "Biscuits and Gravy";

            //Act

            Menu meal = repository.GetMealByName(name);
            //Assert
            Assert.AreEqual(meal.Name, name);
        }

        [TestMethod]
        public void DeleteItemByName_ShouldReturnTrue()
        {
            //Arrange
            repository.AddMenuItem(menu);

            //Act
            Menu meal = repository.GetMealByName("Biscuits and Gravy");

            bool removedMeal = repository.DeleteMealFromMenu(meal);

            //Assert
            Assert.IsTrue(removedMeal);
        }
    }
}
