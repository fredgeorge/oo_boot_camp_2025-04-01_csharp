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
        HopCount(destination, NoVisitedNodes) != Unreachable;

    public int HopCount(Node destination) {
        var result = HopCount(destination, NoVisitedNodes);
        if (result == Unreachable) throw new ArgumentException("Destination node is not reachable");
        return result;
    }

    private int HopCount(Node destination, List<Node> visitedNodes) {
        if (this == destination) return 0;
        if (visitedNodes.Contains(this)) return Unreachable;
        var champion = Unreachable;
        foreach (var n in _neighbors) {
            var challenger = n.HopCount(destination, CopyWithThis(visitedNodes));
            if (challenger == Unreachable) continue;
            if (champion == Unreachable || challenger + 1 < champion) champion = challenger + 1;
        }

        return champion;
    }

    private List<Node> NoVisitedNodes => [];

    private List<Node> CopyWithThis(List<Node> nodes) => [..nodes, this];
}