using Duplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Model;
using Test.Model.SetValueStrategyBuilders.Manager;

namespace Test
{
    [TestClass]
    public class ManagerDuplicationTest
    {
        [TestMethod]
        public void CanDuplicateManagerWithDefaultSetValueStrategies()
        {
            // Arrange
            var m1 = new Manager()
            {
                FullName = "Manager 1"
            };
            m1.AddStaff(new Worker()
            {
                FullName = "Worker 1"
            });
            m1.AddStaff(new Manager()
            {
                FullName = "Team leader 1"
            });

            // Act
            var m2 = m1.Duplicate();

            // Assert
            Assert.AreNotEqual(m1.Id, m2.Id);
            Assert.AreEqual(m1.FullName, m2.FullName);
            Assert.AreEqual(0, m2.Staffs.Count);
        }

        [TestMethod]
        public void CanDuplicateManagerWithOverloadSetValueStrategies()
        {
            // Arrange
            var m1 = new Manager()
            {
                FullName = "Manager 1"
            };
            m1.AddStaff(new Worker()
            {
                FullName = "Worker 1"
            });
            m1.AddStaff(new Manager()
            {
                FullName = "Team leader 1"
            });

            // Act
            var m2 = m1.Duplicate(new KeepAllStaffsOnManagerStrategyBuilder());

            // Assert
            Assert.AreNotEqual(m1.Id, m2.Id);
            Assert.AreEqual(m1.FullName, m2.FullName);
            Assert.AreEqual(m1.Staffs.Count, m2.Staffs.Count);
        }
    }
}
