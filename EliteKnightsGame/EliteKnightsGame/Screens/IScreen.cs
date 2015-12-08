using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsGame.Screens
{
    public interface IScreen
    {
        void Initialize();
        void Update();
        void Draw();
    }
}
