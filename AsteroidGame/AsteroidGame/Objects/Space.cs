using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.Objects
{
    class Space
    {
        private int starsAmount;
        private int asteroidsAmount;
        private Size size { get; set; }
        private List<ObjectInSpace> backgroundObjects;
        private List<ObjectInSpace> foregroundObjects;

        public Space(Size size, int starsAmount, int asteroidsAmount)
        {
            this.size = size;
            this.starsAmount = starsAmount;
            this.asteroidsAmount = asteroidsAmount;
            FillInSpace();
        }

        private void FillInSpace()
        {
            backgroundObjects = new List<ObjectInSpace>();
            foregroundObjects = new List<ObjectInSpace>();
            CreateStars();
            CreateAsteroids();
            ///////////////////////////////////////////
            foregroundObjects.Add(new Bullet(300)); //Временная затычка
        }

        private void CreateStars()
        {
            for (int i = 0; i < starsAmount; i++)
            {
                StarType starType = (StarType)StaticRandom.GetRandom(1, 6);
                int starBrightness = StaticRandom.GetRandom(1, 6);
                //StarType starType = StarType.Shiny;
                backgroundObjects.Add(new Star(
                    new Point(StaticRandom.GetRandom(1, size.Width), StaticRandom.GetRandom(1, size.Height)),
                    new Point(-StaticRandom.GetRandom(1, i + 1), 0),
                    10, starType, starBrightness));
            }

        }

        private void CreateAsteroids()
        {
            for (int i = 0; i < asteroidsAmount; i++)
            {
                foregroundObjects.Add(new Asteroid(
                    new Point(size.Width/*rand.Next(10, size.Width-10)*/, StaticRandom.GetRandom(10, size.Height - 10)),
                    new Point(-StaticRandom.GetRandom(1, 20), StaticRandom.GetRandom(20)),
                    10));
            }

        }

        public void MoveSpaceObjects()
        {
            MoveBackgroundObjects();
            MoveForegroundObjects();
            FindCollisionsDoCollisionConsequences();
        }

        public ObjectInSpace[] GetSpaceObjects()
        {
            ObjectInSpace[] objsInSpace = new ObjectInSpace[backgroundObjects.Count + foregroundObjects.Count];
            int objsCounter = 0;
            for(int i = 0; i < backgroundObjects.Count; i++)
            {
                objsInSpace[objsCounter] = backgroundObjects[i];
                objsCounter++;
            }

            for (int i = 0; i < foregroundObjects.Count; i++)
            {
                objsInSpace[objsCounter] = foregroundObjects[i];
                objsCounter++;
            }

            return objsInSpace;
        }

        private void MoveBackgroundObjects()
        {
            foreach (var backgroundObject in backgroundObjects)
                backgroundObject.MoveInSpace(size);
        }

        private void MoveForegroundObjects()
        {
            foreach (var foregroundObject in foregroundObjects)
            {
                foregroundObject.MoveInSpace(size);
            }
        }

        private void FindCollisionsDoCollisionConsequences()
        {
            List<ICollisionable> ListOfCollisionableObjects = GetCollisionableObjects();
            foreach (var foregroundObject in foregroundObjects)
            {
                if (ListOfCollisionableObjects.Count > 0)
                {
                    if (foregroundObject is ICollisionable)
                    {
                        ICollisionable collisionableForegroundObject = foregroundObject as ICollisionable;
                        ListOfCollisionableObjects.Remove(collisionableForegroundObject);
                        DoCollisions(collisionableForegroundObject, ListOfCollisionableObjects);
                    }
                }
            }
        }

        private List<ICollisionable> GetCollisionableObjects()
        {
            List<ICollisionable> ListOfCollisionableObjects = new List<ICollisionable>();
            foreach (var foregroundObject in foregroundObjects)
            {
                if(foregroundObject is ICollisionable)
                {
                    ListOfCollisionableObjects.Add(foregroundObject as ICollisionable);
                }
            }
            return ListOfCollisionableObjects;
        }

        private void DoCollisions(ICollisionable foregroundObject, List<ICollisionable> ListOfObjects)
        {
            foreach (ICollisionable anotherForegroundObject in ListOfObjects)
            {
                if (anotherForegroundObject.CheckCollision(foregroundObject))
                {
                    ICollisionable temp = new ObjectInSpace(foregroundObject.Rect.Location, foregroundObject.Direction, foregroundObject.Rect.Size) as ICollisionable;
                    foregroundObject.DoCollisionConsequences(anotherForegroundObject);
                    anotherForegroundObject.DoCollisionConsequences(temp);
                }

            }
        }

    }
}
