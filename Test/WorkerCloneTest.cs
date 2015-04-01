using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Model;

namespace Test
{
    [TestClass]
    public class WorkerCloneTest
    {
        [TestMethod]
        public void CloneCanWorkOnPrivateFields()
        {
            // Arrange
            var w1 = new Worker();
            w1.SetAge(10);

            // Act
            var w2 = w1.Clone();

            // Assert
            Assert.AreEqual(w1.Age, w2.Age);
        }
    }
}
