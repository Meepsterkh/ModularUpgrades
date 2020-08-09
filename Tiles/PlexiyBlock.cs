using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Modular.Tiles
{
    class PlexiyBlock : ModTile
    {
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true; 
			drop = ItemType<Items.Placeable.PlexiyBlock>();
			AddMapEntry(new Color(0, 51, 255));
		}
	}
}
