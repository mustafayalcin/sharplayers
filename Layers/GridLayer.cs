using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLayers.Layers
{
    class GridLayer : HTTPRequestLayer
    {
        protected List<Tile> _grid = null;

        public GridLayer(string name, string url)
            :base(name, url)
        {
            _grid = new List<Tile>();    
        }
    }
}
