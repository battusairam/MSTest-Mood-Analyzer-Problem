using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

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
}

[TestClass]
public class MoodAnalyserTests
{
    [TestMethod]
    public void TestConstructor_WhenNotProper_ShouldThrowMoodAnalysisException()
    {
        try
        {
             Type moodAnalyserType = typeof(MoodAnalyser);
            ConstructorInfo constructor = moodAnalyserType.GetConstructor(new Type[] { typeof(int) }); // Pass a wrong constructor parameter
            object moodAnalyserObj = constructor.Invoke(new object[] { 5 });

            // If the above line does not throw an exception, fail the test
            Assert.Fail("No exception was thrown.");
        }
        catch (TargetInvocationException ex)
        {
             if (ex.InnerException is TargetInvocationException innerEx)
            {
                throw new MoodAnalysisException("No such method error.", innerEx);
            }
        }
    }
}
