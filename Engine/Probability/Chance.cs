/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Engine.Order;

namespace Engine.Probability;

// Understands the likelihood of something specific occurring
public class Chance : Orderable<Chance> {
    private const double CertainFraction = 1.0;
    private const double Epsilon = 1e-10;
    private readonly double _fraction;
    
    internal Chance(double likelihoodAsFraction) {
        if (likelihoodAsFraction is < 0.0 or > 1.0)
            throw new ArgumentException("Value must be between 0.0 and 1.0, inclusive.");
        _fraction = likelihoodAsFraction;
    }

    public bool IsBetterThan(Chance other) => this._fraction < other._fraction;

    public override bool Equals(object? obj) => 
        this == obj || obj is Chance other && this.Equals(other);

    private bool Equals(Chance other) => Math.Abs(this._fraction - other._fraction) < Epsilon;
    
    public override int GetHashCode() => Math.Round(_fraction/Epsilon).GetHashCode();
    
    public Chance Not() => new(CertainFraction - _fraction);

    public static Chance operator !(Chance c) => c.Not();

    public Chance And(Chance other) => new(this._fraction * other._fraction);
    
    public static Chance operator &(Chance left, Chance right) => left.And(right);

    // DeMorgan's Law: https://en.wikipedia.org/wiki/De_Morgan%27s_laws
    public static Chance operator |(Chance left, Chance right) => !(!left & !right);

    public Chance Or(Chance other) => this | other;
}

public static class ChanceExtensions {
    public static Chance Chance(this double value) => new(value);
    public static Chance Chance(this int value) => new(value);
}