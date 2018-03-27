using System.Drawing;

namespace Wheebrary.Toolbox
{
    public static class WheePaint
    {
        public static void DrawPoint(Point position, int diameter, Brush color, Graphics graphics)
        {
            graphics.FillEllipse(color, position.X - (int)(diameter * 0.5f), position.Y - (int)(diameter * 0.5f), diameter, diameter);
        }

        public static void DrawRectangle(Point position, int width, int height, Brush color, bool fill, Graphics graphics)
        {
            if (fill) graphics.FillRectangle(color, new Rectangle(position.X, position.Y, width, height));
            else graphics.DrawRectangle(new Pen(color), new Rectangle(position.X, position.Y, width, height));
        }

        public static void DrawSquare(Point position, int width, Brush color, bool fill, Graphics graphics)
        {
            DrawRectangle(position, width, width, color, fill, graphics);
        }

        public static void DrawText(string text, Point position, Point offset, Font font, Brush color, Graphics graphics)
        {
            graphics.DrawString(text, font, color, new PointF(position.X - graphics.MeasureString(text, font).Width / 2 + offset.X, position.Y + offset.Y));
        }
    }
}
