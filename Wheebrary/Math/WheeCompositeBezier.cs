using System.Collections.Generic;

using Wheebrary.Toolbox;

namespace Wheebrary.Math
{
    public class WheeCompositeBezier
    {
        public List<WheeBezier> Points { get; private set; }

        public WheeCompositeBezier(List<WheeBezier> points)
        {
            SetPoints(points);
        }

        public void SetPoints(List<WheeBezier> points)
        {
            Points = points;
        }

        public void SetPoint(int index, WheeBezier point)
        {
            Points[index] = point;
        }

        public void AddPoint(WheeBezier point)
        {
            Points.Add(point);
        }

        public WheePoint GetPointF(float t)
        {
            t = MathExtensions.Clamp(t, 0, Points.Count - 1);
            int a = (int)System.Math.Floor(t);
            int b = (int)System.Math.Ceiling(t);
            return Points[a].GetPoint(Points[b], t - a);
        }
    }
}
