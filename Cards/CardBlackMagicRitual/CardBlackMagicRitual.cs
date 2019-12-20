using System.Collections.Generic;
using PotOfGreed.Cards.Behavior;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace PotOfGreed.Cards.CardBlackMagicRitual
{
    public sealed class CardBlackMagicRitual : CardDefinition
    {
        public CardBlackMagicRitual() : base("BlackMagicRitual",
            new NormalCardSpecifications(
                new Dictionary<GameCulture, string>()
                {
                    { GameCulture.English, "Black Magic Ritual" }
                }, 
                new Dictionary<GameCulture, string>()
                {
                    { GameCulture.English, "Summons Satan" }
                }, 1, rarity: ItemRarityID.Cyan),
            new DefaultNormalCardBehavior(pogPlayer =>
            {
                NPC.NewNPC((int) pogPlayer.player.position.X, (int) pogPlayer.player.position.Y, NPCID.CultistBoss);

                return true;
            }))
        {
        }
    }
}