public class Circle : Shape
{
    private const double PI = 3.14;
    public double Radius { get; set; }
    public override double? CalculateArea()
    {
        return PI * this.Radius * this.Radius;
    }

}