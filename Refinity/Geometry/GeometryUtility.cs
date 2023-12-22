namespace Refinity.Geometry;
 
public static class GeometryUtility
{
    /// <summary>
    /// Calculates the area of a circle.
     /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    /// <returns>The area of the circle.</returns>
    public static double AreaOfCircle(double radius)
    {
        return System.Math.PI * System.Math.Pow(radius, 2);
    }

    /// <summary>
    /// Calculates the area of a triangle.
    /// </summary>
    /// <param name="base">The base of the triangle.</param>
    /// <param name="height">The height of the triangle.</param>
    /// <returns>The area of the triangle.</returns>
    public static double AreaOfTriangle(double @base, double height)
    {
        return @base * height / 2;
    }

    /// <summary>
    /// Calculates the area of a rectangle.
    /// </summary>
    /// <param name="length">The length of the rectangle.</param>
    /// <param name="width">The width of the rectangle.</param>
    /// <returns>The area of the rectangle.</returns>
    public static double AreaOfRectangle(double length, double width)
    {
        return length * width;
    }

    /// <summary>
    /// Calculates the area of a square.
    /// </summary>
    /// <param name="side">The side of the square.</param>
    /// <returns>The area of the square.</returns>
    public static double AreaOfSquare(double side)
    {
        return System.Math.Pow(side, 2);
    }

    /// <summary>
    /// Calculates the area of a trapezoid.
    /// </summary>
    /// <param name="base1">The first base of the trapezoid.</param>
    /// <param name="base2">The second base of the trapezoid.</param>
    /// <param name="height">The height of the trapezoid.</param>
    /// <returns>The area of the trapezoid.</returns>
    public static double AreaOfTrapezoid(double base1, double base2, double height)
    {
        return (base1 + base2) * height / 2;
    }

    /// <summary>
    /// Calculates the area of a parallelogram.
    /// </summary>
    /// <param name="base">The base of the parallelogram.</param>
    /// <param name="height">The height of the parallelogram.</param>
    /// <returns>The area of the parallelogram.</returns>
    public static double AreaOfParallelogram(double @base, double height)
    {
        return @base * height;
    }

    /// <summary>
    /// Calculates the area of a rhombus.
    /// </summary>
    /// <param name="diagonal1">The first diagonal of the rhombus.</param>
    /// <param name="diagonal2">The second diagonal of the rhombus.</param>
    /// <returns>The area of the rhombus.</returns>
    public static double AreaOfRhombus(double diagonal1, double diagonal2)
    {
        return diagonal1 * diagonal2 / 2;
    }

    /// <summary>
    /// Calculates the area of a sector.
    /// </summary>
    /// <param name="radius">The radius of the sector.</param>
    /// <param name="angle">The angle of the sector.</param>
    /// <returns>The area of the sector.</returns>
    public static double AreaOfSector(double radius, double angle)
    {
        return System.Math.PI * System.Math.Pow(radius, 2) * angle / 360;
    }

    /// <summary>
    /// Converts Cartesian coordinates to cartesian coordinates.
    /// </summary>
    /// <param name="radius">The radius.</param>
    /// <param name="angle">The angle.</param>
    /// <returns></returns>
    public static CoordinateModel ToCartesianCoordinates(double radius, double angle)
    {
        return new CoordinateModel
        {
            X = radius * System.Math.Cos(angle),
            Y = radius * System.Math.Sin(angle)
        };
    }

    /// <summary>
    /// Converts Cartesian coordinates to polar coordinates.
    /// </summary>
    /// <param name="x">The x-coordinate.</param>
    /// <param name="y">The y-coordinate.</param>
    /// <returns></returns>
    public static CoordinateModel ToPolarCoordinates(double x, double y)
    {
        return new CoordinateModel
        {
            X = System.Math.Sqrt(System.Math.Pow(x, 2) + System.Math.Pow(y, 2)),
            Y = System.Math.Atan(y / x)
        };
    }

    /// <summary>
    /// Calculates the slope between two points on a Cartesian plane.
    /// </summary>
    /// <param name="x1">The x-coordinate of the first point.</param>
    /// <param name="y1">The y-coordinate of the first point.</param>
    /// <param name="x2">The x-coordinate of the second point.</param>
    /// <param name="y2">The y-coordinate of the second point.</param>
    /// <returns>The slope between the two points.</returns>
    public static double CalculateSlope(double x1, double y1, double x2, double y2)
    {
        return (y2 - y1) / (x2 - x1);
    }

    /// <summary>
    /// Calculates the distance between two points in a two-dimensional space.
    /// </summary>
    /// <param name="x1">The x-coordinate of the first point.</param>
    /// <param name="y1">The y-coordinate of the first point.</param>
    /// <param name="x2">The x-coordinate of the second point.</param>
    /// <param name="y2">The y-coordinate of the second point.</param>
    /// <returns>The distance between the two points.</returns>
    public static double CalculateDistance(double x1, double y1, double x2, double y2)
    {
        return System.Math.Sqrt(System.Math.Pow(x2 - x1, 2) + System.Math.Pow(y2 - y1, 2));
    }
}
