using System;

namespace PotOfGreed.Cards.Behavior
{
    [Flags]
    public enum NormalCardUseBehavior : byte
    {
        None = 0,
        Equip = 1,
        Use = 2,
        Consume = 4 | Use
    }
}