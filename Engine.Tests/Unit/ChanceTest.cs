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
        Assert.Equal(0.75.Chance(), 0.75.Chance());
        Assert.NotEqual(0.75.Chance(), 0.25.Chance());
        Assert.NotEqual(0.75.Chance(), new object());
#pragma warning disable xUnit2000
        Assert.NotEqual(0.75.Chance(), null);
#pragma warning restore xUnit2000
    }

    [Fact]
    public void Set() {
        Assert.Single(new HashSet<Chance> { 0.75.Chance(), 0.75.Chance() });
        Assert.Contains(0.75.Chance(), new HashSet<Chance> { 0.75.Chance() });
    }

    [Fact]
    public void Hash() {
        Assert.Equal(0.75.Chance().GetHashCode(), 0.75.Chance().GetHashCode());
    }

}