/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Collections.Generic;
using Engine.Probability;
using Xunit;

namespace Engine.Tests.Unit;

// Ensures Chance works correctly
public class ChanceTest {
    
    [Fact]
    public void Equality() {
        Assert.Equal(new Chance(0.75), new Chance(0.75));
        Assert.NotEqual(new Chance(0.75), new Chance(0.25));
        Assert.NotEqual(new Chance(0.75), new object());
#pragma warning disable xUnit2000
        Assert.NotEqual(new Chance(0.75), null);
#pragma warning restore xUnit2000
    }

    [Fact]
    public void Set() {
        Assert.Single(new HashSet<Chance> { new(0.75), new(0.75) });
        Assert.Contains(new Chance(0.75), new HashSet<Chance> { new(0.75) });
    }

    [Fact]
    public void Hash() {
        Assert.Equal(new Chance(0.75).GetHashCode(), new Chance(0.75).GetHashCode());
    }

}