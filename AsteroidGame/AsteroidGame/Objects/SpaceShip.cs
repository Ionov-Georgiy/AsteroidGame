﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.Objects
{
    class SpaceShip : ObjectInSpace, ICollisionable
    {
        public int Energy { get { return energy; } }
        private int energy = 20;

        public event EventHandler Destroyed;

        public SpaceShip(Point Position, Point Direction, Size ShipSize, Space ObjectSpace)
            : base(Position, Direction, ShipSize, ObjectSpace) 
        {

        }

        override public void Draw(Graphics g) 
        {
            var rect = Rect;
            g.FillEllipse(Brushes.Blue, rect);
            g.DrawEllipse(Pens.Yellow, rect);
        }

        override public void DoCollisionConsequences(ICollisionable obj)
        {
            if (obj is Asteroid asteroid)
            {
                ChangeEnergy(-(asteroid.Direction.X + asteroid.Direction.Y / 2));
            }
        }

        public void ChangeEnergy(int delta)
        {
            energy += delta;

            if(energy < 0)
            {
                Destroyed?.Invoke(this, EventArgs.Empty);
            }
        }

        public override void MoveInSpace() { }

        public void MoveUp()
        {
            if (Position.Y > 0)
                Position.Y -= Direction.Y;
        }

        public void MoveDown()
        {
            if (Position.Y - ObjectSize.Height < ObjectSpace.SpaceSize.Height)
                Position.Y += Direction.Y;
        }

    }
}
