using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;
using Microsoft.Xna.Framework.Graphics;
using EliteKnightsGame.Entities;

namespace EliteKnightsGame.Interface
{
    class InterfaceGame
    {
        private StatisticCharacter characterStatistic, enemyStatistic;
        private MapLocation map;
        private Log log;
        private Chat chat;
        private SkillsBar skillsBar;

        private bool selected;

        public InterfaceGame(AttackCharacter character)
        {
            characterStatistic = new StatisticCharacter(character);    //mejorar
            map = new MapLocation(character);
            log = new Log(character);
            chat = new Chat(character);
            skillsBar = new SkillsBar(character);
        }

        public void Update()
        {
            characterStatistic.Update();

            if (selected)
                enemyStatistic.Update();

            log.Update();
            skillsBar.Update();
        }

        public void Draw()
        {
            characterStatistic.Draw(BasicWindow.SpaceLade);

            if (selected)
                enemyStatistic.Draw(BasicWindow.SpaceLade + 200);

            map.Draw();
            log.Draw();
            chat.Draw();
            skillsBar.Draw();
        }

        public void AddSelected(IEntityView entity)
        {
            if (entity is PersonageView)
            {
                selected = true;
                PersonageView personage = (PersonageView)entity;
                enemyStatistic = new StatisticCharacter(personage.Personage);
                skillsBar.Enemy = personage.Personage;
            }
        }

        public void RemoveSelected()
        {
            selected = false;
            enemyStatistic = null;
            skillsBar.Enemy = null;
        }
    }
}
