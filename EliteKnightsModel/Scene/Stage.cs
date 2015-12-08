using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel.Scene
{
    public abstract class Stage : Entity, IStage
    {
        private int width, height;

        public Stage(string name, Vector position, int width, int height)
            : base(name, position)
        {
            this.width = width;
            this.height = height;
        }

        public int Width
        {
            get { return width; }
        }
    }
}
