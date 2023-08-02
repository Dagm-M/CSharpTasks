public class Program
{
    public static void PrintShapeArea(Shape shape)
    {
        double? area = shape.CalculateArea();
        Console.WriteLine($"Shape: {shape.Name}, Area: {area}");
    }

    public static void Main()
    {
        Circle circle = new Circle { Name = "Circle", Radius = 5 };
        Rectangle rectangle = new Rectangle { Name = "Rectangle", Width = 4, Height = 6 };
        Triangle triangle = new Triangle { Name = "Triangle", Base = 3, Height = 4 };

        PrintShapeArea(circle);
        PrintShapeArea(rectangle);
        PrintShapeArea(triangle);
    }
}
