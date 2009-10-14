using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLayers.Layers
{
    class HTTPRequestLayer : Layer
    {
        protected string _url = null;

        public HTTPRequestLayer(string name, string url)
            :base(name)
        {
            _url = url;

        }
    }
}
