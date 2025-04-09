/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Collections.Immutable;
using static Engine.Graph.Path;

namespace Engine.Graph;

// Understands its neighbors
public class Node {
    private const double Unreachable = Double.PositiveInfinity;
    private readonly List<Link> _links = [];
    private readonly ImmutableList<Node> _noVisitedNodes = [];

    public bool CanReach(Node destination) =>
        Path(destination, _noVisitedNodes, LeastCost) != None;

    public int HopCount(Node destination) => (int)Cost(destination, Link.FewestHops);

    public double Cost(Node destination) => Path(destination).Cost();

    public Path Path(Node destination) {
        var result = Path(destination, _noVisitedNodes, LeastCost);
        if (result == None) throw new ArgumentException("Destination node is not reachable");
        return result;
    }

    internal Path Path(Node destination, ImmutableList<Node> visitedNodes, PathStrategy strategy) {
        if (this == destination) return new ActualPath();
        if (visitedNodes.Contains(this)) return None;
        return _links
                   .Select(link => link.Path(destination, CopyWithThis(visitedNodes), strategy))
                   .MinBy(strategy.Invoke)
               ?? None;
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