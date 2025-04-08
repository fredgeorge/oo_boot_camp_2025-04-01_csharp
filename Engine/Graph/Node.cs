/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Collections.Immutable;

namespace Engine.Graph;

// Understands its neighbors
public class Node {
    private const double Unreachable = Double.PositiveInfinity;
    private readonly List<Node> _neighbors = [];
    private readonly ImmutableList<Node> _noVisitedNodes = [];

    public Node To(Node neighbor) {
        _neighbors.Add(neighbor);
        return neighbor;
    }

    public bool CanReach(Node destination) =>
        HopCount(destination, _noVisitedNodes) != Unreachable;

    public int HopCount(Node destination) {
        var result = HopCount(destination, _noVisitedNodes);
        if (result == Unreachable) throw new ArgumentException("Destination node is not reachable");
        return (int)result;
    }

    private double HopCount(Node destination, ImmutableList<Node> visitedNodes) {
        if (this == destination) return 0.0;
        if (visitedNodes.Contains(this) || _neighbors.Count == 0) return Unreachable;            
        return _neighbors.Min(n => n.HopCount(destination, CopyWithThis(visitedNodes)) + 1);
    }

    private ImmutableList<Node> CopyWithThis(ImmutableList<Node> nodes) => [..nodes, this];
}