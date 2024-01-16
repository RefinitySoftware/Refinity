namespace RefinityGeometry;
/// <summary>
/// Represents the geometry utility.
/// </summary>
public static class GeometryUtility
{
    /// <summary>
    /// Calculates the area of a circle.
    /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    /// <returns>The area of the circle.</returns>
    public static double AreaOfCircle(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentException("Radius cannot be negative.");
        }
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
        if (@base < 0 || height < 0)
        {
            throw new ArgumentException("Base and height cannot be negative.");
        }
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
        if (length < 0 || width < 0)
        {
            throw new ArgumentException("Length and width cannot be negative.");
        }
        return length * width;
    }

    /// <summary>
    /// Calculates the area of a square.
    /// </summary>
    /// <param name="side">The side of the square.</param>
    /// <returns>The area of the square.</returns>
    public static double AreaOfSquare(double side)
    {
        if (side < 0)
        {
            throw new ArgumentException("Side cannot be negative.");
        }
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
        if (base1 < 0 || base2 < 0 || height < 0)
        {
            throw new ArgumentException("Bases and height cannot be negative.");
        }
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
        if (@base < 0 || height < 0)
        {
            throw new ArgumentException("Base and height cannot be negative.");
        }
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
        if (diagonal1 < 0 || diagonal2 < 0)
        {
            throw new ArgumentException("Diagonals cannot be negative.");
        }
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
        if (radius < 0 || angle < 0)
        {
            throw new ArgumentException("Radius and angle cannot be negative.");
        }
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
        if (radius < 0)
        {
            throw new ArgumentException("Radius cannot be negative.");
        }
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
        if (x1 == x2)
        {
            throw new ArgumentException("The x-coordinates cannot be the same.");
        }
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
        if (x1 == x2 && y1 == y2)
        {
            throw new ArgumentException("The points cannot be the same.");
        }
        return System.Math.Sqrt(System.Math.Pow(x2 - x1, 2) + System.Math.Pow(y2 - y1, 2));
    }

    /// <summary>
    /// Calculates the perimeter of a square.
    /// </summary>
    /// <param name="side">The length of a side of the square.</param>
    /// <returns>The perimeter of the square.</returns>
    public static double CalculateSquarePerimeter(double side)
    {
        if (side < 0)
        {
            throw new ArgumentException("Side cannot be negative.");
        }
        return 4 * side;
    }

    /// <summary>
    /// Calculates the perimeter of a rectangle.
    /// </summary>
    /// <param name="length">The length of the rectangle.</param>
    /// <param name="width">The width of the rectangle.</param>
    /// <returns>The perimeter of the rectangle.</returns>
    public static double CalculateRectanglePerimeter(double length, double width)
    {
        if (length < 0 || width < 0)
        {
            throw new ArgumentException("Length and width cannot be negative.");
        }
        return 2 * (length + width);
    }

    /// <summary>
    /// Calculates the diagonal length of a rectangle using its length and width.
    /// </summary>
    /// <param name="length">The length of the rectangle.</param>
    /// <param name="width">The width of the rectangle.</param>
    /// <returns>The diagonal length of the rectangle.</returns>
    public static double CalculateRectangleDiagonal(double length, double width)
    {
        if (length < 0 || width < 0)
        {
            throw new ArgumentException("Length and width cannot be negative.");
        }
        return System.Math.Sqrt(length * length + width * width);
    }

    /// <summary>
    /// Calculates the perimeter of a trapezoid.
    /// </summary>
    /// <param name="base1">The length of the first base of the trapezoid.</param>
    /// <param name="base2">The length of the second base of the trapezoid.</param>
    /// <param name="side1">The length of the first side of the trapezoid.</param>
    /// <param name="side2">The length of the second side of the trapezoid.</param>
    /// <returns>The perimeter of the trapezoid.</returns>
    public static double CalculateTrapezoidPerimeter(double base1, double base2, double side1, double side2)
    {
        if (base1 < 0 || base2 < 0 || side1 < 0 || side2 < 0)
        {
            throw new ArgumentException("Bases and sides cannot be negative.");
        }
        return base1 + base2 + side1 + side2;
    }

    /// <summary>
    /// Calculates the perimeter of a parallelogram.
    /// </summary>
    /// <param name="baseLength">The length of the base of the parallelogram.</param>
    /// <param name="sideLength">The length of the side of the parallelogram.</param>
    /// <returns>The perimeter of the parallelogram.</returns>
    public static double CalculateParallelogramPerimeter(double baseLength, double sideLength)
    {
        if (baseLength < 0 || sideLength < 0)
        {
            throw new ArgumentException("Base and side cannot be negative.");
        }
        return 2 * (baseLength + sideLength);
    }

    /// <summary>
    /// Calculates the perimeter of a rhombus given the length of its side.
    /// </summary>
    /// <param name="side">The length of the side of the rhombus.</param>
    /// <returns>The perimeter of the rhombus.</returns>
    public static double CalculateRhombusPerimeter(double side)
    {
        if (side < 0)
        {
            throw new ArgumentException("Side cannot be negative.");
        }
        return 4 * side;
    }

    /// <summary>
    /// Calculates the perimeter of an isosceles trapezoid.
    /// </summary>
    /// <param name="base1">The length of the first base.</param>
    /// <param name="base2">The length of the second base.</param>
    /// <param name="side">The length of the side.</param>
    /// <returns>The perimeter of the isosceles trapezoid.</returns>
    public static double CalculateIsoscelesTrapezoidPerimeter(double base1, double base2, double side)
    {
        if (base1 < 0 || base2 < 0 || side < 0)
        {
            throw new ArgumentException("Bases and side cannot be negative.");
        }
        return base1 + base2 + 2 * side;
    }

    /// <summary>
    /// Calculates the length of a side of an isosceles trapezoid given the lengths of its bases and height.
    /// </summary>
    /// <param name="base1">The length of the first base of the trapezoid.</param>
    /// <param name="base2">The length of the second base of the trapezoid.</param>
    /// <param name="height">The height of the trapezoid.</param>
    /// <returns>The length of the side of the trapezoid.</returns>
    public static double CalculateIsoscelesTrapezoidSide(double base1, double base2, double height)
    {
        if (base1 < 0 || base2 < 0 || height < 0)
        {
            throw new ArgumentException("Bases and height cannot be negative.");
        }
        double halfBaseDifference = (base1 - base2) / 2;
        if (halfBaseDifference < 0)
        {
            throw new ArgumentException("The difference between the bases cannot be negative.");
        }
        return System.Math.Sqrt(halfBaseDifference * halfBaseDifference + height * height);
    }

    /// <summary>
    /// Calculates the perimeter of a right trapezoid.
    /// </summary>
    /// <param name="base1">The length of the first base.</param>
    /// <param name="base2">The length of the second base.</param>
    /// <param name="height">The height of the trapezoid.</param>
    /// <param name="side">The length of the side.</param>
    /// <returns>The perimeter of the right trapezoid.</returns>
    public static double CalculateRightTrapezoidPerimeter(double base1, double base2, double height, double side)
    {
        if (base1 < 0 || base2 < 0 || height < 0 || side < 0)
        {
            throw new ArgumentException("Bases, height, and side cannot be negative.");
        }
        return base1 + base2 + height + side;
    }

    /// <summary>
    /// Calculates the diagonal of a right trapezoid.
    /// </summary>
    /// <param name="base1">The length of the first base of the trapezoid.</param>
    /// <param name="base2">The length of the second base of the trapezoid.</param>
    /// <param name="height">The height of the trapezoid.</param>
    /// <param name="side">The length of the side of the trapezoid.</param>
    /// <returns>The diagonal of the right trapezoid.</returns>
    public static double CalculateRightTrapezoidDiagonal(double base1, double base2, double height, double side)
    {
        if (base1 < 0 || base2 < 0 || height < 0 || side < 0)
        {
            throw new ArgumentException("Bases, height, and side cannot be negative.");
        }
        double halfBaseDifference = (base1 - base2) / 2;
        if (halfBaseDifference < 0)
        {
            throw new ArgumentException("The difference between the bases cannot be negative.");
        }
        return System.Math.Sqrt(halfBaseDifference * halfBaseDifference + height * height + side * side);
    }
}
