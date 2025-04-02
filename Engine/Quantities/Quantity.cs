/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Engine.Quantities;

// Understands a specific measurement
public class Quantity(double value, Unit unit) {
    private readonly double _value = value;
    private readonly Unit _unit = unit;

    public override bool Equals(object? obj) => 
        this == obj || obj is Quantity other && this.Equals(other);

    private bool Equals(Quantity other) => 
        this._value == other._value && this._unit == other._unit;

    public override int GetHashCode() => HashCode.Combine(this._value, this._unit);
}