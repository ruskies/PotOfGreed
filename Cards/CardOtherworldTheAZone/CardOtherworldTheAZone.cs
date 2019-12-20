using System.Collections.Generic;
using PotOfGreed.Cards.Behavior;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace PotOfGreed.Cards.CardOtherworldTheAZone
{
    public sealed class CardOtherworldTheAZone : CardDefinition
    {
        public CardOtherworldTheAZone() : base("OtherworldTheAZone",
            new NormalCardSpecifications(
                new Dictionary<GameCulture, string>()
                {
                    { GameCulture.English, "Otherworld - The \"A\" Zone" }
                }, 
                new Dictionary<GameCulture, string>()
                {
                    { GameCulture.English, "Summons outworldly enemies" }
                }, 1, rarity: ItemRarityID.Cyan),
            new DefaultNormalCardBehavior(pogPlayer =>
            {
                WorldGen.TriggerLunarApocalypse();
                NPC.LunarApocalypseIsUp = false;

                return true;
            }))
        {
        }
    }
}
