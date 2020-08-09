using System.IO;
using Terraria.ModLoader.IO;

namespace Modular.Items.Cores
{
    class ToolCore : Core
	{
		public override TagCompound Save()
		{
			return new TagCompound
			{
				{"Pick", item.pick},
				{"Axe", item.axe},
				{"Hammer", item.hammer},
				{"Damage", item.damage},
				{"LifeRegen", item.lifeRegen}
			};
		}

		public override void Load(TagCompound tag)
		{
			item.pick = tag.GetInt("Pick");
			item.axe  = tag.GetInt("Axe");
			item.hammer = tag.GetInt("Hammer");
			item.damage = tag.GetInt("Damage");
			item.lifeRegen = tag.GetInt("LifeRegen");
		}

		public override bool Autoload(ref string name)
		{
			if (GetType() == typeof(ToolCore))
			{
				return false;
			}
			return true;
		}
	}
}
