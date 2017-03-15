using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class FlipFlopIteratorTests
{
    private FlipFlopIterator iterator;
    private FlipFlopIterator<object> typedIterator;

    [SetUp]
    public void SetUp()
    {
    }

    private List<int?> GetIterationList()
    {
        var result = new List<int?>();
        int? tmp;
        int loop = 0;

        while (true)
        {
            tmp = iterator.Get();
            Console.WriteLine(tmp);
            // leave if we're done
            if (tmp == null)
                break;

            result.Add(tmp);

            // delete this.
            if (++loop > 7) throw new Exception("infinite loop detected");
        }

        return result;
    }

    private List<object> GetTypedIterationList()
    {
        var result = new List<object>();
        int loop = 0;

        foreach (var obj in typedIterator.Iterate())
        {
            // cant happen, but whatever
            if (obj == null)
                break;

            result.Add(obj);

            // delete this.
            if (++loop > 7) throw new Exception("infinite loop detected");
        }

        return result;
    }

    [Test]
    public void FlipFlopIteratorTest_1()
    {
        iterator = new FlipFlopIterator(3, 1, 5);

        var actual = GetIterationList();
        var expected = new List<int?> { 3, 4, 2, 5, 1 };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void FlipFlopIteratorTest_2()
    {
        iterator = new FlipFlopIterator(3, 1, 6);

        var actual = GetIterationList();
        var expected = new List<int?> { 3, 4, 2, 5, 1, 6 };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void FlipFlopIteratorTest_3()
    {
        iterator = new FlipFlopIterator(-1, -4, 1);

        var actual = GetIterationList();
        var expected = new List<int?> { -1, 0, -2, 1, -3, -4 };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void FlipFlopIteratorTest_4()
    {
        iterator = new FlipFlopIterator(0, 0, 0);

        var actual = GetIterationList();
        var expected = new List<int?> { 0 };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void FlipFlopIteratorTest_5()
    {
        iterator = new FlipFlopIterator(-4, -4, 1);

        var actual = GetIterationList();
        var expected = new List<int?> { -4, -3, -2, -1, 0, 1 };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void FlipFlopIteratorTest_6()
    {
        iterator = new FlipFlopIterator(1, -4, 1);

        var actual = GetIterationList();
        var expected = new List<int?> { 1, 0, -1, -2, -3, -4 };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void FlipFlopIteratorTest_7()
    {
        iterator = new FlipFlopIterator(-3, -6, -1);

        var actual = GetIterationList();
        var expected = new List<int?> { -3, -2, -4, -1, -5, -6 };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void FlipFlopIteratorTest_8()
    {
        iterator = new FlipFlopIterator(-4, -6, 0);

        var actual = GetIterationList();
        var expected = new List<int?> { -4, -3, -5, -2, -6, -1, 0 };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void FlipFlopIteratorTest_9()
    {
        iterator = new FlipFlopIterator(-4, -6, -1);

        var actual = GetIterationList();
        var expected = new List<int?> { -4, -3, -5, -2, -6, -1 };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void FlipFlopIteratorTest_10()
    {
        var item1 = new { val = "Item1" };
        var item2 = new { val = "Item2" };
        var item3 = new { val = "Item3" };
        var item4 = new { val = "Item4" };
        var item5 = new { val = "Item5" };

        var collection = new List<object> { item1, item2, item3, item4, item5 };
        typedIterator = new FlipFlopIterator<object>(collection, item2);

        var actual = GetTypedIterationList();
        var expected = new List<object> { item2, item3, item1, item4, item5 };

        Assert.That(actual, Is.EquivalentTo(expected));
    }
}