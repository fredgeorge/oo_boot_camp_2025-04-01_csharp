/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Engine.Quantities;

// Understands a specific metric
public class Unit {
    internal static readonly Unit Teaspoon = new();
    internal static readonly Unit Tablespoon = new(3, Teaspoon);
    internal static readonly Unit Ounce = new(2, Tablespoon);
    internal static readonly Unit Cup = new(8, Ounce);
    internal static readonly Unit Pint = new(2, Cup);
    internal static readonly Unit Quart = new(2, Pint);
    internal static readonly Unit Gallon = new(4, Quart);

    internal static readonly Unit Inch = new();
    internal static readonly Unit Foot = new(12, Inch);
    internal static readonly Unit Yard = new(3, Foot);
    internal static readonly Unit Fathom = new(6, Foot);
    internal static readonly Unit Chain = new(22, Yard);
    internal static readonly Unit Furlong = new(10, Chain);
    internal static readonly Unit Mile = new(8, Furlong);
    internal static readonly Unit League = new(3, Mile);

    private readonly double _baseUnitRatio;

    private Unit() {
        _baseUnitRatio = 1.0;
    }

    private Unit(double relativeRatio, Unit relativeUnit) {
        _baseUnitRatio = relativeRatio * relativeUnit._baseUnitRatio;
    }

    internal double ConvertedAmount(double otherAmount, Unit other) =>
        otherAmount * other._baseUnitRatio / this._baseUnitRatio;

    internal int HashCode(double amount) =>
        Math.Round(amount / Quantity.Epsilon * _baseUnitRatio).GetHashCode();
}

public static class QuantityConstructors {
    public static Quantity Teaspoons(this double amount) => new(amount, Unit.Teaspoon);
    public static Quantity Teaspoons(this int amount) => new(amount, Unit.Teaspoon);
    public static Quantity Tablespoons(this double amount) => new(amount, Unit.Tablespoon);
    public static Quantity Tablespoons(this int amount) => new(amount, Unit.Tablespoon);
    public static Quantity Ounces(this double amount) => new(amount, Unit.Ounce);
    public static Quantity Ounces(this int amount) => new(amount, Unit.Ounce);
    public static Quantity Cups(this double amount) => new(amount, Unit.Cup);
    public static Quantity Cups(this int amount) => new(amount, Unit.Cup);
    public static Quantity Pints(this double amount) => new(amount, Unit.Pint);
    public static Quantity Pints(this int amount) => new(amount, Unit.Pint);
    public static Quantity Quarts(this double amount) => new(amount, Unit.Quart);
    public static Quantity Quarts(this int amount) => new(amount, Unit.Quart);
    public static Quantity Gallons(this double amount) => new(amount, Unit.Gallon);
    public static Quantity Gallons(this int amount) => new(amount, Unit.Gallon);

    public static Quantity Inches(this double amount) => new(amount, Unit.Inch);
    public static Quantity Inches(this int amount) => new(amount, Unit.Inch);
    public static Quantity Feet(this double amount) => new(amount, Unit.Foot);
    public static Quantity Feet(this int amount) => new(amount, Unit.Foot);
    public static Quantity Yards(this double amount) => new(amount, Unit.Yard);
    public static Quantity Yards(this int amount) => new(amount, Unit.Yard);
    public static Quantity Fathoms(this double amount) => new(amount, Unit.Fathom);
    public static Quantity Fathoms(this int amount) => new(amount, Unit.Fathom);
    public static Quantity Chains(this double amount) => new(amount, Unit.Chain);
    public static Quantity Chains(this int amount) => new(amount, Unit.Chain);
    public static Quantity Furlongs(this double amount) => new(amount, Unit.Furlong);
    public static Quantity Furlongs(this int amount) => new(amount, Unit.Furlong);
    public static Quantity Miles(this double amount) => new(amount, Unit.Mile);
    public static Quantity Miles(this int amount) => new(amount, Unit.Mile);
    public static Quantity Leagues(this double amount) => new(amount, Unit.League);
    public static Quantity Leagues(this int amount) => new(amount, Unit.League);
}