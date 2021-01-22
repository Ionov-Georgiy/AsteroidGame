using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame.Objects
{
    static class GamePreferences
    {
        static private int DisplaySettingsIndex = 0;

        static private Size[] DisplaySizes = new Size[3] { new Size(800, 600), new Size(1024, 768), new Size(1920, 1080) };

        /// <summary>
        /// Устанавливает настройки окна
        /// </summary>
        /// <param name="DisplaySettings"> 
        /// {0} 800 - 600 
        /// {1} 1024 - 768
        /// {2} 1920 - 1080
        /// </param>
        static public void SetDisplaySettings(int DisplaySettings)
        {
            DisplaySettingsIndex = DisplaySettings;
        }

        static public Size DisplaySettings { get { return DisplaySizes[DisplaySettingsIndex]; } }

    }
}
