using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;
using EliteKnightsModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using EliteKnightsGame.Screens;

namespace EliteKnightsGame.Gameplay
{
    class CameraGame : Camera, IObserverMobile
    {
        private Character character;

        public CameraGame(Character character)
        {
            this.character = character;
            character.AddObserver(this);

            yaw = (float)Math.PI;
            pitch = -0.2f;

            UpdateDistance();
        }

        public override void Update()
        {
            MouseState mouse = Mouse.GetState();
            MouseState oldMouse = GameLoop.OldMouse;
            ray = CreateRay(mouse);

            if (mouse.RightButton == ButtonState.Pressed && oldMouse.RightButton == ButtonState.Pressed)
            {
                if (mouse.X > oldMouse.X)
                    character.Rotate(Direction.GireRight * 5);
                if (mouse.X < oldMouse.X)
                    character.Rotate(Direction.GireLeft * 5);
            }

            UpdateMatrices();
        }

        public void UpdateMove(Vector traslation)
        {
            Vector3 move = new Vector3(traslation.X, traslation.Z, traslation.Y);
            Move(-move);
        }

        public void UpdateRotate(float rotate)
        {
            yaw = (float)Math.PI + rotate;

            UpdateDistance();
        }

        private void UpdateDistance()
        {
            Vector3 forward = Vector3.Transform(ConstantGame.CameraDistance, Matrix.CreateRotationY(yaw));
            position = PosCharacter() + forward;
        }

        private Vector3 PosCharacter()
        {
            return new Vector3(character.Position.X, character.Position.Z, character.Position.Y);
        }
    }
}
