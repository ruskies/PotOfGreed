using System.Collections.Generic;
using PotOfGreed.Players;
using Terraria;
using Terraria.Localization;

namespace PotOfGreed.Cards.CardFormChange.EtherialArmor
{
    public sealed class FormChangeSolarChlorophyteArmor : FormChangeEtherialArmor
    {
        public FormChangeSolarChlorophyteArmor() : base(
            new Dictionary<GameCulture, string>()
            {
                { GameCulture.English, "Solar Armor" }
            }, 78, player => Main.hardMode && NPC.downedGolemBoss)
        {
        }


        public override void Update(POGPlayer pogPlayer)
        {
            pogPlayer.player.setSolar = true;
        }
    }
}