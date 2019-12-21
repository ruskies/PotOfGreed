using System.Collections.Generic;
using PotOfGreed.Cards.CardFormChange.EtherialArmor;
using PotOfGreed.Players;
using Terraria;
using Terraria.Localization;
using WebmilioCommons.Buffs;

namespace PotOfGreed.Cards.CardFormChange
{
    public sealed class CardFormChangeBuff : StandardBuff
    {
        public CardFormChangeBuff() : base(
            new Dictionary<GameCulture, string>()
            {
                { GameCulture.English, "Form Change" }
            },
            new Dictionary<GameCulture, string>()
            {
                { GameCulture.English, "You're wearing etherial armor!" }
            })
        {
        }


        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            base.ModifyBuffTip(ref tip, ref rare);

            FormChangeEtherialArmor etherialArmor = GetEtherialArmor(Main.LocalPlayer);

            tip += "\nCurrently wearing: " + etherialArmor.DisplayNames[Language.ActiveCulture];
            tip += "\nGaining " + etherialArmor.BonusArmor + " bonus armor";
        }

        public override void Update(Player player, ref int buffIndex)
        {
            FormChangeEtherialArmor etherialArmor = GetEtherialArmor(player);

            player.statDefense += etherialArmor.BonusArmor;
            etherialArmor.Update(POGPlayer.Get(player));
        }


        private FormChangeEtherialArmor GetEtherialArmor(Player player) =>
            FormChangeEtherialArmorLoader.Instance.FindGeneric(armor => armor.Conditions(player));


        private enum EtherialArmor
        {
            Molten,
            Chlorophyte,

            Solar,
            Vortex,
            Stardust,
            Nebula
        }
    }
}