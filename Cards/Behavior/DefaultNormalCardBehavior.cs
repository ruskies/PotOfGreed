using System;
using PotOfGreed.Players;

namespace PotOfGreed.Cards.Behavior
{
    public class DefaultNormalCardBehavior : NormalCardBehavior
    {
        private readonly Predicate<POGPlayer> _useItem;


        public DefaultNormalCardBehavior(Predicate<POGPlayer> useItem, int useTime = USE_TIME, int useAnimation = USE_TIME) : 
            base(NormalCardUseBehavior.Use | NormalCardUseBehavior.Consume, useTime: useTime, useAnimation: useAnimation)
        {
            _useItem = useItem;
        }


        public override bool UseItem(POGPlayer pogPlayer, CardDefinition definition) => _useItem(pogPlayer);
    }
}