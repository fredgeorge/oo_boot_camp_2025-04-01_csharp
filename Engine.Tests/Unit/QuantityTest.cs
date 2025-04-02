/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Engine.Quantities;
using Xunit;
using static Engine.Quantities.Unit;

namespace Engine.Tests.Unit;

// Ensures Quantities work as intended
public class QuantityTest {
    
    [Fact]
    public void EqualityOfLikeUnits() {
        Assert.Equal(new Quantity(8.0, Tablespoon), new Quantity(8.0, Tablespoon));
        Assert.NotEqual(new Quantity(8, Tablespoon), new Quantity(6.0, Tablespoon));
        Assert.NotEqual(new Quantity(8, Tablespoon), new object());
#pragma warning disable xUnit2000
        Assert.NotEqual(new Quantity(8, Tablespoon), null);
#pragma warning restore xUnit2000
    }

    [Fact]
    public void EqualityOfDifferentUnits() {
        Assert.NotEqual(new Quantity(8.0, Tablespoon), new Quantity(8.0, Pint));
    }
}