using System.Collections.Generic;
using PotOfGreed.Cards.Behavior;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace PotOfGreed.Cards.CardForest
{
    public sealed class CardForestDefinition : CardDefinition
    {
        public CardForestDefinition() : base("Forest",
            new NormalCardSpecifications(
                new Dictionary<GameCulture, string>()
                {
                    { GameCulture.English, "Forest" }
                },
                new Dictionary<GameCulture, string>()
                {
                    { GameCulture.English, "Summons trees around the player" }
                }, 10, rarity: ItemRarityID.Blue),
            new DefaultNormalCardBehavior(pogPlayer =>
            {
                int
                    playerX = (int)pogPlayer.player.position.X / 16,
                    playerY = (int)pogPlayer.player.position.Y / 16;

                for (int i = playerX - 16; i < playerX + 16; i++)
                    for (int j = playerY - 16; j < playerY + 16; j++)
                        WorldGen.GrowTree(i, j);

                return true;
            }))
        {
        }
    }
}
