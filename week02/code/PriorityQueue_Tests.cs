using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue one item and dequeue it
    // Expected Result: The dequeued value matches the enqueued value
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities
    // Expected Result: Dequeue returns the highest priority item first
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Multiple items with same highest priority
    // Expected Result: Dequeue returns the first item with highest priority (FIFO)
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result); // FIFO
    }

    [TestMethod]
    // Scenario: Dequeue multiple times
    // Expected Result: Items are removed in correct priority order
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 4);
        priorityQueue.Enqueue("C", 4);
        priorityQueue.Enqueue("D", 1);

        Assert.AreEqual("B", priorityQueue.Dequeue()); // first 4
        Assert.AreEqual("C", priorityQueue.Dequeue()); // second 4
        Assert.AreEqual("A", priorityQueue.Dequeue()); // 2
        Assert.AreEqual("D", priorityQueue.Dequeue()); // 1
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: Throws InvalidOperationException
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }

    [TestMethod]
    // Scenario: Enqueue items with negative or zero priority
    // Expected Result: Dequeue still returns the highest priority (largest number)
    public void TestPriorityQueue_NegativePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", -1);
        priorityQueue.Enqueue("B", 0);
        priorityQueue.Enqueue("C", -5);

        Assert.AreEqual("B", priorityQueue.Dequeue()); // 0 is highest
        Assert.AreEqual("A", priorityQueue.Dequeue()); // -1 next
        Assert.AreEqual("C", priorityQueue.Dequeue()); // -5 last
    }
}
