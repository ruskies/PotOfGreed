using System.Collections.Generic;
using PotOfGreed.Players;
using Terraria;
using Terraria.Localization;

namespace PotOfGreed.Cards.CardFormChange.EtherialArmor
{
    public sealed class FormChangeChlorophyteEtherialArmor : FormChangeEtherialArmor
    {
        public FormChangeChlorophyteEtherialArmor() : base(
            new Dictionary<GameCulture, string>()
            {
                { GameCulture.English, "Chlorophyte" }
            }, 56, player => Main.hardMode && !NPC.downedGolemBoss)
        {
        }


        public override void Update(POGPlayer pogPlayer)
        {
            pogPlayer.player.crystalLeaf = true;
        }
    }
}