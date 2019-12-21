using Extensions;
using PotOfGreed.Players;
using Terraria.ID;

namespace PotOfGreed.Cards.Behavior
{
    public abstract class NormalCardBehavior
    {
        public const int USE_TIME = 30;


        protected NormalCardBehavior(NormalCardUseBehavior useBehavior, 
            int useStyle = ItemUseStyleID.HoldingUp, int useTime = USE_TIME, int useAnimation = USE_TIME)
        {
            UseBehavior = useBehavior;

            UseStyle = useStyle;
            UseTime = useTime;
            UseAnimation = useAnimation;
        }


        public virtual bool CanUseItem(POGPlayer pogPlayer, CardDefinition definition) => 
            UseBehavior.Has(NormalCardUseBehavior.Use) && pogPlayer.NormalCanUseCard(definition);

        public virtual bool UseItem(POGPlayer pogPlayer, CardDefinition definition) => true;


        public NormalCardUseBehavior UseBehavior { get; }


        public int UseStyle { get; }
        public int UseTime { get; }
        public int UseAnimation { get; }
    }
}