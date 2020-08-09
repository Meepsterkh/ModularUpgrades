using IL.Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular.Items
{
    class DevTool : ModItem
    {
        public override void SetDefaults()
        {
            item.Size = new Vector2(40);
            item.rare = ItemRarityID.Red;
            item.value = 999999;

            item.autoReuse = true;
            item.useTime = 3;
            item.useAnimation = 25;
            item.useTurn = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;

            item.damage = 500000;
            item.melee = true;

            item.axe = 500;
            item.hammer = 500;
            item.pick = 500;
        }
    }
}
