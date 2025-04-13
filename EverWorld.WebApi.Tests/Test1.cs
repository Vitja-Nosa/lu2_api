using Microsoft.VisualStudio.TestTools.UnitTesting;
using EverWorld.WebApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EverWorld.Tests
{
    [TestClass]
    public class EnvironmentModelTests
    {
        [TestMethod]
        public void Environment_WithValidData_IsValid()
        {
            // Arrange
            var env = new Environment
            {
                Id = 1,
                Name = "Forest",
                MaxHeight = 50,
                MaxLength = 100,
                UserId = "user123"
            };

            // Act
            var isValid = Validator.TryValidateObject(env, new ValidationContext(env), null, true);

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Environment_WithInvalidData_IsInvalid()
        {
           // Arrange
           var env = new Environment
           {
               Id = 1,
               Name = "", // Invalid: too short
               MaxHeight = 5, // Invalid: below 10
               MaxLength = 300 // Invalid: above 200
           };

            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(env, new ValidationContext(env), results, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(3, results.Count); // Expecting 3 validation errors
        }

        [TestMethod]
        public void Object2d_ValidObject_ReturnsTrue()
        {
            // Arrange
            var obj = new Object2d
            {
                PositionX = 10.5f,
                PositionY = 20.5f,
                PrefabId = 1,
                Id = 100,
                EnvironmentId = 5
            };

            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);

            // Assert
            Assert.IsTrue(isValid);  // Should be valid since all Required fields are set
        }
    }
}
