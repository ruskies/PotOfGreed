using System.Collections.Generic;
using PotOfGreed.Cards.Behavior;
using Terraria.ID;
using Terraria.Localization;

namespace PotOfGreed.Cards.CardOfSafeReturn
{
    public sealed class CardCardOfSafeReturnDefinition : CardDefinition
    {
        public CardCardOfSafeReturnDefinition() : base("CardOfSafeReturn",
            new NormalCardSpecifications(
                new Dictionary<GameCulture, string>()
                {
                    { GameCulture.English, "Card of Safe Return" }
                },
                new Dictionary<GameCulture, string>()
                {
                    { GameCulture.English, "When used, teleports you back to your spawn point." }
                },
                3, rarity: ItemRarityID.Blue), 
            new DefaultNormalCardBehavior(pogPlayer =>
            {
                pogPlayer.player.Spawn();

                return true;
            }, 30, 40))
        {
        }
    }
}