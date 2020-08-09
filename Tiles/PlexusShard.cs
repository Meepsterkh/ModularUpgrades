using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Modular.Tiles
{
    class PlexusShard : ModTile
    {
		public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;

            //Tile Foundation
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);

            TileObjectData.newTile.AnchorValidTiles = new int[]
            {
                TileID.Stone,
                TileID.IceBlock,
                TileID.Ebonstone,
                TileID.Pearlstone,
                TileID.Crimstone,
                TileType<InfusedStone>()
            };

            //From Ceiling
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.StyleHorizontal = true;
            // TileObjectData.newTile.RandomStyleRange = 6;
            TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { 124 };
            // TileObjectData.newAlternate.DrawFlipVertical = true;
            /*TileObjectData.newAlternate.Origin = new Point16(0, 0);*/
            TileObjectData.newAlternate.AnchorLeft = AnchorData.Empty;
            TileObjectData.newAlternate.AnchorRight = AnchorData.Empty;
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
            // TileObjectData.newAlternate.StyleHorizontal = false;
            TileObjectData.addAlternate(1);

            //From Left
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.StyleHorizontal = true;
            TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { 124 };
            /*TileObjectData.newAlternate.Origin = new Point16(0, 0);*/
            TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
            TileObjectData.addAlternate(2);

            //From Right
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.StyleHorizontal = true;
            TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { 124 };
            /*TileObjectData.newAlternate.Origin = new Point16(0, 0);*/
            TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
            TileObjectData.addAlternate(3);

            //From Ground
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.StyleHorizontal = true;
            // TileObjectData.newTile.RandomStyleRange = 6;
            TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { 124 };
            /*TileObjectData.newAlternate.Origin = new Point16(0, 0);*/
            TileObjectData.addAlternate(4);

            /*TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.RandomStyleRange = 6;*/


            TileObjectData.addTile(Type);

            drop = ItemType<Items.Placeable.PlexusShard>();
            AddMapEntry(new Color(204, 51, 255));

        }
	}
}
