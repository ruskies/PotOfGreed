using System;
using System.Collections.Generic;
using PotOfGreed.Items.Cards;
using Terraria.ModLoader;
using WebmilioCommons.Loaders;

namespace PotOfGreed.Cards
{
    public sealed class CardDefinitionLoader : SingletonLoader<CardDefinitionLoader, CardDefinition>
    {
        private Dictionary<string, CardDefinition> _definitionsByName = new Dictionary<string, CardDefinition>();


        protected override void PostAdd(Mod mod, CardDefinition item, Type type)
        {
            _definitionsByName.Add(item.UnlocalizedName, item);
        }

        public override void PreLoad()
        {
            _definitionsByName = new Dictionary<string, CardDefinition>();
            ProxyCardItem.definitionsById = new Dictionary<int, CardDefinition>();
        }

        public override void Unload()
        {
            _definitionsByName = null;
            ProxyCardItem.definitionsById = default;
        }


        public CardDefinition GetGeneric(string unlocalizedName) => _definitionsByName[unlocalizedName];
    }
}