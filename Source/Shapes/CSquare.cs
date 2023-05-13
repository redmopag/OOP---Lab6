using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Shapes
{
    class CSquare : Shape
    {
        private int _x, _y;
        private int _width = 30, _height = 30;
        private bool _isSelection;
        private int distForSel = 6;
        private Color _color;

        public CSquare() { _x = 0; _y = 0; }
        public CSquare(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public Shape clone() { return new CSquare(); }
        public void setX(int x) { _x = x; }
        public void setY(int y) { _y = y; }
        public bool inShape(int x, int y)
        {
            bool isIn = false;
            if ((x > _x - _width / 2) && (x < _x + _width / 2) && (y > _y - _height / 2) && (y < _y + _height / 2))
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
            int centerX = _x - _width / 2;
            int centerY = _y - _height / 2;
            penNotSel.Color = _color;
            gr.DrawRectangle(penNotSel, centerX, centerY, _width, _height);
            penNotSel.Color = Color.Black;
            if (_isSelection)
            {
                gr.DrawRectangle(penSel, centerX - (distForSel / 2), centerY - (distForSel / 2), _width + distForSel, _height + distForSel);
            }
        }
        public void setSelection(bool selection) { _isSelection = selection;}
        public bool getSelection() { return _isSelection; }
        public void moveX(int num, int start, int end)
        {
            if (_x - _width / 2 + num < start)
                _x = start + _width / 2;
            else if (_x + _width / 2 + num > end)
                _x = end - _width / 2;
            else
                _x += num;
        }
        public void moveY(int num, int start, int end)
        {
            if (_y - _height / 2 + num < start)
                _y = start + _height / 2;
            else if (_y + _height / 2 + num > end)
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
                _width += num;
                _height += num;
            }
        }
    }
}
