using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /** "Implementor" */
    interface DrawingAPI
    {
        void DrawCircle(double x, double y, double radius);
    }

    /** "ConcreteImplementor" 1/2 */
    class DrawingAPI1 : DrawingAPI
    {
        public void DrawCircle(double x, double y, double radius)
        {
            System.Console.WriteLine("API1.circle at {0}:{1} radius {2}\n", x, y, radius);
        }
    }

    /** "ConcreteImplementor" 2/2 */
    class DrawingAPI2 : DrawingAPI
    {
        public void DrawCircle(double x, double y, double radius)
        {
            System.Console.WriteLine("API2.circle at {0}:{1} radius {2}\n", x, y, radius);
        }
    }

        /** "Abstraction" */
    interface Shape
    {
        void Draw();                             // low-level
        void ResizeByPercentage(double pct);     // high-level
    }

    /** "Refined Abstraction" */
    class CircleShape : Shape
    {
        private double x, y, radius;
        private DrawingAPI drawingAPI;

        public CircleShape(double x, double y, double radius, DrawingAPI drawingAPI)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.drawingAPI = drawingAPI;
        }

        // low-level i.e. Implementation specific
        public void Draw()
        {
            drawingAPI.DrawCircle(x, y, radius);
        }

        // high-level i.e. Abstraction specific       
        public void ResizeByPercentage(double pct)
        {
            radius *= pct;
        }
    }
}
