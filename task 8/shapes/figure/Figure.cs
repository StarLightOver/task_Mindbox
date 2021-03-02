/* Задания:
 * Вычислять площадь круга по радиусу 
 * Вычислять площадь треугольника по трем сторонам
 * 
 * Дополнительно реализовать:
 * Юнит-тесты 
 * Легкость добавления других фигур (?)
 * Вычисление площади фигуры без знания типа фигуры
 * Проверку на то, является ли треугольник прямоугольным
 */

using System;

namespace Figure
{
    /// <summary> Перечисление TypeFigure. Множество типов фигур </summary>
    public enum TypeFigures
    {
        NO_FIGURE = 0,
        CIRCLE = 1,
        TRIANGLE = 2,
        RECTANGULAR_TRIANGLE = 3
    }

    /// <summary> Класс Figure. Абстрактный класс для фигур, определяет общие поля, свойства и методы </summary>
    public abstract class Figure
    {
        /************************************************************
         ****************** Блок переменных и свойств ***************
         ************************************************************/

        /// <summary> Тип фигуры </summary>
        private TypeFigures TypeFigure = TypeFigures.NO_FIGURE;

        /************************************************************
         ************************ Блок методов **********************
         ************************************************************/

        /// <summary> Получить тип фигуры </summary>
        public TypeFigures GetTypeFigure() { return TypeFigure; }

        /// <summary> Установить тип фигуры </summary>
        protected void SetTypeFigure(TypeFigures Type) { this.TypeFigure = Type; }
    }

    /// <summary> Интерфейс IFigure. Интерфейс для определения площади фигуру без знания типа фигуры </summary>
    public interface IFigure
    {
        /// <summary> Вычислить площадь фигуры </summary>
        double GetSquare();
    }

    /// <summary> Класс Circle. Класс окружности </summary>
    public class Circle : Figure, IFigure
    {
        /************************************************************
         ****************** Блок переменных и свойств ***************
         ************************************************************/
        
        /// <summary> Радиус окружности </summary>
        private double Radius;

        /************************************************************
         ************************ Блок методов **********************
         ************************************************************/
       
        /// <summary> Получить радиус окружности </summary>
        /// <returns> Радиус окружности </returns>
        public double GetRadius() { return Radius; }

        /// <summary> Вычислить площадь фигуры </summary>
        /// <param name="rad"> Радиус окружности </param>
        public void SetRadius(double rad)
        {
            if (rad > 0)
            {
                this.Radius = rad;
                SetTypeFigure(TypeFigures.CIRCLE);
            }
            else
            {
                throw new Exception("Некорректный радиус!");
            }
        }

        /// <summary> Вычислить площадь фигуры </summary>
        public double GetSquare()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        /// <summary> Конструктор для Circle </summary>
        /// <param name="rad"> Радиус окружности </param>
        public Circle(double rad)
        {
            SetRadius(rad);
        }

        /// <summary> Конструктор для Circle </summary>
        /// <param name="circle"> Другая окружность Circle </param>
        public Circle(Circle circle)
        {
            SetRadius(circle.Radius);
        }
    }

    /// <summary> Класс Triangle. Класс треугольников </summary>
    public class Triangle : Figure, IFigure
    {
        /************************************************************
         ****************** Блок переменных и свойств ***************
         ************************************************************/

        /// <summary> Массив, содержащий три стороны треугольника </summary>
        private double[] Sides;

        /************************************************************
         ************************ Блок методов **********************
         ************************************************************/

        /// <summary> Получить стороны треугольника </summary>
        /// <returns> Массив, содержащий три стороны треугольника </returns>
        public double[] GetSides() { return Sides; }

        /// <summary> Установить стороны треугольника </summary>
        /// <param name="SideA"> Первая сторона Triangle </param>
        /// <param name="SideB"> Вторая сторона Triangle </param>
        /// <param name="SideC"> Третья сторона Triangle </param>
        public void SetSides(double SideA, double SideB, double SideC)
        {
            this.Sides = new double[] { SideA, SideB, SideC };
            InitTriangle();
        }

        /// <summary> Вычислить площадь фигуры </summary>
        public double GetSquare()
        {
            double p = (Sides[0] + Sides[1] + Sides[2]) / 2;
            double temp = p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]);
            return Math.Sqrt(temp);
        }

        /// <summary> Функция, опредлеяющая являются ли треугольник прямоугольным </summary>
        /// <returns> True - является прямоугольным треугольником, False - не является прямоугольным треугольником, </returns>
        private bool IsRectangular()
        {
            if (Math.Pow(Sides[2], 2) == Math.Pow(Sides[1], 2) + Math.Pow(Sides[0], 2))
            {
                return true;
            }
            return false;
        }

        /// <summary> Функция, опредлеяющая являются ли три точки треугольником </summary>
        /// <returns> True - является треугольником, False - не является треугольником, </returns>
        private bool IsTriangle()
        {
            if (Sides[0] + Sides[1] > Sides[2])
            {
                return true;
            }
            return false;
        }

        /// <summary> Функция инициализации </summary>
        private void InitTriangle()
        {
            foreach (var side in Sides)
            {
                if (side <= 0) { throw new Exception("Некорректное значение стороны треугольника!"); };
            }

            Array.Sort(Sides);
            if (!IsTriangle())
            {
                throw new Exception("Не треугольник!");
            }
            else
            {
                SetTypeFigure(TypeFigures.TRIANGLE);
            }

            if (IsRectangular())
            {
                SetTypeFigure(TypeFigures.RECTANGULAR_TRIANGLE);
            }
        }

        /// <summary> Функция, опредлеяющая являются ли три точки треугольником </summary>
        /// <param name="SideA"> Первая сторона Triangle </param>
        /// <param name="SideB"> Вторая сторона Triangle </param>
        /// <param name="SideC"> Третья сторона Triangle </param>
        public Triangle(double SideA, double SideB, double SideC)
        {
            SetSides(SideA, SideB, SideC);
        }

        /// <summary> Функция, опредлеяющая являются ли три точки треугольником </summary>
        /// <param name="SideABC"> Масиив сторон Triangle </param>
        public Triangle(double[] SideABC)
        {
            if (SideABC.Length == 3)
            {
                this.Sides = SideABC;
            }
            else
            {
                throw new Exception("Некорректное количество сторон!");
            }

            InitTriangle();
        }

        /// <summary> Функция, опредлеяющая являются ли три точки треугольником </summary>
        /// <param name="SideABC"> Другой треугольник Triangle </param>
        public Triangle(Triangle triangle)
        {
            this.Sides = triangle.Sides;
            SetTypeFigure(triangle.GetTypeFigure());
        }
    }
}
