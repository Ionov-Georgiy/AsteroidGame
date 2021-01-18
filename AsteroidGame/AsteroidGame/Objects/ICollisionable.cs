using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame.Objects
{
    interface ICollisionable
    {
        Rectangle Rect { get; }

        bool CheckCollision(ICollisionable obj);

        void DoCollisionConsequences(Point NewDirection);
    }
}
