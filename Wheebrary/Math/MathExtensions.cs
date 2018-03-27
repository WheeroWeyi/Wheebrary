namespace Wheebrary.Math
{
    public static class MathExtensions
    {
        public static float ClampMe(this float f, float min, float max)
        {
            return Clamp(f, min, max);
        }

        public static float ClampMeMin(this float f, float min)
        {
            return ClampMin(f, min);
        }

        public static float ClampMeMax(this float f, float max)
        {
            return ClampMax(f, max);
        }

        public static float Clamp(float value, float min, float max)
        {
            if (value < min) value = min;
            if (value > max) value = max;
            return value;
        }

        public static float ClampMin(float value, float min)
        {
            return value < min ? min : value;
        }

        public static float ClampMax(float value, float max)
        {
            return value > max ? max : value;
        }

        public static WheePoint Interpolate(WheePoint p1, WheePoint p2, float t)
        {
            return new WheePoint(p1.X + (p2.X - p1.X) * t, p1.Y + (p2.Y - p1.Y) * t);
        }
    }
}
