
//PRESS SPACE BAR TO MAKE CAT SAD OR HAPPY

using System;
using System.Numerics;

namespace MohawkGame2D
{
   
    public class Game
    {
        bool isAngry = false;

        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("Cat Face - Press Space to Toggle Mood");
        }

        public void Update()
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                isAngry = !isAngry;
            }

            Window.ClearBackground(Color.OffWhite);

            Vector2 center = new Vector2(Window.Width / 2f, Window.Height / 2f - 10);

            Draw.LineColor = Color.Black;
            Draw.LineSize = 4f;

            // head
            Draw.FillColor = Color.Gray;
            Draw.Circle(center, 80);

            // ears
            Draw.Triangle(center + new Vector2(-50, -40),
                          center + new Vector2(-80, -110),
                          center + new Vector2(-20, -45));

            Draw.Triangle(center + new Vector2(50, -40),
                          center + new Vector2(80, -110),
                          center + new Vector2(20, -45));

            // inner ears
            Draw.FillColor = new Color(255, 200, 220);
            Draw.Triangle(center + new Vector2(-45, -50),
                          center + new Vector2(-62, -95),
                          center + new Vector2(-28, -50));

            Draw.Triangle(center + new Vector2(45, -50),
                          center + new Vector2(62, -95),
                          center + new Vector2(28, -50));

            // eyes
            Vector2 leftEye = center + new Vector2(-30, -10);
            Vector2 rightEye = center + new Vector2(30, -10);

            Draw.FillColor = Color.White;
            Draw.Circle(leftEye, 18);
            Draw.Circle(rightEye, 18);

            // pupils
            Draw.FillColor = Color.Black;
            Vector2 pupilShift = isAngry ? new Vector2(0, 2) : Vector2.Zero;
            Draw.Circle(leftEye + pupilShift, 7);
            Draw.Circle(rightEye + pupilShift, 7);

            // nose
            Draw.FillColor = new Color(255, 150, 170);
            Draw.Triangle(center + new Vector2(0, 6),
                          center + new Vector2(-8, 16),
                          center + new Vector2(8, 16));

            // whiskers
            Draw.LineSize = 3f;
            Draw.Line(leftEye + new Vector2(-10, 20), leftEye + new Vector2(-70, 26));
            Draw.Line(leftEye + new Vector2(-10, 10), leftEye + new Vector2(-70, 10));
            Draw.Line(leftEye + new Vector2(-10, 0), leftEye + new Vector2(-70, -6));

            Draw.Line(rightEye + new Vector2(10, 20), rightEye + new Vector2(70, 26));
            Draw.Line(rightEye + new Vector2(10, 10), rightEye + new Vector2(70, 10));
            Draw.Line(rightEye + new Vector2(10, 0), rightEye + new Vector2(70, -6));

            // eyebrows
            Draw.LineSize = 5f;
            if (isAngry)
            {
                Draw.Line(leftEye + new Vector2(-18, -22), leftEye + new Vector2(0, -10));
                Draw.Line(rightEye + new Vector2(18, -22), rightEye + new Vector2(0, -10));
            }
            else
            {
                Draw.Line(leftEye + new Vector2(-18, -18), leftEye + new Vector2(0, -22));
                Draw.Line(rightEye + new Vector2(18, -18), rightEye + new Vector2(0, -22));
            }

            // mouth
            Draw.LineSize = 5f;

            if (isAngry)
            {
                Vector2 m = center + new Vector2(0, 40);
                var f = ComputeArcPoints(m, 32, 18, 20, 160, 20);
                Draw.PolyLine(f);
                Draw.Line(m + new Vector2(-8, -2), m + new Vector2(8, -2));
            }
            else
            {
                Vector2 m = center + new Vector2(0, 45);
                var s = ComputeArcPoints(m, 36, 20, 200, 340, 20);
                Draw.PolyLine(s);
            }
        }

        Vector2[] ComputeArcPoints(Vector2 center, float rx, float ry, float startDeg, float endDeg, int segments)
        {
            float start = startDeg * MathF.PI / 180f;
            float end = endDeg * MathF.PI / 180f;
            float total = end - start;

            Vector2[] pts = new Vector2[segments + 1];

            for (int i = 0; i <= segments; i++)
            {
                float t = i / (float)segments;
                float ang = start + total * t;

                float x = center.X + MathF.Cos(ang) * rx;
                float y = center.Y + MathF.Sin(ang) * ry;

                pts[i] = new Vector2(x, y);
            }

            return pts;
        }
    }
}
//it did not come out how i wanted it to come out but i finsished something