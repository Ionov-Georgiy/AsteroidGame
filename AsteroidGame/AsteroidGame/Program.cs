using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Form game_form = new Form();
            //Size DisplaySize = new Size(800, 600);
            //Size PreferedSize = game_form.GetPreferredSize(DisplaySize);
            //Size WindowSize = new Size(DisplaySize.Width + PreferedSize.Width, DisplaySize.Height + PreferedSize.Height);
            //game_form.Size = WindowSize;

            //game_form.Show();

            //Game.Initialize(game_form);
            //Game.StartGame();
            ////Game.Draw();

            //Application.Run(game_form);

            SplashScreen.Initialize();

        }
    }
}
