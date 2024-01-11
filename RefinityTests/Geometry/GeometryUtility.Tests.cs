using NUnit.Framework;
using Refinity.Geometry;
using System;

[TestFixture]
public class GeometryUtilityTests
{
    [Test]
    public void AreaOfCircle_WithPositiveRadius_ReturnsCorrectArea()
    {
        // Arrange
        double radius = 5;

        // Act
        double result = GeometryUtility.AreaOfCircle(radius);

        // Assert
        Assert.That(result, Is.EqualTo(Math.PI * 25));
    }

    [Test]
    public void AreaOfTriangle_WithPositiveBaseAndHeight_ReturnsCorrectArea()
    {
        // Arrange
        double baseLength = 10;
        double height = 5;

        // Act
        double result = GeometryUtility.AreaOfTriangle(baseLength, height);

        // Assert
        Assert.That(result, Is.EqualTo(25));
    }

    // ... Repeat the pattern for the other methods ...

    [Test]
    public void ToCartesianCoordinates_WithPositiveRadiusAndAngle_ReturnsCorrectCoordinates()
    {
        // Arrange
        double radius = 5;
        double angle = Math.PI / 4;

        // Act
        var result = GeometryUtility.ToCartesianCoordinates(radius, angle);

        // Assert
        Assert.That(result.X, Is.EqualTo(radius * Math.Cos(angle)));
        Assert.That(result.Y, Is.EqualTo(radius * Math.Sin(angle)));
    }

    // ... Add more tests as needed ...
}