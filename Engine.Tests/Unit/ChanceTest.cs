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
    private static readonly Chance Impossible = 0.Chance();
    private static readonly Chance Unlikely = 0.25.Chance();
    private static readonly Chance EquallyLikely = 0.5.Chance();
    private static readonly Chance Likely = 0.75.Chance();
    private static readonly Chance Certain = 1.Chance();
    
    [Fact]
    public void Equality() {
        Assert.Equal(0.75.Chance(), Likely);
        Assert.NotEqual(Likely, Unlikely);
        Assert.NotEqual(Likely, new object());
#pragma warning disable xUnit2000
        Assert.NotEqual(Likely, null);
#pragma warning restore xUnit2000
    }

    [Fact]
    public void Set() {
        Assert.Single(new HashSet<Chance> { Likely, 0.75.Chance() });
        Assert.Contains(0.75.Chance(), new HashSet<Chance> { Likely });
    }

    [Fact]
    public void Hash() {
        Assert.Equal(0.75.Chance().GetHashCode(), Likely.GetHashCode());
    }

}