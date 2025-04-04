/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Runtime.CompilerServices;

namespace Engine.Quantities;

// Understands a specific measurement
public class Quantity {
    private readonly double _amount;
    private readonly Unit _unit;
    
    internal Quantity(double amount, Unit unit) {
        _amount = amount;
        _unit = unit;
    }

    public override bool Equals(object? obj) => 
        this == obj || obj is Quantity other && this.Equals(other);

    private bool Equals(Quantity other) => this._amount == ConvertedAmount(other);

    private double ConvertedAmount(Quantity other) {
        return this._unit.ConvertedAmount(other._amount, other._unit);
    }

    public override int GetHashCode() => _unit.HashCode(_amount);

    public static Quantity operator +(Quantity left, Quantity right) => 
        new(left._amount + left.ConvertedAmount(right), left._unit);

    public static Quantity operator -(Quantity q) => new(-q._amount, q._unit);
    
    public static Quantity operator -(Quantity left, Quantity right) => left + -right;
}