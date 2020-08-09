using System.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Modular.Items.Modifiers
{
    class Modifier : ModItem
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
				{"ColdDamage", coldDamage}
			};
		}

		public override void Load(TagCompound tag)
		{
			penetrate = tag.GetInt("Penetrate");
			time = tag.GetInt("Time");
			coldDamage = tag.GetBool("ColdDamage");
		}

		// NetSend and NetRecieve allow the countdownTimer value to be synced correctly even as the item is tossed out into the world and picked up by other players
		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(penetrate);
			writer.Write(time);
			writer.Write(coldDamage);
		}

		public override void NetRecieve(BinaryReader reader)
		{
			penetrate = reader.ReadInt32();
			time = reader.ReadInt32();
			coldDamage = reader.ReadBoolean();
		}

		public override bool Autoload(ref string name)
		{
			if (GetType() == typeof(Modifier))
			{
				return false;
			}
			return true;
		}
	}
}
