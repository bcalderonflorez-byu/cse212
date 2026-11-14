using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities.
    // Expected Result: Items must be added to the back of the queue.
    // Defect(s) Found: None in Enqueue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual(
            "[A (Pri:1), B (Pri:5), C (Pri:3)]",
            priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Dequeue an item when the highest priority is at the end.
    // Expected Result: The item with priority 10 is returned.
    // Defect(s) Found: The original loop skips the last queue element.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 10);

        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority.
    // Expected Result: The first item added with that priority is returned.
    // Defect(s) Found: Using >= instead of > can select a later item
    // when equal priorities are encountered.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 10);
        priorityQueue.Enqueue("C", 10);
        priorityQueue.Enqueue("D", 5);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Remove an item from the queue.
    // Expected Result: The returned item must no longer exist in the queue.
    // Defect(s) Found: The original Dequeue does not remove the item.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with the exact message
    // "The queue is empty."
    // Defect(s) Found: No defect; this behavior is already implemented.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}
