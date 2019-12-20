using System.Collections.Generic;
using Terraria.ID;
using Terraria.Localization;

namespace PotOfGreed.Cards
{
    public class NormalCardSpecifications
    {
        public NormalCardSpecifications(Dictionary<GameCulture, string> displayNames, Dictionary<GameCulture, string> tooltips, int maxInInventory, int maxUses = -1, int rarity = ItemRarityID.White)
        {
            DisplayNames = displayNames;
            Tooltips = tooltips;

            MaxInInventory = maxInInventory;

            if (maxUses == -1)
                maxUses = maxInInventory;

            MaxUses = maxUses;

            Rarity = rarity;
        }


        public Dictionary<GameCulture, string> DisplayNames { get; }
        public Dictionary<GameCulture, string> Tooltips { get; }

        public int MaxInInventory { get; }
        public int MaxUses { get; }

        public int Rarity { get; }
    }
}