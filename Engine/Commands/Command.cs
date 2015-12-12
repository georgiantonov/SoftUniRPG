using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Commands
{
    public abstract class Command : ICommand
    {
        private IGEngine gameEngine;

        public Command(IGEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        public IGEngine GameEngine
        {
            get
            {
                return this.gameEngine;
            }
            private set
            {
                this.gameEngine = value;
            }
        }

        public abstract void Execute(string[] arguments);
    }
}
