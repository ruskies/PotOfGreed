using Extensions;
using PotOfGreed.Players;
using Terraria.ID;

namespace PotOfGreed.Cards.Behavior
{
    public abstract class NormalCardBehavior
    {
        public const int USE_TIME = 15;


        protected NormalCardBehavior(NormalCardUseBehavior useBehavior, 
            int useStyle = ItemUseStyleID.HoldingUp, int useTime = USE_TIME, int useAnimation = USE_TIME)
        {
            UseBehavior = useBehavior;

            UseStyle = useStyle;
            UseTime = useTime;
            UseAnimation = useAnimation;
        }


        public virtual bool CanUseItem(POGPlayer pogPlayer) => UseBehavior.Has(NormalCardUseBehavior.Use);

        public virtual bool UseItem(POGPlayer pogPlayer) => true;


        public NormalCardUseBehavior UseBehavior { get; }


        public int UseStyle { get; }
        public int UseTime { get; }
        public int UseAnimation { get; }
    }
}