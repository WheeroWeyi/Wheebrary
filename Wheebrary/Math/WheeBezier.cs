using System;
using System.Drawing;

namespace Wheebrary.Math
{
    public class WheeBezier
    {
        public WheePoint P { get; private set; }
        public WheePoint T1 { get; private set; }
        public WheePoint T2 { get; private set; }
        public bool LockT { get; private set; } = true;

        public WheeBezier(WheePoint p, WheePoint t1, WheePoint t2)
        {
            if (p == null) p = new WheePoint(0, 0);
            if (t1 == null) t1 = new WheePoint(0, 0);
            if (t2 == null) t2 = new WheePoint(0, 0);
            SetPoints(p, t1, t2);
        }
        public WheeBezier(Point p, Point t1, Point t2)
            : this(WheePoint.Parse(p), WheePoint.Parse(t1), WheePoint.Parse(t2)) { }

        public void SetPoints(WheePoint p, WheePoint t1, WheePoint t2)
        {
            P = p;
            T1 = t1;
            T2 = t2;
        }

        public void SetP(WheePoint p)
        {
            P = p;
        }

        public void SetP(PointF p)
        {
            SetP(new WheePoint(p.X, p.Y));
        }

        public void SetT1(WheePoint t1)
        {
            T1 = t1;
            if (LockT)
            {
                T2 = P.Substract(t1.Substract(P));
            }
        }

        public void SetT1(PointF t1)
        {
            SetT1(new WheePoint(t1.X, t1.Y));
        }

        public void SetT2(WheePoint t2)
        {
            T2 = t2;
            if (LockT)
            {
                T2 = P.Substract(t2.Substract(P));
            }
        }

        public void SetT2(PointF t2)
        {
            SetT2(new WheePoint(t2.X, t2.Y));
        }

        public void Move(WheePoint position)
        {
            WheePoint offset = position.Substract(P);
            P = position;
            T1 = T1.Add(offset);
            T2 = T2.Add(offset);
        }

        public void Offset(WheePoint offset)
        {
            P = P.Add(offset);
            T1 = T1.Add(offset);
            T2 = T2.Add(offset);
        }

        public WheePoint[] GetPointFs()
        {
            return new WheePoint[] { P, T1, T2};
        }

        public WheePoint[] GetPoints()
        {
            return new WheePoint[]
            {
                new WheePoint((int)P.X, (int)P.Y),
                new WheePoint((int)T1.X, (int)T1.Y),
                new WheePoint((int)T2.X, (int)T2.Y),
            };
        }

        public WheePoint GetPointF(WheeBezier bezier, float t)
        {
            t = MathExtensions.Clamp(t, 0, 1);
            WheePoint t1 = MathExtensions.Interpolate(P, T2, t);
            WheePoint t2 = MathExtensions.Interpolate(bezier.T1, bezier.P, t);
            return MathExtensions.Interpolate(t1, t2, t);
        }

        public WheePoint GetPoint(WheeBezier bezier, float t)
        {
            WheePoint pointF = GetPointF(bezier, t);
            return new WheePoint((int)pointF.X, (int)pointF.Y);
        }
    }
}
