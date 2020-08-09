using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Modular.Tiles
{
    class InfusedStone : ModTile
    {
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileMerge[Type][mod.TileType("InfusedSoil")] = true;
			Main.tileStone[Type] = true;
			Main.tileBlockLight[Type] = true;

			drop = ItemType<Items.Placeable.InfusedStone>();
			soundType = SoundID.Tink;

			AddMapEntry(new Color(255, 94, 15));
		}
	}
}
