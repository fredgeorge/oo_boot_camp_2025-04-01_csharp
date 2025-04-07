/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Engine.Order;

namespace Engine.Quantities;

// Understands a specific measurement on a scale
public class IntervalQuantity : Orderable<IntervalQuantity> {
    internal const double Epsilon = 1E-10;
    protected readonly double Amount;
    protected readonly Unit Unit;

    internal IntervalQuantity(double amount, Unit unit) {
        Amount = amount;
        Unit = unit;
    }

    public bool IsBetterThan(IntervalQuantity other) => 
        this.Amount > ConvertedAmount(other);

    public override bool Equals(object? obj) =>
        this == obj || obj is IntervalQuantity other && this.Equals(other);

    private bool Equals(IntervalQuantity other) => 
        this.IsCompatible(other) &&
        Math.Abs(this.Amount - ConvertedAmount(other)) < Epsilon;

    protected double ConvertedAmount(IntervalQuantity other) {
        return this.Unit.ConvertedAmount(other.Amount, other.Unit);
    }

    public override int GetHashCode() => Unit.HashCode(Amount);

    private bool IsCompatible(IntervalQuantity other) => this.Unit.IsCompatible(other.Unit);
}