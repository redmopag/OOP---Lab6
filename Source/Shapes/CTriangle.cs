using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Shapes
{
    class CTriangle : Shape
    {
        private int _x, _y;
        private int _width = 30, _height = 30;
        private bool _isSelection;
        private int distForSel = 6;
        private Color _color;

        private Point[] _vertices = new Point[3];
        // Вычисление координат вершин треугольника
        // Выисляется от центра треугольника, указанного в _x, _y
        // Значения добавляются в _vertiсes
        private void getVertices()
        {
            // Левый нижний угол треугольника
            Point a = new Point(_x - _width / 2, _y + _height / 2);
            _vertices[0] = a;
            // Верхний угол
            Point b = new Point(_x, _y - _height / 2);
            _vertices[1] = b;
            // Правый нижний угол
            Point c = new Point(_x + _width / 2, _y + _height / 2);
            _vertices[2] = c;
        }

        public CTriangle() { _x =  0; _y = 0; }
        public CTriangle(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public Shape clone() { return new CTriangle(); }
        public void setX(int x) { _x = x; }
        public void setY(int y) { _y = y; }
        public bool inShape(int x, int y)
        {
            bool isIn = false;
            getVertices();
            // Вычисляем векторное и псевдоскалярное произведения
            int a = (_vertices[0].X - x) * (_vertices[1].Y - _vertices[0].Y) - (_vertices[1].X - _vertices[0].X) * (_vertices[0].Y - y);
            int b = (_vertices[1].X - x) * (_vertices[2].Y - _vertices[1].Y) - (_vertices[2].X - _vertices[1].X) * (_vertices[1].Y - y);
            int c = (_vertices[2].X - x) * (_vertices[0].Y - _vertices[2].Y) - (_vertices[0].X - _vertices[2].X) * (_vertices[2].Y - y);
            // Если их знаки равны между собой - точка лежит на или в треугольнике
            if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
                isIn = true;
            return isIn;
        }
        public void setColor(Color color)
        {
            if(_isSelection)
                _color = color;
        }
        public void draw(Graphics gr, Pen penNotSel, Pen penSel)
        {
            getVertices();
            penNotSel.Color = _color;
            gr.DrawPolygon(penNotSel, _vertices);
            penNotSel.Color = Color.Black;
            if (_isSelection)
            {
                _vertices[0].X -= distForSel; _vertices[0].Y += distForSel / 2;
                _vertices[1].Y -= distForSel;
                _vertices[2].X += distForSel; _vertices[2].Y += distForSel / 2;
                gr.DrawPolygon(penSel, _vertices);
            }
        }
        public void setSelection(bool selection) { _isSelection = selection; }
        public bool getSelection() { return _isSelection; }
        public void moveX(int num, int start, int end)
        {
            getVertices();
            if (_vertices[0].X + num < start)
                _x = start + _width / 2;
            else if (_vertices[2].X + num > end)
                _x = end - _width / 2;
            else
                _x += num;
        }
        public void moveY(int num, int start, int end)
        {
            getVertices();
            if (_vertices[1].Y + num < start)
                _y = start + _height / 2;
            else if (_vertices[0].Y + num > end || _vertices[2].Y + num > end)
                _y = end - _height / 2;
            else
                _y += num;
        }
        public void changeSize(int num)
        {
            int tmpWidth = _width + num;
            int tmpHeight = _height + num;
            if (tmpWidth > 0 && tmpHeight > 0)
            {
                _width = tmpWidth;
                _height = tmpHeight;
            }
        }
    }
}
