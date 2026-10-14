```csharp
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add one item and remove it.
    // Expected Result: The item added is returned.
    // Defect(s) Found: The original Dequeue did not remove the item.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 1);

        Assert.AreEqual("Apple", priorityQueue.Dequeue());
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Add items with different priorities, including the highest
    // priority item at the end of the queue.
    // Expected Result: The highest-priority item is removed first.
    // Defect(s) Found: The original loop skipped the last item.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("Highest", 10);

        Assert.AreEqual("Highest", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add several items with the same priority.
    // Expected Result: Items are removed in FIFO order.
    // Defect(s) Found: The original >= comparison could select a later
    // item with the same priority instead of the first one.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue an empty queue.
    // Expected Result: InvalidOperationException with the exact message
    // "The queue is empty."
    // Defect(s) Found: Verify that the required exception is thrown.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Scenario: Remove the highest-priority item and inspect the queue.
    // Expected Result: Only the removed item disappears from the queue.
    // Defect(s) Found: The original Dequeue returned the value without
    // removing the selected item.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 8);
        priorityQueue.Enqueue("Third", 4);

        Assert.AreEqual("Second", priorityQueue.Dequeue());

        Assert.AreEqual(
            "[First (Pri:2), Third (Pri:4)]",
            priorityQueue.ToString());
    }
}
```
