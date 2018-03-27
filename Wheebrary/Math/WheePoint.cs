using System.Drawing;

namespace Wheebrary.Math
{
    public class WheePoint
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public WheePoint Inverted
        {
            get
            {
                return new WheePoint(-X, -Y);
            }
            private set { }
        }
        public float Magnitude
        {
            get
            {
                return (float)System.Math.Sqrt(X * X + Y * Y);
            }
            private set { }
        }

        public WheePoint(float x, float y)
        {
            X = x;
            Y = y;
        }
        public WheePoint(PointF point)
            : this(point.X, point.Y) { }
        public WheePoint(Point point)
            : this(point.X, point.Y) { }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y;
        }

        public static WheePoint Parse(PointF point)
        {
            return point != null ? new WheePoint(point.X, point.Y) : null;
        }

        public WheePoint Add(WheePoint point)
        {
            return new WheePoint(X + point.X, Y + point.Y);
        }

        public WheePoint Substract(WheePoint point)
        {
            return new WheePoint(X - point.X, Y - point.Y);
        }

        public PointF ToPointF()
        {
            return new PointF(X, Y);
        }

        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }
    }
}
