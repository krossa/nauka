// This file was auto-generated based on version 1.3.0 of the canonical data.

using System;
using Xunit;

public class SaddlePointsTest
{
    [Fact]
    public void Can_identify_single_saddle_point()
    {
        var matrix = new[,]
        {
             { 9, 8, 7 },
             { 5, 3, 2 },
             { 6, 6, 7 }
        };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        var expected = new[] { (1, 0) };
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Can_identify_that_empty_matrix_has_no_saddle_points()
    {
        var matrix = new int[,] { };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        Assert.Empty(actual);
    }

    [Fact]
    public void Can_identify_lack_of_saddle_points_when_there_are_none()
    {
        var matrix = new[,]
        {
             { 1, 2, 3 },
             { 3, 1, 2 },
             { 2, 3, 1 }
        };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        Assert.Empty(actual);
    }

    [Fact]
    public void Can_identify_multiple_saddle_points_in_a_column()
    {
        var matrix = new[,]
        {
             { 4, 5, 4 },
             { 3, 5, 5 },
             { 1, 5, 4 }
        };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        var expected = new[] { (0, 1), (1, 1), (2, 1) };
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Can_identify_multiple_saddle_points_in_a_row()
    {
        var matrix = new[,]
        {
             { 6, 7, 8 },
             { 5, 5, 5 },
             { 7, 5, 6 }
        };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        var expected = new[] { (1, 0), (1, 1), (1, 2) };
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Can_identify_saddle_point_in_bottom_right_corner()
    {
        var matrix = new[,]
        {
             { 8, 7, 9 },
             { 6, 7, 6 },
             { 3, 2, 5 }
        };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        var expected = new[] { (2, 2) };
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Can_identify_saddle_points_in_a_non_square_matrix()
    {
        var matrix = new[,]
        {
             { 3, 1, 3 },
             { 3, 2, 4 }
        };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        var expected = new[] { (0, 0), (0, 2) };
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Can_identify_that_saddle_points_in_a_single_column_matrix_are_those_with_the_minimum_value()
    {
        var matrix = new[,]
        {
             { 2 },
             { 1 },
             { 4 },
             { 1 }
        };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        var expected = new[] { (1, 0), (3, 0) };
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Can_identify_that_saddle_points_in_a_single_row_matrix_are_those_with_the_maximum_value()
    {
        var matrix = new[,]
        {
             { 2, 5, 3, 5 }
        };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        var expected = new[] { (0, 1), (0, 3) };
        Assert.Equal(expected, actual);
    }
}