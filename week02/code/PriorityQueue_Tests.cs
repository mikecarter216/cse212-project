using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue one item and dequeue it
    // Expected Result: Dequeued value matches enqueued value ("A")
    // Defect(s) Found: Item was not returned correctly; dequeue sometimes failed on single-item queues.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities
    // Expected Result: Dequeue returns the highest priority (largest number) first ("B")
    // Defect(s) Found: Queue removed lowest priority instead of highest.
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
    // Scenario: Multiple items with the same highest priority
    // Expected Result: Dequeue follows FIFO order among equals (return "A" before "B")
    // Defect(s) Found: Queue did not preserve FIFO for equal-priority items.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Dequeue multiple times
    // Expected Result: Order = B, C, A, D (priority 4,4,2,1)
    // Defect(s) Found: Priority comparison wrong; items came out in unsorted order.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 4);
        priorityQueue.Enqueue("C", 4);
        priorityQueue.Enqueue("D", 1);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException thrown
    // Defect(s) Found: No exception thrown; needed explicit empty check.
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }

    [TestMethod]
    // Scenario: Enqueue items with negative or zero priority
    // Expected Result: Order = B (0), A (-1), C (-5)
    // Defect(s) Found: Negative/zero priorities mishandled; did not still pick highest number.
    public void TestPriorityQueue_NegativePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", -1);
        priorityQueue.Enqueue("B", 0);
        priorityQueue.Enqueue("C", -5);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }
}
