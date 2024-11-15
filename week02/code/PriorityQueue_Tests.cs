using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a PriorityQueue and add persons with equal priority to the queue
    // Expected Result: The person at index [0] is first dequeued
    // Defect(s) Found: The equality sign in the >= caused the higest priority to move to the next person in the loop
    // even though all persons have equal priority. Removed the = from comparison after which the test passed.
    public void TestPriorityQueue_EqualPrioriries()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("John", 1);
        priorityQueue.Enqueue("Jane", 1);
        priorityQueue.Enqueue("Doe", 1);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("John", result);
    }

    [TestMethod]
    // Scenario: create PriorityQueue and add persons with different priorities, with the highest Priority not at index[0]
    // Expected Result: Person with highest Priority is dequeued even though not at index[0]
    // Defect(s) Found: Not all items are inspected in the loop because the loop is less than than priorityQueue.Count
    // passed after corrections were made
    public void TestPriorityQueue_VaryingPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("John", 1);
        priorityQueue.Enqueue("Doe", 2);
        priorityQueue.Enqueue("Jane", 9);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Jane", result);
    }



}