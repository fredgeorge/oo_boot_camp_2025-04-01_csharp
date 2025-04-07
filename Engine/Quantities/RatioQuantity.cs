/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Engine.Order;

namespace Engine.Quantities;

// Understands a specific zero-based measurement
public class RatioQuantity : IntervalQuantity, Orderable<RatioQuantity> {

    internal RatioQuantity(double amount, Unit unit) : base(amount, unit) { }
    
    public static RatioQuantity operator +(RatioQuantity left, RatioQuantity right) =>
        new(left.Amount + left.ConvertedAmount(right), left.Unit);

    public static RatioQuantity operator -(RatioQuantity q) => new(-q.Amount, q.Unit);

    public static RatioQuantity operator -(RatioQuantity left, RatioQuantity right) => 
        left + -right;
    
    public bool IsBetterThan(RatioQuantity other) => base.IsBetterThan(other);
}