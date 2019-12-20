using Microsoft.Xna.Framework.Input;
using PotOfGreed.Cards;
using PotOfGreed.Items.Cards;
using Terraria.ModLoader;

namespace PotOfGreed
{
	public class PotOfGreed : Mod
	{
		public PotOfGreed()
        {
            Instance = this;
        }


        public override void Load()
        {
            for (int i = CardDefinitionLoader.Instance.FirstIndex; i < CardDefinitionLoader.Instance.NextIndex; i++)
            {
                CardDefinition definition = CardDefinitionLoader.Instance.GetGeneric(i);

                ProxyCardItem card = new ProxyCardItem(definition);
                AddItem(card.AutoloadName, card);
            }
        }


        public override void Unload()
        {
            Instance = null;
        }


        public static PotOfGreed Instance { get; private set; }
    }
}