using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Commands
{
    public class CreateItemCommand : Command
    {
        public CreateItemCommand(IGEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] arguments)
        {
            throw new NotImplementedException();
        }
    }
}
