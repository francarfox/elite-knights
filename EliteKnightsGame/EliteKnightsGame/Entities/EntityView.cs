using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using EliteKnightsGame.Gameplay;
using EliteKnightsModel;
using EliteKnightsGame.Resources;

namespace EliteKnightsGame.Entities
{
    abstract class EntityView : IEntityView
    {
        private Model model;
        protected Vector3 position, rotation;
        private Vector3 scale;
        private Matrix world;
        
        //private float cameraDistance;
        private BoundingBox box;    //for selected

        public EntityView(Model model, Vector3 position, Vector3 scale, Vector3 rotation)
        {
            this.model = model;
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;

            box = new BoundingBox(ConstantGame.MinBoundigBox, ConstantGame.MaxBoundigBox);
        }

        public EntityView(Model model, Vector3 position, Vector3 scale)
            : this(model, position, scale, new Vector3(0, -1.571f, 0))
        { }

        public EntityView(Model model, Vector3 position)
            : this(model, position, new Vector3(1))
        { }

        public virtual void Update()
        {
            world = Matrix.CreateScale(scale) * Matrix.CreateFromYawPitchRoll(rotation.X, rotation.Y, rotation.Z) * Matrix.CreateTranslation(position);

            Matrix selected = world * Matrix.CreateTranslation(new Vector3(0, 1, 0));   //location of selection box
            box = new BoundingBox(Vector3.Transform(ConstantGame.MinBoundigBox, selected), Vector3.Transform(ConstantGame.MaxBoundigBox, selected));

            //cameraDistance = Vector3.Distance(position, Camera.Posicion);
        }

        public void Draw()
        {
            GameLoop.Device.DepthStencilState = DepthStencilState.Default;    //solide

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();

                    effect.World = world;
                    effect.View = Camera.View;
                    effect.Projection = Camera.Projection;

                    effect.CurrentTechnique.Passes[0].Apply();
                }

                mesh.Draw();
            }
        }

        public virtual bool IsSelected()
        {
            bool selected = false;
            float? result = box.Intersects(Camera.Ray);

            if (result != null && result != 0)
                selected = true;

            return selected;
        }
    }
}
