using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Shapes
{
    class CCircle : Shape
    {
        private int m_x, m_y; // Центр круга
        private int m_radius = 20; // Радиус круга
        private bool isSelection; // Выделен ли элемент
        private int distForSel = 6;
        private Color _color;

        public CCircle()
        {
            m_x = 0; m_y = 0;
        }
        public CCircle(int x, int y)
        {
            m_x = x;
            m_y = y;
        }

        // Создаёт круг с серединной в указанной точке
        public Shape clone() { return new CCircle(); }
        public void setX(int x) { m_x = x; }
        public void setY(int y) { m_y = y; }
        // Находится ли указанные координаты внутри фигуры
        public bool inShape(int x, int y)
        {
            bool isBigger = Math.Sqrt(Math.Pow(x - m_x, 2) +  Math.Pow(y - m_y, 2)) > m_radius;
            return !isBigger;
        }
        public void setColor(Color color)
        {
            if(isSelection)
                _color = color;
        }
        // Прорисовка круга: в случае выделения и созодания
        public void draw(Graphics gr, Pen penNotSel, Pen penSel)
        {
            penNotSel.Color = _color;
            gr.DrawEllipse(penNotSel, m_x - m_radius, m_y - m_radius, 2 * m_radius, 2 * m_radius);
            penNotSel.Color = Color.Black;
            if (isSelection)
            {
                gr.DrawEllipse(penSel, m_x - m_radius - distForSel / 2, m_y - m_radius - distForSel / 2, 2 * m_radius + distForSel, 2 * m_radius + distForSel);
            }
        }
        public void setSelection(bool flag)
        {
            isSelection = flag;
        }
        public bool getSelection()
        {
            return isSelection;
        }
        public void moveX(int num, int start, int end)
        {
            if (m_x - m_radius + num < start)
                m_x = start + m_radius;
            else if (m_x + m_radius + num > end)
                m_x = end - m_radius;
            else
                m_x += num;
        }
        public void moveY(int num, int start, int end)
        {
            if(m_y - m_radius + num < start)
                m_y = start + m_radius;
            else if(m_y + m_radius + num > end)
                m_y = end - m_radius;
            else
                m_y += num;
        }
        public void changeSize(int num)
        {
            if(m_radius + num > 0)
                m_radius += num;
        }
    }
}
