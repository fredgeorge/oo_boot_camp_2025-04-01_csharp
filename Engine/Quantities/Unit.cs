/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Engine.Quantities;

// Understands a specific metric
public class Unit {
    public static readonly Unit Teaspoon = new();
    public static readonly Unit Tablespoon = new();
    public static readonly Unit Ounce = new();
    public static readonly Unit Cup = new();
    public static readonly Unit Pint = new();
    public static readonly Unit Quart = new();
    public static readonly Unit Gallon = new();
}