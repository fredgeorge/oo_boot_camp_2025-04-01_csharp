/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Xml.Serialization;

namespace Engine.Order;

// Understands a sequencing of elements
public interface Orderable<T> {
    bool IsBetterThan(T other);
}

public static class OrderableExtensions {
    public static T Best<T>(this List<T> candidates) where T : Orderable<T> =>
        candidates.Aggregate(candidates.First(), (champion, challenger) => 
            challenger.IsBetterThan(champion) ? challenger : champion);
}