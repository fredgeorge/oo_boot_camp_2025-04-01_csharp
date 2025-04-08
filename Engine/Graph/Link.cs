/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Collections.Immutable;

namespace Engine.Graph;

// Understands a connection from one Node to another
public class Link {
    private readonly double _cost;
    private readonly Node _target;

    internal Link(double cost, Node target) {
        _cost = cost;
        _target = target;
    }

    internal double HopCount(Node destination, ImmutableList<Node> visitedNodes) => 
        _target.HopCount(destination, visitedNodes) + 1;
}