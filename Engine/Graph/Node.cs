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
    private readonly List<Link> _links = [];
    private readonly ImmutableList<Node> _noVisitedNodes = [];

    public bool CanReach(Node destination) =>
        Cost(destination, _noVisitedNodes, Link.LeastCost) != Unreachable;

    public int HopCount(Node destination) => (int)Cost(destination, Link.FewestHops);

    public double Cost(Node destination) => Cost(destination, Link.LeastCost);

    public Path Path(Node destination) => Path(destination, _noVisitedNodes)
                                          ?? throw new ArgumentException("Destination node is not reachable");

    internal Path? Path(Node destination, ImmutableList<Node> visitedNodes) {
        if (this == destination) return new Path();
        if (visitedNodes.Contains(this)) return null;
        Path? champion = null;
        foreach (var link in _links) {
            var challenger = link.Path(destination, CopyWithThis(visitedNodes));
            if (challenger == null) continue;
            if (champion == null || challenger.Cost() < champion.Cost()) champion = challenger;
        }
        return champion;
    }

    private double Cost(Node destination, Link.CostStrategy strategy) {
        var result = Cost(destination, _noVisitedNodes, strategy);
        if (result == Unreachable) throw new ArgumentException("Destination node is not reachable");
        return result;
    }

    internal double Cost(Node destination, ImmutableList<Node> visitedNodes, Link.CostStrategy strategy) {
        if (this == destination) return 0.0;
        if (visitedNodes.Contains(this) || _links.Count == 0) return Unreachable;
        return _links.Min(link => link.Cost(destination, CopyWithThis(visitedNodes), strategy));
    }

    private ImmutableList<Node> CopyWithThis(ImmutableList<Node> nodes) => [..nodes, this];

    public LinkBuilder Cost(double amount) => new(_links, amount);

    public class LinkBuilder {
        private readonly List<Link> _links;
        private readonly double _amount;

        internal LinkBuilder(List<Link> links, double amount) {
            _links = links;
            _amount = amount;
        }

        public Node To(Node neighbor) {
            _links.Add(new Link(_amount, neighbor));
            return neighbor;
        }
    }
}