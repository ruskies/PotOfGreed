using PotOfGreed.Players;
using Terraria.ModLoader;

namespace PotOfGreed.Commands
{
    public class ResetCardsUsed : ModCommand
    {
        public override void Action(CommandCaller caller, string input, string[] args)
        {
            POGPlayer.Get(caller.Player).ResetCardsUsed();
        }


        public override bool Autoload(ref string name) => true;


        public override string Command { get; } = "resetcu";
        public override CommandType Type { get; } = CommandType.Chat;
    }
}