using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    // Insert a new node into the BST
    public void Insert(int value)
    {
        if (_root is null)
            _root = new Node(value);
        else
            _root.Insert(value);
    }

    // Check if tree contains value
    public bool Contains(int value)
    {
        return _root?.Contains(value) ?? false;
    }

    // Generic enumerator
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
            yield return number;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Forward traversal (smallest to largest)
    private void TraverseForward(Node? node, List<int> values)
    {
        if (node == null) return;
        TraverseForward(node.Left, values);
        values.Add(node.Data);
        TraverseForward(node.Right, values);
    }

    // Reverse traversal (largest to smallest)
    public IEnumerable<int> Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
            yield return number;
    }

    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node == null) return;
        TraverseBackward(node.Right, values);
        values.Add(node.Data);
        TraverseBackward(node.Left, values);
    }

    // Get tree height
    public int GetHeight()
    {
        return _root?.GetHeight() ?? 0;
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}

// Helper extension to print IEnumerable<int>
public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable<int> array)
    {
        return "<IEnumerable>{" + string.Join(", ", array) + "}";
    }
}
