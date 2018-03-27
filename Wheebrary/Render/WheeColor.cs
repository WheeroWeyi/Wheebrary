using System.Drawing;
using Wheebrary.Math;

namespace Wheebrary.Render
{
    public class WheeColor
    {
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }
        public float A { get; private set; }

        public static readonly WheeColor White = new WheeColor(255, 255, 255);
        public static readonly WheeColor Red = new WheeColor(255, 0, 0);
        public static readonly WheeColor Yellow = new WheeColor(255, 255, 0);
        public static readonly WheeColor Orange = new WheeColor(255, 128, 0);
        public static readonly WheeColor Green = new WheeColor(0, 255, 0);
        public static readonly WheeColor Cyan = new WheeColor(0, 255, 255);
        public static readonly WheeColor Blue = new WheeColor(0, 0, 255);
        public static readonly WheeColor Magenta = new WheeColor(255, 0, 255);
        public static readonly WheeColor Black = new WheeColor(0, 0, 0);

        public WheeColor(int r, int g, int b, float a)
        {
            r = (int)MathExtensions.Clamp(r, 0, 255);
            g = (int)MathExtensions.Clamp(g, 0, 255);
            b = (int)MathExtensions.Clamp(b, 0, 255);
            a = MathExtensions.Clamp(a, 0, 1);
        }
        public WheeColor(int r, int g, int b)
            : this(r, g, b, 1) { }

        public static WheeColor Parse(Color color)
        {
            return new WheeColor(color.R, color.G, color.B, color.A);
        }

        public Color ToColor()
        {
            return Color.FromArgb((int)(A * 255), R, G, B); 
        }

        public override string ToString()
        {
            return "RGBA: " + R.ToString() + ", " + G.ToString() + ", " + B.ToString() + ", " + A.ToString();
        }
    }
}
