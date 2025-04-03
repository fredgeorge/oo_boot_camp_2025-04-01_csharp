/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System;
using System.Collections.Generic;
using Engine.Quantities;
using Xunit;

namespace Engine.Tests.Unit;

// Ensures Quantities work as intended
public class QuantityTest {
    
    [Fact]
    public void EqualityOfLikeUnits() {
        Assert.Equal(8.0.Tablespoons(), 8.0.Tablespoons());
        Assert.NotEqual(8.Tablespoons(), 8.Pints());
        Assert.NotEqual(8.Tablespoons(), new object());
#pragma warning disable xUnit2000
        Assert.NotEqual(8.Tablespoons(), null);
#pragma warning restore xUnit2000
    }

    [Fact]
    public void EqualityOfDifferentUnits() {
        Assert.NotEqual(8.0.Tablespoons(), 8.0.Pints());
        Assert.Equal(8.0.Tablespoons(), 0.5.Cups());
        Assert.Equal(768.Teaspoons(), 1.Gallons());
        Assert.Equal(18.Inches(), 0.5.Yards());
        Assert.Equal(1.Miles(), (12 * 5280).Inches());
        Assert.Equal(1.5.Leagues(), 36.Furlongs());
        Assert.Equal(22.Fathoms(), 2.Chains());
    }

    [Fact]
    public void Set() {
        Assert.Single(new HashSet<Quantity> { 8.Tablespoons(), 8.Tablespoons() });
        Assert.Contains(8.Tablespoons(), new HashSet<Quantity> { 8.Tablespoons() });
    }

    [Fact]
    public void Hash() {
        Assert.Equal(8.Tablespoons().GetHashCode(), 8.Tablespoons().GetHashCode());
        Assert.Equal(8.0.Tablespoons().GetHashCode(), 0.5.Cups().GetHashCode());
        Assert.Equal(18.Inches().GetHashCode(), 0.5.Yards().GetHashCode());
        Assert.Equal(6.Inches().GetHashCode(), (0.5.Yards() - 1.Feet()).GetHashCode());
    }

    [Fact]
    public void Arithmetic() {
        Assert.Equal(0.5.Quarts(), 6.Tablespoons() + 13.Ounces());
        Assert.Equal((-6).Tablespoons(), -6.Tablespoons());
        Assert.Equal(-0.5.Pints(), 10.Tablespoons() - 13.Ounces());
        Assert.Equal(6.Inches(), 0.5.Yards() - 1.Feet());
    }

    [Fact]
    public void CrossUnitEquality() {
        Assert.NotEqual(1.Inches(), 1.Teaspoons());
        Assert.NotEqual(4.Ounces(), 2.Feet());
    }

    [Fact]
    public void CrossUnitArithmetic() {
        Assert.Throws<ArgumentException>(() => 3.Yards() - 4.Tablespoons());
    }
}