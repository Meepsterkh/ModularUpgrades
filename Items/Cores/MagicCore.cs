using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ModLoader.IO;

namespace Modular.Items.Cores
{
    class MagicCore : Core
	{
		public int penetrate = 0;
		public int time = 0;
		public bool coldDamage = false;

		public override TagCompound Save()
		{
			return new TagCompound
			{
				{"Penetrate", penetrate},
				{"Time", time},
				{"ColdDamage", coldDamage},
				{"Damage", item.damage},
				{"ShootSpeed", item.shootSpeed},
				{"AutoReuse", item.autoReuse}
			};
		}

		public override void Load(TagCompound tag)
		{
			penetrate = tag.GetInt("Penetrate");
			time = tag.GetInt("Time");
			coldDamage = tag.GetBool("ColdDamage");
			item.damage = tag.GetInt("Damage");
			item.shootSpeed = tag.GetFloat("ShootSpeed");
			item.autoReuse = tag.GetBool("AutoReuse");
		}

		// NetSend and NetRecieve allow the countdownTimer value to be synced correctly even as the item is tossed out into the world and picked up by other players
		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(coldDamage);
			writer.Write(time);
			writer.Write(penetrate);
		}

		public override void NetRecieve(BinaryReader reader)
		{
			penetrate = reader.ReadInt32();
			time = reader.ReadInt32();
			coldDamage = reader.ReadBoolean();
		}

		public override bool Autoload(ref string name)
		{
			/*if (GetType() == typeof(Core))
			{
				return false;
			}
			return true;*/
			return false;
		}
	}
}
