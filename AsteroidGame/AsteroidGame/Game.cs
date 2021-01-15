using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        private static BufferedGraphicsContext context;
        private static BufferedGraphics buffer;
        private static Space space;
        private static Form mainMenuForm;
        private static Form gameForm;
        private static Timer timer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static void Initialize(Form GameForm, Form MainMenu)
        {
            Width = GameForm.DisplayRectangle.Width;
            Height = GameForm.DisplayRectangle.Height;
            mainMenuForm = MainMenu;
            gameForm = GameForm;
            timer = new Timer { Interval = 100 };
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            PlayTurn();
            Draw();
        }

           

        public static void StartMainMenu()
        {
            space = new Space(new Size(800, 600), 30, 0);

            context = BufferedGraphicsManager.Current;
            Graphics g = mainMenuForm.CreateGraphics();
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Draw();

        }

        public static void StartGame()
        {
            space = new Space(new Size(800, 600), 30, 10);

            context = BufferedGraphicsManager.Current;
            Graphics g = gameForm.CreateGraphics();
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            //timer.Interval = 100;
            timer.Tick += OnTimerTick;
            timer.Start();
            Draw();

            mainMenuForm.Visible = false;
            mainMenuForm.Enabled = false;
            gameForm.Show(mainMenuForm);
        }

        public static void EndGame()
        {
            timer.Stop();
        }

        private static void PlayTurn()
        {
            space.MoveSpaceObjects();
        }

        private static void Draw()
        {
            Graphics g = buffer.Graphics;
            g.Clear(Color.Black);
            ObjectInSpace[] objArr = space.GetSpaceObjects();
            foreach (var game_object in objArr)
            {
                game_object.Draw(g);
            }

            buffer.Render();
        }

    }
}
