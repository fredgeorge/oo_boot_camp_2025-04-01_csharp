/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System;
using System.Collections.Generic;
using Engine.Geometry;
using Engine.Order;
using Xunit;
using static Engine.Geometry.Rectangle;

namespace Engine.Tests.Unit;

// Ensures implementers of Orderable work correctly
public class OrderableTest {
    
    [Fact]
    public void LargestRectangle() {
        Assert.Equal(24.0, new List<Rectangle> {
            new(2, 3),
            new(6.0, 4.0),
            Square(3)
        }.Best().Area());
        Assert.Throws<InvalidOperationException>(() => new List<Rectangle>().Best());
    }
}