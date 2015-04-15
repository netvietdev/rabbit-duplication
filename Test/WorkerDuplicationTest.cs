using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabbit.Duplication;
using Test.Model;
using Test.Model.SetValueStrategyBuilders.Worker;

namespace Test
{
    [TestClass]
    public class WorkerDuplicationTest
    {
        [TestMethod]
        public void CanDuplicateAWorker()
        {
            // Arrange
            var w1 = new Worker()
            {
                FullName = "Worker 1",
            };
            w1.AddCar(new Car()
            {
                Brand = "Kia Sorento"
            });
            w1.SetAge(10);

            // Act
            var w2 = w1.Duplicate();

            // Assert
            Assert.AreNotEqual(w1.Id, w2.Id);
            Assert.AreEqual(w1.FullName, w2.FullName);

            // Reference equals
            Assert.AreEqual(w1.Cars.Count, w2.Cars.Count);
            Assert.AreEqual(w1.Cars.First(), w2.Cars.First());
        }

        [TestMethod]
        public void CanDuplicateAWorkerWithAllCarsAreDuplicated()
        {
            // Arrange
            var w1 = new Worker()
            {
                FullName = "Worker 1",
            };
            w1.AddCar(new Car()
            {
                Brand = "Kia Sorento"
            });
            w1.SetAge(10);

            // Act
            var w2 = w1.Duplicate(new WorkerDeepCopySetValueStrategyBuilder());

            // Assert
            Assert.AreNotEqual(w1.Id, w2.Id);
            Assert.AreEqual(w1.FullName, w2.FullName);

            // Reference equals
            Assert.AreEqual(w1.Cars.Count, w2.Cars.Count);
            Assert.AreNotEqual(w1.Cars.First().Id, w2.Cars.First().Id);
            Assert.AreEqual(w1.Cars.First().Brand, w2.Cars.First().Brand);
        }

        [TestMethod]
        public void CanDuplicateAWorkerWithCustomAction()
        {
            // Arrange
            var w1 = new Worker()
            {
                FullName = "Worker 1",
            };
            w1.AddCar(new Car()
            {
                Brand = "Kia Sorento"
            });
            w1.SetAge(10);

            // Act
            var w2 = w1.Duplicate(w =>
            {
                w.FullName = "Worker 2";
                w.SetAge(20);
            });

            // Assert
            Assert.AreEqual("Worker 2", w2.FullName);
            Assert.AreEqual(20, w2.Age);
        }
    }
}
