/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Engine.Graph;

// Understands a specific route from one Node to another
public abstract class Path {
    
    public abstract int HopCount();

    public abstract double Cost();

    internal virtual Path Prepend(Link link) => this;
}

internal class ActualPath : Path {
    private readonly List<Link> _links = [];

    public override int HopCount() => _links.Count;

    public override double Cost() => Link.TotalCost(_links);

    internal override Path Prepend(Link link) {
        _links.Add(link);
        return this;
    }
}