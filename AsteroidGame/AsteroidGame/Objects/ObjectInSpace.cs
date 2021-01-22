using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.Objects
{
    class ObjectInSpace : IMovableInSpace, ICollisionable
    {

        protected Point Position;
        public Point Direction { get { return direction; } }
        protected Point direction;
        protected Size ObjectSize;
        public Rectangle Rect { get { return new Rectangle(Position, ObjectSize); } }

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

        public virtual void MoveInSpace(Size SpaceSize)
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

        public bool CheckCollision(ICollisionable obj)
        {
            return Rect.IntersectsWith(obj.Rect);
        }

        virtual public void DoCollisionConsequences(ICollisionable obj)
        {
            Point CollisionObjectDirection = obj.Direction;
            if (direction.X > 0 || CollisionObjectDirection.X < 0)
            {
                direction.X = CollisionObjectDirection.X * -1;
            }
            else
            {
                direction.X = CollisionObjectDirection.X;
            }

            if (direction.Y > 0 || CollisionObjectDirection.Y < 0)
            {
                direction.Y = CollisionObjectDirection.Y * -1;
            }
            else
            {
                direction.Y = CollisionObjectDirection.Y;
            }
        }

    }
}
