using Microsoft.Xna.Framework;
using Modular.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Modular.Tiles
{
    class MeteoriteScrapForge : ModTile
	{
        private ModifierUI multiItemUI = new ModifierUI(2);

		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);

			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Meteorite Scrap Forge");
			AddMapEntry(new Color(102, 0, 204), name);
		}
		public override bool HasSmartInteract()
		{
			return true;
		}
		
		public void Close()
		{
			if (multiItemUI.GetActive())
			{
				Main.PlaySound(SoundID.MenuClose);
				multiItemUI.SetActive(false);
			}
			GetInstance<Modular>().ModifierAdditionInteraface.SetState(null);
		}
		public override bool NewRightClick(int i, int j)
		{
			if (multiItemUI.GetActive())
			{
				Close();
				return true;
			}

			Player player = Main.player[Main.myPlayer];
			Main.playerInventory = true;

			GetInstance<Modular>().ModifierAdditionInteraface.SetState(multiItemUI);
			multiItemUI.SetActive(true);

			Main.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);

			return true;
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
            base.NearbyEffects(i, j, closer);

			if (!PlayerInside(i, j))
            {
				Close();
			}

			if(!Main.playerInventory)
            {
				Close();
            }
		}

		public bool PlayerInside(int x, int y)
        {
			if ((x - 1) * 16 > Main.LocalPlayer.position.X + (7 * 16) || (x - 1) * 16 < Main.LocalPlayer.position.X - (7 * 16) ||
				y * 16 > Main.LocalPlayer.position.Y + (7 * 16) || y * 16 < Main.LocalPlayer.position.Y - (7 * 16))
			{
				return false;
			}
			return true;
		}

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
			Close();
            Item.NewItem(i * 16, j * 16, 40, 40, ItemType<Items.Placeable.MeteoriteScrapForge>());
        }
    }
}
