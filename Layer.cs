using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Web.UI.HtmlControls;
namespace SharpLayers
{
    class Layer
    {
        protected string _id = null;
        protected string _name = null;
        protected HtmlControl _div = null;
        protected float? _opacity = null;
        protected bool? _alwaysInRange = null;
        protected bool _isBaseLayer = false;
        protected bool _alpha = false;
        protected bool _displayInLayerSwitcher = true;
        protected bool _visibility = true;
        protected string _attribution = null;
        protected bool _inRange = false;
        protected Size _imageSize = Size.Empty;
        protected Pixel _imageOffset = null;
        protected int _gutter = 0;

        protected Map _map = null;
        protected List<float> _resolutions = null;
        protected bool _wrapDateLine = false;
        protected Rect _maxExtent = Rect.Empty;
        protected bool _displayOutsideMaxExtent = false;

        public Layer(string name)
        {
            _name = name;

            if (_id == null)
            {
                _id = Util.createUniqueID(GetType().Name + "_");
                _div = Util.createDiv(_id, null, Size.Empty, null, null, null, null, 2);
                _div.Style["width"] = "100%";
                _div.Style["height"] = "100%";
                _div.Style["direction"] = "ltr";

            }

            if (_wrapDateLine)
                _displayOutsideMaxExtent = true;
        }

        public LonLat getLonLatFromViewPortPx(Pixel viewPortPx)
        {
            LonLat lonlat = null;
            if (viewPortPx != null)
            {
                Size size = _map.getSize();
                LonLat center = _map.getCenter();
                if (center != null)
                {
                    float res = _map.getResolution().Value;

                    float delta_x = (float)(viewPortPx.x - (size.Width / 2));
                    float delta_y = (float)(viewPortPx.y - (size.Height / 2));

                    lonlat = new LonLat(center.lon + delta_x * res,
                                                center.lat - delta_y * res);

                    if (_wrapDateLine)
                    {
                        lonlat = lonlat.wrapDateLine(_maxExtent);
                    }
                }
            }
            return lonlat;
        }

        public float getResolution()
        {
            int? zoom = _map.getZoom();
            return getResolutionForZoom((float)zoom.Value);
        }

        public float getResolutionForZoom(float zoom)
        {
            float z = Math.Max(0, Math.Min((float)zoom, (float)(_resolutions.Count - 1)));
            if (_map.fractionalZoom)
            {
                // @@@ todo
                return z;
            }
            else
            {
                return _resolutions[(int)Math.Round(z)];
            }
        }

    }
}
