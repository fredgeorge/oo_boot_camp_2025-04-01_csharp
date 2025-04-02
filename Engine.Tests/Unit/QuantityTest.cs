/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

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
    }

    [Fact]
    public void Set() {
        Assert.Single(new HashSet<Quantity> { 8.Tablespoons(), 8.Tablespoons() });
        Assert.Contains(8.Tablespoons(), new HashSet<Quantity> { 8.Tablespoons() });
    }

    [Fact]
    public void Hash() {
        Assert.Equal(8.Tablespoons().GetHashCode(), 8.Tablespoons().GetHashCode());
    }
}