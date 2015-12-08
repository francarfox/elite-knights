using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel;
using EliteKnightsGame.Entities;
using EliteKnightsGame.Resources;
using EliteKnightsModel.Characters;
using Microsoft.Xna.Framework.Input;
using EliteKnightsGame.Interface;
using EliteKnightsModel.Simulator;

namespace EliteKnightsGame.Gameplay
{
    class Core : IObserverWorld
    {
        private Memory memory;
        private World world;
        private PersonageView principal;
        private List<IEntityView> entities;
        //add gravedad
        private Camera camera;
        private InterfaceGame interfaceGame;

        private bool start;

        public Core(Memory memory)
        {
            this.memory = memory;
            world = World.Instance;
            world.AddObserver(this);
            entities = new List<IEntityView>();
        }

        public void Initialize()
        {
            world.Initialize(memory.Profile.MainPersonage); //notifications
            camera = new CameraGame(principal.Personage);
            interfaceGame = new InterfaceGame(principal.Personage);
        }

        public void Update()
        {
            EntitiesSelected();
            KeyboardDetected();

            if (start)
            {
                //entities.Sort();
                foreach (IEntityView entity in entities)
                    entity.Update();
            }

            camera.Update();
            interfaceGame.Update();
        }

        public void Draw()
        {
            foreach (IEntityView entity in entities)
                entity.Draw();

            interfaceGame.Draw();
        }

        private void EntitiesSelected()
        {
            MouseState mouse = Mouse.GetState();

            foreach(IEntityView entity in entities)
            {
                if(entity.IsSelected() && entity != principal && mouse.LeftButton == ButtonState.Pressed)
                {
                    interfaceGame.AddSelected(entity);
                    break;
                }
                else
                    if (mouse.Y < BasicWindow.PositionYSkillBar && mouse.LeftButton == ButtonState.Pressed)
                        interfaceGame.RemoveSelected();

            }
        }

        private void KeyboardDetected()
        {
            KeyboardState kBoard = Keyboard.GetState();

            if (kBoard.IsKeyDown(KeyboardGame.Up))
                principal.Personage.Move(Direction.Up);

            if (kBoard.IsKeyDown(KeyboardGame.Down))
                principal.Personage.Move(Direction.Down);

            if (kBoard.IsKeyDown(KeyboardGame.Right))
                principal.Personage.Move(Direction.Right);

            if (kBoard.IsKeyDown(KeyboardGame.Left))
                principal.Personage.Move(Direction.Left);

            if (kBoard.IsKeyDown(KeyboardGame.RotateRight))
                principal.Personage.Rotate(Direction.GireRight);

            if (kBoard.IsKeyDown(KeyboardGame.RotateLeft))
                principal.Personage.Rotate(Direction.GireLeft);
        }

        public void Start()
        {
            start = true;
        }

        //public void Pause()
        //{
        //    start = false;
        //}

        public void UpdateAddPrincipal(Personage personage)
        {
            principal = (PersonageView)CreatorView.View(personage);
            entities.Add(principal);
        }

        public void UpdateAddEntity(IEntity entity)
        {
            IEntityView drawable = CreatorView.View(entity);
            entities.Add(drawable);
        }
    }
}
