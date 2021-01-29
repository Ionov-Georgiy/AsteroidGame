using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsteroidGame.Interfaces;

namespace AsteroidGame.Objects
{
    class UI
    {
        public readonly Point Location;
        public Size UISize => uiSize;
        private Size uiSize = Size.Empty;
        public Dictionary<IUIElement, Point> UIElements = new Dictionary<IUIElement, Point>();

        public UI(Point Location, IEnumerable<IUIElement>UIElementsList)
        {
            this.Location = Location;
            foreach (IUIElement elem in UIElementsList)
            {
                UIElements.Add(elem, new Point(Location.X + UISize.Width, Location.Y));
                uiSize.Width += elem.ElementSize.Width + 20;
            }            
        }

        public void Draw(Graphics g)
        {
            //UIElements.Select(
            //    (KeyValuePair<IUIElement, Point> el) => { 
            //        el.Key.Draw(g, el.Value); 
            //        return el;
            //    });
        }
    }
}
