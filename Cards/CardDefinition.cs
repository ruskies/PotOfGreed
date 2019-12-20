using System.Collections.Generic;
using PotOfGreed.Cards.Behavior;
using Terraria.Localization;
using WebmilioCommons.Managers;

namespace PotOfGreed.Cards
{
    public abstract class CardDefinition : IHasUnlocalizedName
    {
        protected CardDefinition(string unlocalized, NormalCardSpecifications specifications, NormalCardBehavior normalBehavior)
        {
            UnlocalizedName = unlocalized;

            NormalSpecifications = specifications;

            NormalBehavior = normalBehavior;
        }


        public string UnlocalizedName { get; }

        public NormalCardSpecifications NormalSpecifications { get; }

        public NormalCardBehavior NormalBehavior { get; }
    }
}