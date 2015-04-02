using Duplication.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Model;

namespace Test
{
    [TestClass]
    public class ManagerDuplicationTest
    {
        [TestMethod]
        public void CanDuplicateManagerWithClearingAllStaffs()
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
    }
}
