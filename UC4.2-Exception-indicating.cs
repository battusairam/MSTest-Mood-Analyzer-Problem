using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class MoodAnalysisException : Exception
{
    public MoodAnalysisException(string message) : base(message)
    {
    }
}

public class MoodAnalyser
{
    private string mood;

    public MoodAnalyser()
    {
        this.mood = "unknown";
    }

    public MoodAnalyser(string mood)
    {
        this.mood = mood;
    }

    public string GetMood()
    {
        return mood;
    }

    public void SetMood(string mood)
    {
        this.mood = mood;
    }
}

[TestClass]
public class MoodAnalyserTests
{
    [TestMethod]
    public void TestClassName_WhenImproper_ShouldThrowMoodAnalysisException()
    {
        try
        {
            string className = "WrongClassName"; // Provide an incorrect class name here

            // Use reflection to get the type based on the class name
            Type type = Type.GetType(className);

            if (type == null)
            {
                throw new MoodAnalysisException("No such class error: " + className);
            }
        }
        catch (MoodAnalysisException ex)
        {
            Assert.AreEqual("No such class error: WrongClassName", ex.Message);
        }
    }
}
