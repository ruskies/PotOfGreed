using System.Collections.Generic;
using Terraria.ID;
using Terraria.Localization;

namespace PotOfGreed.Items.Cards
{
    public abstract class CardItem : PotOfGreedItem
    {
        protected CardItem(string displayName, string tooltip, int value = 0, int defense = 0, int rarity = 0, int maxStack = 999) : base(displayName, tooltip, 44, 64, value, defense, rarity, maxStack)
        {
        }

        protected CardItem(Dictionary<GameCulture, string> displayNames, Dictionary<GameCulture, string> tooltips, int width, int height, int value = 0, int defense = 0, int rarity = 0, int maxStack = 999) : base(displayNames, tooltips, width, height, value, defense, rarity, maxStack)
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.consumable = true;

            item.useStyle = ItemUseStyleID.HoldingOut;

            item.useTime = 15;
            item.useAnimation = 15;
        }
    }
}