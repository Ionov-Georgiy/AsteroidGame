using AsteroidGame.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.Objects
{
    class Asteroid : ObjectInSpace, ICollisionable
    {

        private Image astrImg;
        private int Id;
        public Rectangle Rect { get { return rect; } }
        private Rectangle rect;

        public bool CheckCollision(ICollisionable obj)
        {
            return rect.IntersectsWith(obj.Rect);
        }

        public void DoCollisionConsequences()
        {
            astrImg.RotateFlip(RotateFlipType.Rotate180FlipX);
            Direction.X *= -1;
            Direction.Y *= -1;
        }

        public Asteroid(Point Position, Point Direction, int Size, int Id)
            : base(Position, Direction, new Size(Size, Size))
        {
            this.Id = Id;
            rect = new Rectangle(Position, ObjectSize);
            astrImg = Image.FromFile("Asteroid.png");
        }

        override public void Move(Size SpaceSize)
        {
            Position.X += Direction.X;
            Position.Y += Direction.Y;

            if (Position.X < 0)
            {
                direction.X *= -1;
                astrImg.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
            if (Position.Y < 0 + ObjectSize.Height)
            {
                direction.Y *= -1;
                astrImg.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }

            if (Position.X + ObjectSize.Width > SpaceSize.Width)
            {
                direction.X *= -1;
                astrImg.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
            if (Position.Y + ObjectSize.Height > SpaceSize.Height)
            {
                direction.Y *= -1;
                astrImg.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }
        }

        override public void Draw(Graphics g)
        {
            g.DrawImage(astrImg, new Point(Position.X, Position.Y));
        }

    }
}
