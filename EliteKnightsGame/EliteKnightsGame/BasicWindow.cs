using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel;
using Microsoft.Xna.Framework;

namespace EliteKnightsGame
{
    abstract class BasicWindow
    {
        public static int AccountWidth = 310;
        public static int AccountHeight = 240;

        public static int ButtonSkillLade = 45;
        public static int ButtonOptionWidth = 130;
        public static int ButtonOptionHeight = 45;

        public static int TextBoxWidth = 140;
        public static int TextBoxHeight = 30;
        public static int SpaceLade = 10;

        public static int MapLegth = 80;
        public static int BorderLegth = 1;
        public static int WidthBar = 120;
        public static int HeightBar = 15;
        public static int PositionYName = SpaceLade;
        public static int PositionYHealthBar = PositionYName + HeightBar + 5;
        public static int PositionYEnergyBar = PositionYHealthBar + HeightBar + 2;

        public static int PositionXDurationBar;
        public static int PositionYDurationBar;

        public static int PositionYButtonOption;
        public static int PositionXButtonOption;

        public static int PositionXSkillBar;
        public static int PositionYSkillBar;

        public static Rectangle RectangleLogOther;
        public static int PositionYLog;

        public static int PositionXMap;
        public static int PositionYMap;

        public static void Initialize(Rectangle windowSize)
        {
            PositionYButtonOption = 150;    //350
            PositionXButtonOption = windowSize.Width - (ButtonOptionWidth);//PositionYButtonOption);

            PositionXSkillBar = (windowSize.Width - General.CountSkillsMax * ButtonSkillLade) / 2;
            PositionYSkillBar = windowSize.Height - ButtonSkillLade;

            RectangleLogOther = new Rectangle((windowSize.Width - 300) / 2, 50, 300, 100);
            PositionYLog = windowSize.Height / 3;

            PositionXDurationBar = windowSize.Width / 2;
            PositionYDurationBar = PositionYName;

            PositionXMap = windowSize.Width - (MapLegth + SpaceLade);
            PositionYMap = SpaceLade;
        }
    }
}
