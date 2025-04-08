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

    public int HopCount(Node destination) {
        var result = Cost(destination, _noVisitedNodes, Link.FewestHops);
        if (result == Unreachable) throw new ArgumentException("Destination node is not reachable");
        return (int)result;
    }

    public double Cost(Node destination) {
        var result = Cost(destination, _noVisitedNodes, Link.LeastCost);
        if (result == Unreachable) throw new ArgumentException("Destination node is not reachable");
        return result;
    }

    internal double Cost(Node destination, ImmutableList<Node> visitedNodes, Link.CostStrategy strategy) {
        if (this == destination) return 0.0;
        if (visitedNodes.Contains(this) || _links.Count == 0) return Unreachable;            
        return _links.Min(link => link.Cost(destination, CopyWithThis(visitedNodes), strategy));
    }

    private ImmutableList<Node> CopyWithThis(ImmutableList<Node> nodes) => [..nodes, this];

    public LinkBuilder Cost(double amount) => new LinkBuilder(_links, amount);

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