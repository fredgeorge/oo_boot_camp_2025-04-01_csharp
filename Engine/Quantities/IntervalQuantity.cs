/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Runtime.CompilerServices;

namespace Engine.Quantities;

// Understands a specific measurement
public class IntervalQuantity {
    internal const double Epsilon = 1E-10;
    private readonly double _amount;
    private readonly Unit _unit;

    internal IntervalQuantity(double amount, Unit unit) {
        _amount = amount;
        _unit = unit;
    }

    public override bool Equals(object? obj) =>
        this == obj || obj is IntervalQuantity other && this.Equals(other);

    private bool Equals(IntervalQuantity other) => 
        this.IsCompatible(other) &&
        Math.Abs(this._amount - ConvertedAmount(other)) < Epsilon;

    private double ConvertedAmount(IntervalQuantity other) {
        return this._unit.ConvertedAmount(other._amount, other._unit);
    }

    public override int GetHashCode() => _unit.HashCode(_amount);

    private bool IsCompatible(IntervalQuantity other) => this._unit.IsCompatible(other._unit);
}