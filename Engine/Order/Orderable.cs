/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Engine.Order;

// Understands a sequencing of elements
public interface Orderable<T> {
    bool IsBetterThan(T other);
}

public static class OrderableExtensions {
    public static T Best<T>(this List<T> candidates) where T : Orderable<T> {
        if (candidates.Count == 0) throw new InvalidOperationException("No elements specified");
        var champion = candidates[0];
        foreach (var challenger in candidates) 
            if (challenger.IsBetterThan(champion)) champion = challenger;
        return champion;
    }
}