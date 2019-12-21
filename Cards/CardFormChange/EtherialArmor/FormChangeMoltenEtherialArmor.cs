using System.Collections.Generic;
using PotOfGreed.Players;
using Terraria;
using Terraria.Localization;

namespace PotOfGreed.Cards.CardFormChange.EtherialArmor
{
    public sealed class FormChangeMoltenEtherialArmor : FormChangeEtherialArmor
    {
        public FormChangeMoltenEtherialArmor() : base(
            new Dictionary<GameCulture, string>()
            {
                { GameCulture.English, "Molten Armor" }
            }, 25, player => !Main.hardMode)
        {
        }


        public override void Update(POGPlayer pogPlayer)
        {
            pogPlayer.player.meleeDamageMult += 0.17f;
        }
    }
}