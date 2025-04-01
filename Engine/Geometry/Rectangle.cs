/*
 * Copyright (c) 2025 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Engine.Geometry;

// Understands a polygon with four sides at right angles
public class Rectangle {
    private readonly double _width;
    private readonly double _length;
    public Rectangle(double width, double length) {
        if (width <= 0 || length <= 0) throw new ArgumentException("width and length must be positive");
        _width = width;
        _length = length;
    }
    public double Area() => _length * _width;

    public double Perimeter() => 2 * (_width + _length);

    public bool IsSquare() => _width == _length;
}