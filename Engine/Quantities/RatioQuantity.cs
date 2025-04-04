/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Engine.Quantities;

// Understands a specific zero-based measurement
public class RatioQuantity : IntervalQuantity {

    internal RatioQuantity(double amount, Unit unit) : base(amount, unit) { }
    public static RatioQuantity operator +(RatioQuantity left, RatioQuantity right) =>
        new(left.Amount + left.ConvertedAmount(right), left.Unit);

    public static RatioQuantity operator -(RatioQuantity q) => new(-q.Amount, q.Unit);

    public static RatioQuantity operator -(RatioQuantity left, RatioQuantity right) => left + -right;
}