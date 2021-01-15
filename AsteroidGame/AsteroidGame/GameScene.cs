using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    class GameScene
    {
        private Form SceneForm;
        private Space SceneObject;
        private BufferedGraphicsContext context;
        private BufferedGraphics buffer;

        public GameScene(Form SceneForm, Space SceneObject)
        {
            this.SceneForm = SceneForm;
            this.SceneObject = SceneObject;
            context = BufferedGraphicsManager.Current;
            Graphics g = SceneForm.CreateGraphics();
            buffer = context.Allocate(g, new Rectangle(0, 0, SceneForm.DisplayRectangle.Width, SceneForm.DisplayRectangle.Height));
        }

        private void DrawScene()
        {
            Graphics g = buffer.Graphics;
            g.Clear(Color.Black);
            ObjectInSpace[] objArr = SceneObject.GetSpaceObjects();
            foreach (var game_object in objArr)
            {
                game_object.Draw(g);
            }

            buffer.Render();
        }

        public void ShowScene()
        {
            DrawScene();
            SceneForm.Show();
        }
    }
}
