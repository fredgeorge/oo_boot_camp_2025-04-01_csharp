/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System;
using Engine.Graph;
using Xunit;

namespace Engine.Tests.Unit;

// Ensures graph behaviors are correct
public class GraphTest {
    
    private static readonly Node A = new();
    private static readonly Node B = new();
    private static readonly Node C = new();
    private static readonly Node D = new();
    private static readonly Node E = new();
    private static readonly Node F = new();
    private static readonly Node G = new();

    static GraphTest() {
        B.Cost(5).To(A);
        B.Cost(6).To(C).Cost(7).To(D).Cost(2).To(E).Cost(3).To(B).Cost(4).To(F);
        C.Cost(1).To(D);
        C.Cost(8).To(E);
    }

    [Fact]
    public void CanReach() {
        Assert.True(A.CanReach(A));
        Assert.True(B.CanReach(A));
        Assert.True(B.CanReach(F));
        Assert.True(B.CanReach(D));
        Assert.True(C.CanReach(F));
        Assert.False(A.CanReach(B));
        Assert.False(G.CanReach(B));
        Assert.False(B.CanReach(G));
    }

    [Fact]
    public void HopCount() {
        Assert.Equal(0, A.HopCount(A));
        Assert.Equal(1, B.HopCount(A));
        Assert.Equal(1, B.HopCount(F));
        Assert.Equal(2, B.HopCount(D));
        Assert.Equal(3, C.HopCount(F));
        Assert.Throws<ArgumentException>(() => A.HopCount(B));
        Assert.Throws<ArgumentException>(() => G.HopCount(B));
        Assert.Throws<ArgumentException>(() => B.HopCount(G));
    }

    [Fact]
    public void Cost() {
        Assert.Equal(0, A.Cost(A));
        Assert.Equal(5, B.Cost(A));
        Assert.Equal(4, B.Cost(F));
        Assert.Equal(7, B.Cost(D));
        Assert.Equal(10, C.Cost(F));
        Assert.Throws<ArgumentException>(() => A.Cost(B));
        Assert.Throws<ArgumentException>(() => G.Cost(B));
        Assert.Throws<ArgumentException>(() => B.Cost(G));
    }

    [Fact]
    public void Path() {
        AssertPath(A, A, 0, 0);
        AssertPath(B, A, 1, 5);
        AssertPath(B, F, 1, 4);
        AssertPath(B, D, 2, 7);
        AssertPath(C, F, 4, 10);
        Assert.Throws<ArgumentException>(() => A.Path(B));
        Assert.Throws<ArgumentException>(() => G.Path(B));
        Assert.Throws<ArgumentException>(() => B.Path(G));
    }

    private void AssertPath(Node source, Node destination, int expectedHopCount, double expectedCost) {
        var path = source.Path(destination);
        Assert.Equal(expectedHopCount, path.HopCount());
        Assert.Equal(expectedCost, path.Cost());
    }
    
    /* Code Counts      Path()
     Classes            6
     Methods            21
     Total xLoc         36
     Avg Method         1.7
     Test loc           46
     Test%              56%
     */
}