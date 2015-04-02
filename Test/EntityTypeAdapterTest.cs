using Duplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Model;

namespace Test
{
    [TestClass]
    public class EntityTypeAdapterTest
    {
        [TestMethod]
        public void CanGetAllPublicPropertiesFromAllInheritenceLevels()
        {
            // Arrange
            var adapter = new EntityTypeAdapter(typeof(Worker));

            // Act
            adapter.Initialize();

            // Assert
            Assert.AreEqual(6, adapter.PublicProperties.Count);
        }
    }
}
