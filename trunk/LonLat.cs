using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SharpLayers
{
    class LonLat
    {
        private float _lon;
        private float _lat;

        public LonLat(float lon, float lat)
        {
            _lat = lat;
            _lon = lon;
        }

        public LonLat(LonLat c)
        {
            this._lat = c._lat;
            this._lon = c._lon;
        }

        public float lon
        {
            get { return _lon; }
            set { _lon = value; }
        }

        public float lat
        {
            get { return _lat; }
        }

        public LonLat wrapDateLine(Rect maxExtent)
        {
            LonLat newLonLat = new LonLat(this);

            if (maxExtent != Rect.Empty)
            {
                while (newLonLat.lon < maxExtent.X)
                {
                    newLonLat.lon += (float)maxExtent.Width;
                }

                while (newLonLat.lon > maxExtent.Right)
                {
                    newLonLat.lon -= (float)maxExtent.Width;
                }
            }

            return newLonLat;
        }
    }
}
