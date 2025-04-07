/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Engine.Graph;

// Understands its neighbors
public class Node {
    private const int Unreachable = -1;
    private readonly List<Node> _neighbors = [];

    public Node To(Node neighbor) {
        _neighbors.Add(neighbor);
        return neighbor;
    }

    public bool CanReach(Node destination) =>
        CanReach(destination, NoVisitedNodes);

    public int HopCount(Node destination) {
        var result = HopCount(destination, NoVisitedNodes);
        if (result == Unreachable) throw new ArgumentException("Destination node is not reachable");
        return result;
    }

    private bool CanReach(Node destination, List<Node> visitedNodes) {
        if (this == destination) return true;
        if (visitedNodes.Contains(this)) return false;
        visitedNodes.Add(this);
        foreach (var n in _neighbors)
            if (n.CanReach(destination, visitedNodes)) return true;

        return false;
    }

    private int HopCount(Node destination, List<Node> visitedNodes) {
        if (this == destination) return 0;
        if (visitedNodes.Contains(this)) return Unreachable;
        visitedNodes.Add(this);
        foreach (var n in _neighbors) {
            var neighborHopCoount = n.HopCount(destination, visitedNodes);
            if (neighborHopCoount != Unreachable) return neighborHopCoount + 1;
        }

        return Unreachable;
    }

    private List<Node> NoVisitedNodes => [];
}