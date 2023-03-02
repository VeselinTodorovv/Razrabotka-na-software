using System;
using Aqua;
using NUnit.Framework;

namespace AquariumProject.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void FishConstructorShouldInicializeCorrectly() {
            Fish fish = new Fish("Tuna", 8);
            
            Assert.AreEqual("Tuna", fish.Type);
            Assert.AreEqual(8, fish.Price);
        }

        [Test]
        public void AquariumConstructorShouldInicializeCorrectly() {
            Aquarium aquarium = new Aquarium("Rectangle", 50);
            
            Assert.AreEqual("Rectangle", aquarium.Shape);
            Assert.AreEqual(50, aquarium.Capacity);
            Assert.IsEmpty(aquarium.Fishes);
        }

        [Test]
        public void RemoveMethodShoudThrowExIfListIsEmpty() {
            Aquarium aquarium = new Aquarium("Rectangle", 50);
            
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Tuna"));
        }

        [Test]
        public void RemoveMethodShoudThrowExactExceptionMessageIfListIsEmpty() {
            Aquarium aquarium = new Aquarium("Rectangle", 50);
            var ex = Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Tuna"));
            
            Assert.AreEqual("Invalid operation", ex.Message);
        }

        [Test]
        public void RemoveMethodShoudThrowExeptionIfFishIsMissing() {
            Aquarium aquarium = new Aquarium("Rectangle", 50);
            Fish fish = new Fish("Tuna", 8);
            aquarium.AddFish(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Salmon"));
        }

        [Test]
        public void RemoveMethodShoudThrowExactMessageIfFishIsMissing() {
            Aquarium aquarium = new Aquarium("Rectangle", 50);
            Fish fish = new Fish("Tuna", 8);
            aquarium.AddFish(fish);

            var ex = Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Salmon"));
            Assert.AreEqual("Invalid operation", ex.Message);
        }

        [Test]
        public void RemoveMethodShoudWorkCorrectlyAndDecreseNumberOfFishesInTheList() {
            Aquarium aquarium = new Aquarium("Rectangle", 50);
            Fish fish = new Fish("Tuna", 8);
            aquarium.AddFish(fish);
            aquarium.RemoveFish("Tuna");
            
            Assert.AreEqual(0, aquarium.Fishes.Count);
        }

        [Test]
        public void RemoveMethodShoudIncreaseFreeCapacity() {
            Aquarium aquarium = new Aquarium("Rectangle", 50);
            Fish fish = new Fish("Tuna", 8);
            aquarium.AddFish(fish);
            aquarium.RemoveFish("Tuna");
            
            Assert.AreEqual(50, aquarium.Capacity);
        }

        [Test]
        public void RemoveMethodShoudRemoveExactFish() {
            Aquarium aquarium = new Aquarium("Rectangle", 50);
            Fish fish = new Fish("Tuna", 8);
            Fish fish2 = new Fish("Salmon", 10);
            aquarium.AddFish(fish);
            aquarium.AddFish(fish2);
            aquarium.RemoveFish("Tuna");
            
            Assert.AreEqual("Salmon", aquarium.Fishes[0].Type);
            Assert.AreEqual(10, aquarium.Fishes[0].Price);
        }

        [Test]
        public void ReportRemoveFishShoudPrintExactSuccessfulMessage() {
            Aquarium aquarium = new Aquarium("Rectangle", 50);
            Fish fish = new Fish("Tuna", 8);
            aquarium.AddFish(fish);
            aquarium.RemoveFish("Tuna");
            
            Assert.AreEqual("You successfully remove a fish!", aquarium.ReportRemoveFish());
        }

        [Test]
        public void EmptyMethodShoudWorkCorrectly() {
            Aquarium aquarium = new Aquarium("Rectangle", 50);
            Fish fish = new Fish("Tuna", 8);
            aquarium.AddFish(fish);
            aquarium.Empty();
            
            Assert.AreEqual(0, aquarium.Fishes.Count);
        }
    }
}