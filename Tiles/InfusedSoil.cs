using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Modular.Tiles
{
    class InfusedSoil : ModTile
    {
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileMerge[Type][mod.TileType("InfusedStone")] = true;
			Main.tileBlockLight[Type] = true;

			drop = ItemType<Items.Placeable.InfusedSoil>();

			AddMapEntry(new Color(20, 202, 148));
		}
	}
}
