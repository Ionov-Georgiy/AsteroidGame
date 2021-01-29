using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsteroidGame.Interfaces;

namespace AsteroidGame.Objects
{
    class EnergyBar : IUIElement
    {
        public Size ElementSize => elementSize;
        private Size elementSize = new Size(100, 10);
        public int CurrentEnergy;
        public int MaxEnergy;

        public EnergyBar(int CurrentEnergy, int MaxEnergy)
        {
            this.CurrentEnergy = CurrentEnergy;
            this.MaxEnergy = MaxEnergy;
        }

        public void Draw(Graphics g, Point ElementLocation)
        {
            g.DrawRectangle(Pens.Red, ElementLocation.X, ElementLocation.Y, ElementSize.Width, ElementSize.Height);
            g.FillRectangle(Brushes.Red, ElementLocation.X, ElementLocation.Y, CurrentEnergy*ElementSize.Width/MaxEnergy, ElementSize.Height);
        }

    }
}
