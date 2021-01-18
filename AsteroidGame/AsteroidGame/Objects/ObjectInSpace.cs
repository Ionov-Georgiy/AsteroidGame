using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.Objects
{
    abstract class ObjectInSpace 
    {

        protected Point Position;
        internal Point Direction { get { return direction; } }
        protected Point direction;
        protected Size ObjectSize;

        public ObjectInSpace(Point Position, Point Direction, Size ObjectSize)
        {
            this.Position = Position;
            this.direction = Direction;
            this.ObjectSize = ObjectSize;
        }

        public virtual void Draw(Graphics g)
        {
            g.DrawEllipse(
                Pens.White,
                Position.X, Position.Y,
                ObjectSize.Width, ObjectSize.Height);
        }

        public virtual void Move(Size SpaceSize)
        {
            Position.X += Direction.X;
            Position.Y += Direction.Y;

            if (Position.X < 0)
                direction.X *= -1;
            if (Position.Y < 0)
                direction.Y *= -1;

            if (Position.X > SpaceSize.Width - ObjectSize.Width)
                direction.X *= -1;
            if (Position.Y > SpaceSize.Height - ObjectSize.Height)
                direction.Y *= -1;
        }

    }
}
