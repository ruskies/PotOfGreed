using System;
using System.Collections.Generic;
using PotOfGreed.Players;
using Terraria;
using Terraria.Localization;

namespace PotOfGreed.Cards.CardFormChange.EtherialArmor
{
    public abstract class FormChangeEtherialArmor
    {
        protected FormChangeEtherialArmor(Dictionary<GameCulture, string> displayNames, int bonusArmor, Predicate<Player> condition)
        {
            DisplayNames = displayNames;
            BonusArmor = bonusArmor;
            Conditions = condition;
        }


        public virtual void Update(POGPlayer pogPlayer) { }


        public Dictionary<GameCulture, string> DisplayNames { get; }

        public int BonusArmor { get; }

        public Predicate<Player> Conditions { get; }
    }
}