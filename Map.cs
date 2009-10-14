using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Web.UI.HtmlControls;

namespace SharpLayers
{
    class Map
    {
        protected Size _tileSize = new Size(256, 256);
        protected Rect _maxExtent = Rect.Empty;
        protected HtmlControl _parentDiv = null;
        protected HtmlControl _viewPortDiv = null;
        protected HtmlControl _layerContainerDiv = null;
        protected Size _size = Size.Empty;
        protected int? _zoom = 0;
        protected LonLat _center = null;
        protected Layer _baseLayer = null;
        protected bool _fractionalZoom = false;

        public Map(HtmlControl parentDiv)
        {
            _parentDiv = parentDiv;
            _maxExtent = new Rect(new Point(-180, -90), new Point(180, 90));
            _parentDiv.Attributes["class"] = "olMap";
            _viewPortDiv = Util.createDiv("_ViewPort", null, Size.Empty, null, "relative", null, "hidden", 2f);
            _viewPortDiv.Style["width"] = "100%";
            _viewPortDiv.Style["height"] = "100%";
            _viewPortDiv.Attributes["class"] = "olMapViewport";
            _parentDiv.Controls.Add(_viewPortDiv);
            _layerContainerDiv = Util.createDiv("_Container", null, Size.Empty, null, null, null, null, 2f);
            _layerContainerDiv.Style["z-index"] = "999";
            _viewPortDiv.Controls.Add(_layerContainerDiv);
            
            updateSize();
        
        }

        public bool fractionalZoom
        {
            get { return _fractionalZoom; }
        }

        public int? getZoom()
        {
            return _zoom;
        }

        private void updateSize()
        {
            Size newSize = getCurrentSize();
            Size oldSize = getSize();

            if (oldSize == Size.Empty)
            {
                _size = oldSize = newSize;                
            }
            if (!newSize.Equals(oldSize))
            {
                _size = newSize;
                
                // @@@ notify layers on resize?

                if (_baseLayer != null)
                {
                    Pixel center = new Pixel((float)(newSize.Width / 2), (float)(newSize.Height / 2));
                    LonLat lonlat = getLonLatFromViewPortPx(center);
                    int zoom = getZoom().Value;
                    _zoom = null;
                    setCenter(getCenter(), zoom, null, null);
                }
            }
        }

        public void setCenter(LonLat lonlat, int zoom, bool? dragging, bool? forceZoomChange)
        {
            //moveTo(lonlat, 
        }

        public LonLat getCenter()
        {
            return _center;    
        }

        private LonLat getLonLatFromViewPortPx(Pixel viewPortPx)
        {
            LonLat lonlat = null;

            if (_baseLayer != null)
            {
                lonlat = _baseLayer.getLonLatFromViewPortPx(viewPortPx);
            }

            return lonlat;
        }

        public float? getResolution()
        {
            if (_baseLayer != null)
                return _baseLayer.getResolution();

            return null;
        }

        public Size getSize()
        {
            return _size;
        }

        private Size getCurrentSize()
        {
            // @@@ check for style as well
            return new Size(double.Parse(_parentDiv.Attributes["width"]),
                double.Parse(_parentDiv.Attributes["height"]));

        }
    }
}
