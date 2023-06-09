using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

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

    public static MoodAnalyser CreateMoodAnalyser()
    {
        return new MoodAnalyser();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        MoodAnalyser other = (MoodAnalyser)obj;
        return mood.Equals(other.mood);
    }
}

[TestClass]
public class MoodAnalyserTests
{
    [TestMethod]
    public void CreateMoodAnalyser_ReturnsNonNullObject()
    {
        MoodAnalyser moodAnalyser = MoodAnalyser.CreateMoodAnalyser();
        Assert.IsNotNull(moodAnalyser);
    }

    [TestMethod]
    public void Equals_TwoObjectsWithSameMood_ReturnsTrue()
    {
        MoodAnalyser moodAnalyser1 = new MoodAnalyser("Happy");
        MoodAnalyser moodAnalyser2 = new MoodAnalyser("Happy");

        Assert.IsTrue(moodAnalyser1.Equals(moodAnalyser2));
    }

    [TestMethod]
    public void Equals_TwoObjectsWithDifferentMood_ReturnsFalse()
    {
        MoodAnalyser moodAnalyser1 = new MoodAnalyser("Happy");
        MoodAnalyser moodAnalyser2 = new MoodAnalyser("Sad");

        Assert.IsFalse(moodAnalyser1.Equals(moodAnalyser2));
    }

    [TestMethod]
    public void Equals_NullObject_ReturnsFalse()
    {
        MoodAnalyser moodAnalyser = new MoodAnalyser("Happy");

        Assert.IsFalse(moodAnalyser.Equals(null));
    }

    [TestMethod]
    public void Equals_ObjectOfDifferentType_ReturnsFalse()
    {
        MoodAnalyser moodAnalyser = new MoodAnalyser("Happy");
        string otherObject = "Happy";

        Assert.IsFalse(moodAnalyser.Equals(otherObject));
    }
}

class Program
{
    static void Main()
    {
        // Running the tests
        MoodAnalyserTests moodAnalyserTests = new MoodAnalyserTests();
        Type type = typeof(MoodAnalyserTests);

        foreach (MethodInfo method in type.GetMethods())
        {
            if (method.GetCustomAttributes(typeof(TestMethodAttribute), true).Length > 0)
            {
                Console.WriteLine("Running Test: " + method.Name);
                method.Invoke(moodAnalyserTests, null);
            }
        }
    }
}
