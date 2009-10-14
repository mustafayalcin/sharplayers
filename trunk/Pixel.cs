using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SharpLayers
{
    public class Pixel
    {
        private float _x = 0;
        private float _y = 0;

        public Pixel(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public float x
        {
            get { return _x; }
        }

        public float y
        {
            get { return _y; }
        }

    }
}
