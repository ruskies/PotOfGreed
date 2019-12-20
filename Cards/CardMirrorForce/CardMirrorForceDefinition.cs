using System.Collections.Generic;
using PotOfGreed.Cards.Behavior;
using Terraria.ID;
using Terraria.Localization;

namespace PotOfGreed.Cards.CardMirrorForce
{
    public sealed class CardMirrorForceDefinition : CardDefinition
    {
        public CardMirrorForceDefinition() : base("MirrorForce",
            new NormalCardSpecifications(
                new Dictionary<GameCulture, string>()
                {
                    { GameCulture.English, "Mirror Force" }
                },
                new Dictionary<GameCulture, string>()
                {
                    { GameCulture.English, "When an opponent's monster declares an attack: Destroy all your opponent's Attack Position monsters." }
                },
                1, rarity: ItemRarityID.Pink),
            new CardMirrorForceNormalBehavior())
        {
        }
    }
}