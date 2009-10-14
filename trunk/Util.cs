using System.Web.UI.HtmlControls;
using System.Windows;

namespace SharpLayers
{
    public static class Util
    {
        private static int _lastSeqID = 0;

        public static string createUniqueID(string prefix)
        {
            if (prefix == null)
                prefix = "id_";

            _lastSeqID++;
            return prefix + _lastSeqID.ToString();

        }

        public static HtmlControl createDiv(string id, Pixel px, Size sz, string imgUrl, string position, 
            string border, string overflow, float opacity)
        {
            HtmlContainerControl div = new HtmlGenericControl("div");

            if (imgUrl != null)
                div.Style.Add("background-image", string.Format("url({0})", imgUrl));

            if (position == null)
                position = "absolute";

            modifyDOMElement(div, id, px, sz, position, border, overflow, opacity);

            return div;
        }

        public static void modifyDOMElement(HtmlControl element, string id, Pixel px, Size sz, string position, string border,
            string overflow, float opacity)
        {
            if (id != null)
                element.ID = id;

            if (px != null)
            {
                element.Style["left"] = px.x + "px";
                element.Style["top"] = px.y + "px";
            }

            if (sz != Size.Empty)
            {
                element.Style["width"] = sz.Width + "px";
                element.Style["height"] = sz.Height + "px";
            }

            if (position != null)
            {
                element.Style["position"] = position;
            }

            if (border != null)
            {
                element.Style["border"] = border;
            }

            if (overflow != null)
            {
                element.Style["overflow"] = overflow;
            }

            if (opacity >= 0 && opacity < 1)
            {
                element.Style["filter"] = string.Format("alpha(opacity={0})", opacity * 100);
                element.Style["opacity"] = opacity.ToString();
            }
            else
                if (opacity == 1)
                {
                    element.Style["filter"] = "";
                    element.Style["opacity"] = "";
                }

        }
            
    }
}
