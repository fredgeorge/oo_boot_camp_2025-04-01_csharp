/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Collections.Immutable;
using static Engine.Graph.Path;

namespace Engine.Graph;

// Understands a connection from one Node to another
public class Link {
    private readonly double _cost;
    private readonly Node _target;

    internal Link(double cost, Node target) {
        _cost = cost;
        _target = target;
    }

    internal static double TotalCost(List<Link> links) =>
        links.Sum(link => link._cost);

    internal Path Path(Node destination, ImmutableList<Node> visitedNodes, PathStrategy strategy) {
        return _target.Path(destination, visitedNodes, strategy).Prepend(this);
    }
}