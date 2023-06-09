using MSTest_Mood_Analyzer_Problem.MoodAnalyzer;
namespace TestProject1_MoodAnalyzer;
using System;
[TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        // Arrange
        MoodAnalyzerClass obj = new MoodAnalyzerClass("null");

        // Act
        string expected = "Happy";
        string actual = obj.AnalyzeMood();

        // Assert
        Assert.AreEqual(expected, actual);
        
        }
    }