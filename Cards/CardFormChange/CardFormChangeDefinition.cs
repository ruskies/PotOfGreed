using System.Collections.Generic;
using PotOfGreed.Cards.Behavior;
using Terraria.ID;
using Terraria.Localization;
using WebmilioCommons;
using WebmilioCommons.Extensions;

namespace PotOfGreed.Cards.CardFormChange
{
    public sealed class CardFormChangeDefinition : CardDefinition
    {
        public CardFormChangeDefinition() : base("FormChange",
            new NormalCardSpecifications(
                new Dictionary<GameCulture, string>()
                {
                    { GameCulture.English, "Form Change" }
                }, 
                new Dictionary<GameCulture, string>()
                {
                    { GameCulture.English, "Temporarily gives you the best armor available at your stage of the game" }
                },
                1, rarity: ItemRarityID.Red),
            new DefaultNormalCardBehavior(pogPlayer =>
            {
                pogPlayer.player.AddBuff<CardFormChangeBuff>(Constants.TICKS_PER_SECOND * 20);

                return true;
            }))
        {
        }
    }
}