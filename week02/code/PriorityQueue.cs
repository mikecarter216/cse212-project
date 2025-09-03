using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.
    /// The item is always added to the back of the queue regardless of priority.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        _queue.Add(new PriorityItem(value, priority));
    }

    /// <summary>
    /// Remove and return the value with the highest priority from the queue.
    /// If multiple items have the same highest priority, the first one (FIFO) is removed.
    /// Throws InvalidOperationException if the queue is empty.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        int highIndex = 0;
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[highIndex].Priority)
            {
                highIndex = i;
            }
        }

        string value = _queue[highIndex].Value;
        _queue.RemoveAt(highIndex);
        return value;
    }

    // DO NOT MODIFY: Grader relies on this
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY: Grader relies on this
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
