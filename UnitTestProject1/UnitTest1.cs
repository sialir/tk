using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamGrading.Tests
{
    [TestClass]
    public class ExamGradingTests
    {
        [TestMethod]
        public void CalculateScore_ValidScores_ReturnsCorrectGrade()
        {
            Assert.AreEqual("5 (отлично)", GetGrade(20, 35, 18));
            Assert.AreEqual("4 (хорошо)", GetGrade(15, 25, 10));
            Assert.AreEqual("3 (удовлетворительно)", GetGrade(10, 10, 5));
            Assert.AreEqual("2 (неудовлетворительно)", GetGrade(5, 5, 3));
        }

        [TestMethod]
        public void CalculateScore_InvalidScores_ReturnsError()
        {
            Assert.IsFalse(IsValid(-1, 30, 10)); // Отрицательное значение
            Assert.IsFalse(IsValid(23, 30, 10)); // Превышение максимума
            Assert.IsFalse(IsValid(15, -5, 10)); // Отрицательное значение
            Assert.IsFalse(IsValid(15, 40, 10)); // Превышение максимума
            Assert.IsFalse(IsValid(15, 30, -2)); // Отрицательное значение
            Assert.IsFalse(IsValid(15, 30, 25)); // Превышение максимума
        }

        private string GetGrade(int db, int dev, int support)
        {
            int total = db + dev + support;

            if (total >= 56) return "5 (отлично)";
            if (total >= 32) return "4 (хорошо)";
            if (total >= 16) return "3 (удовлетворительно)";
            return "2 (неудовлетворительно)";
        }

        private bool IsValid(int db, int dev, int support)
        {
            return db >= 0 && db <= 22 &&
                   dev >= 0 && dev <= 38 &&
                   support >= 0 && support <= 20;
        }
    }
}
