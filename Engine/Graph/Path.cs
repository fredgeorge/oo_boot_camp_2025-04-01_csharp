/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Engine.Graph;

// Understands a specific route from one Node to another
public class Path {
    private readonly List<Link> _links = [];
    
    internal Path() {}
    
    public int HopCount() => _links.Count;

    public double Cost() => Link.TotalCost(_links);

    internal Path Prepend(Link link) {
        _links.Add(link);
        return this;
    }
}