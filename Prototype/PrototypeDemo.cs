
class Point {
  public int x;
  public int y;

  public Point(int x, int y) {
    this.x = x;
    this.y = y;
  }
}

abstract class Shape
{
  protected Point start;
  protected Point end;
  protected int color;
  protected int thickness;
  protected int fillStyle;

  public Shape(Point start, Point end, int color, int thickness, int fillStyle)
  {
    this.start = start;
    this.end = end;
    this.color = color;
    this.thickness = thickness;
    this.fillStyle = fillStyle;
  }

  protected Shape(Shape shape)
  {
    this.start = shape.start;
    this.end = shape.end;
    this.color = shape.color;
    this.thickness = shape.thickness;
    this.fillStyle = shape.fillStyle;
  }

  public abstract void Draw();
    public abstract Shape Clone();

}

class Line : Shape
{
    public Line(Point start, Point end)
      : base(start, end, 0, 1, 1)
    {
    }

    protected Line(Line shape) : base(shape) 
    {

    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Line from {start.x}:{start.y} to {end.x}:{end.y}");
    }



    public override Shape Clone()
    {
        return new Line(this);
    }
}

class Rectangle : Shape
{
    public int Width;
    public int Height;
    public Rectangle(Point start, Point end, int width, int height) : base(start, end, 0, 1, 1)
    {
        Width = width;
        Height = height;
    }

    protected Rectangle(Rectangle rectangle) : base(rectangle)
    {
        Width = rectangle.Width;
        Height = rectangle.Height;  
    }

    public override void Draw()
    {
       Console.WriteLine($"Drawing Rectangle from {start.x}:{start.y} to {end.x}:{end.y} with the width {Width} & height {Height}"); 
    }

    public override Shape Clone()
    {
        return new Rectangle(this);
    }
}

public class Program
{

    public static void Main()
    {
        var drawing = new List<Shape>();
        var shape = new Line(new Point(0, 0), new Point(10, 10));
        var rShape = new Rectangle(new Point(0, 0), new Point(10, 10), 20, 30);
       
        shape.Draw();
        rShape.Draw();      
        
        drawing.Add(shape);
        
        var newShape = shape.Clone();
        var newRShape = rShape.Clone();
        
        newShape.Draw();
        newRShape.Draw();
    }
}