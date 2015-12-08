using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using EliteKnightsGame.Interface;

namespace EliteKnightsGame.Gameplay
{
    abstract class Camera
    {
        protected static Ray ray;
        protected static Matrix view, projection;
        protected Vector3 position;
        protected float yaw, pitch;

        public Camera()
        {
            this.position = Vector3.Zero;   //test

            view = Matrix.CreateLookAt(position, Vector3.Zero, Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), GameLoop.Device.Viewport.AspectRatio, 0.01f, 1000.0f);

            ray = new Ray();
        }

        public abstract void Update();

        protected void UpdateMatrices()
        {
            Matrix rotation = Matrix.CreateRotationX(pitch) * Matrix.CreateRotationY(yaw);

            Vector3 transformed = Vector3.Transform(new Vector3(0, 0, -1), rotation);
            Vector3 lookAt = position + transformed;

            view = Matrix.CreateLookAt(position, lookAt, Vector3.Up);
        }

        protected void Move(Vector3 direction)
        {
            Vector3 forward = Vector3.Transform(direction, Matrix.CreateRotationY(yaw));
            position += forward;
        }

        protected Ray CreateRay(MouseState mouse)
        {
            Vector3 nearSource = new Vector3(mouse.X, mouse.Y, 0);
            Vector3 farSource = new Vector3(mouse.X, mouse.Y, 1);

            Vector3 nearPoint = GameLoop.Device.Viewport.Unproject(nearSource, projection, view, Matrix.Identity);
            Vector3 farPoint = GameLoop.Device.Viewport.Unproject(farSource, projection, view, Matrix.Identity);

            Vector3 direction = farPoint - nearPoint;
            direction.Normalize();

            return new Ray(nearPoint, direction);
        }

        public static Matrix View
        {
            get { return view; }
        }

        public static Matrix Projection
        {
            get { return projection; }
        }

        public static Ray Ray
        {
            get { return ray; }
        }
    }
}
