using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Rabbit.Duplication.Extensions;
using Rabbit.Duplication.SetValueStrategies;
using Rabbit.Duplication.SetValueStrategies.Builders.Extensions;
using Test.Model;
using Test.Model.SetValueStrategyBuilders.Manager;

namespace Test.SetValueStrategiesTests
{
    [TestClass]
    public class SetValueStrategyBuilderExtensionTest
    {
        [TestMethod]
        public void CanMergeSetValueStrategiesBitweenTwoBuilders()
        {
            // Arrange
            var m1 = new Manager();
            var builder1 = m1.SetValueStrategyBuilder;
            var builder2 = new KeepAllStaffsOnManagerStrategyBuilder();

            // Act
            var strategies = builder2.MergeWith(builder1);

            // Assert
            var kvp = strategies.First(x => x.Key.GetPropertyInfo().Name == "Staffs");
            Assert.AreEqual(typeof(KeepSameValueStrategy), kvp.Value.GetType());
        }
    }
}
