using Figure;
using System;
using Xunit;

namespace shapes.XUnitTests
{
    public class FigureUnitTest
    {
        [Fact]
        public void CircleСonstructor_Radius_Test()
        {
            //>0
            double testRadius = 8.1;

            Circle circle = new Circle(testRadius);

            double radiusTest = circle.GetRadius();
            var typeFigureTest = circle.GetTypeFigure();

            Assert.Equal(testRadius, radiusTest);
            Assert.Equal(TypeFigures.CIRCLE, typeFigureTest);

            //=0
            testRadius = 0;

            Assert.Throws<Exception>(() => new Circle(testRadius));

            //<0
            testRadius = -10;

            Assert.Throws<Exception>(() => new Circle(testRadius));
        }

        [Fact]
        public void CircleСonstructor_CopyСonstructor_Test()
        {
            double testRadius = 8.1;

            Circle circle = new Circle(new Circle(testRadius));

            double radiusTest = circle.GetRadius();
            var typeFigureTest = circle.GetTypeFigure();

            Assert.Equal(testRadius, radiusTest);
            Assert.Equal(TypeFigures.CIRCLE, typeFigureTest);
        }

        [Fact]
        public void Circle_SetRadius_Test()
        {
            double radius = 1;

            Circle circle = new Circle(10);
            circle.SetRadius(radius);

            Assert.Equal(radius, circle.GetRadius());

            radius = -1;

            Assert.Throws<Exception>(() => circle.SetRadius(radius));
        }

        [Fact]
        public void Circle_GetSquare_Test()
        {
            double radius = 5;

            Circle circle = new Circle(radius);

            Assert.Equal(Math.PI * Math.Pow(radius, 2), circle.GetSquare());
        }

        [Fact]
        public void TriangleСonstructor_sideA_sideB_sideC_Test()
        {
            // Обычный треугольник
            double sideA = 10;
            double sideB = 5;
            double sideC = 13;

            Triangle triangle = new Triangle(sideA, sideB, sideC);

            Assert.Equal(new double[] { 5, 10, 13 }, triangle.GetSides());
            Assert.Equal(TypeFigures.TRIANGLE, triangle.GetTypeFigure());

            // Прямоугольный треугольник
            sideA = 4;
            sideB = 5;
            sideC = 3;

            triangle = new Triangle(sideA, sideB, sideC);

            Assert.Equal(new double[] { 3, 4, 5 }, triangle.GetSides());
            Assert.Equal(TypeFigures.RECTANGULAR_TRIANGLE, triangle.GetTypeFigure());

            // Одна сторона отрицательная
            sideA = -4;
            sideB = 5;
            sideC = 3;

            Assert.Throws<Exception>(() => new Triangle(sideA, sideB, sideC));

            // Три линии не образуют треугольник
            sideA = 10;
            sideB = 5;
            sideC = 3;

            Assert.Throws<Exception>(() => new Triangle(sideA, sideB, sideC));
        }

        [Fact]
        public void TriangleСonstructor_sideABC_Test()
        {
            // Обычный треугольник
            double[] sideABC = { 10, 5, 13 };

            Triangle triangle = new Triangle(sideABC);

            Assert.Equal(sideABC, triangle.GetSides());
            Assert.Equal(TypeFigures.TRIANGLE, triangle.GetTypeFigure());

            // Прямоугольный треугольник
            sideABC = new double[] { 4, 5, 3 };

            triangle = new Triangle(sideABC);

            Assert.Equal(sideABC, triangle.GetSides());
            Assert.Equal(TypeFigures.RECTANGULAR_TRIANGLE, triangle.GetTypeFigure());

            // Одна сторона отрицательная
            sideABC = new double[] { -4, 5, 3 };

            Assert.Throws<Exception>(() => new Triangle(sideABC));

            // Три линии не образуют треугольник
            sideABC = new double[] { 10, 5, 3 };

            Assert.Throws<Exception>(() => new Triangle(sideABC));

            // Два отрезка
            sideABC = new double[] { 10, 5 };

            Assert.Throws<Exception>(() => new Triangle(sideABC));

            // Четыре отрезка
            sideABC = new double[] { 10, 5, 3, 4 };

            Assert.Throws<Exception>(() => new Triangle(sideABC));
        }

        [Fact]
        public void TriangleСonstructor_CopyСonstructor_Test()
        {
            // Обычный треугольник
            double[] sideABC = { 5, 10, 13 };

            Triangle copyTriangle = new Triangle(sideABC);

            Triangle triangle = new Triangle(copyTriangle);

            Assert.Equal(sideABC, triangle.GetSides());
            Assert.Equal(TypeFigures.TRIANGLE, triangle.GetTypeFigure());

            // Прямоугольный треугольник
            sideABC = new double[] { 3, 4, 5 };

            copyTriangle = new Triangle(sideABC);

            triangle = new Triangle(copyTriangle);

            Assert.Equal(sideABC, triangle.GetSides());
            Assert.Equal(TypeFigures.RECTANGULAR_TRIANGLE, triangle.GetTypeFigure());
        }

        [Fact]
        public void TriangleСonstructor_SetSides_Test()
        {
            // Обычный треугольник
            double[] sideABC = { 2, 3, 2 };

            Triangle triangle = new Triangle(sideABC);

            triangle.SetSides(5, 10, 13);

            Assert.Equal(new double[] { 5, 10, 13 }, triangle.GetSides());
            Assert.Equal(TypeFigures.TRIANGLE, triangle.GetTypeFigure());

            // Прямоугольный треугольник
            triangle.SetSides(3, 4, 5);

            Assert.Equal(new double[] { 3, 4, 5 }, triangle.GetSides());
            Assert.Equal(TypeFigures.RECTANGULAR_TRIANGLE, triangle.GetTypeFigure());

            // Одна сторона отрицательная
            Assert.Throws<Exception>(() => triangle.SetSides(-4, 5, 3));

            // Три линии не образуют треугольник
            Assert.Throws<Exception>(() => triangle.SetSides(10, 5, 3));
        }

        [Fact]
        public void TriangleСonstructor_GetSquare_Test()
        {
            Triangle triangle = new Triangle(5, 10, 13);

            Assert.Equal(22.449944, Math.Round(triangle.GetSquare(), 6));
        }
    }
}
