using System.Collections.Generic;
using Terraria.Localization;
using WebmilioCommons.Items.Standard;

namespace PotOfGreed.Items
{
    public abstract class PotOfGreedItem : StandardItem
    {
        protected PotOfGreedItem(string displayName, string tooltip, int width, int height, int value = 0, int defense = 0, int rarity = 0, int maxStack = 999) : base(displayName, tooltip, width, height, value, defense, rarity, maxStack)
        {
        }

        protected PotOfGreedItem(Dictionary<GameCulture, string> displayNames, Dictionary<GameCulture, string> tooltips, int width, int height, int value = 0, int defense = 0, int rarity = 0, int maxStack = 999) : base(displayNames, tooltips, width, height, value, defense, rarity, maxStack)
        {
        }
    }
}