using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular.Items.Modifiers.Tools.Picks
{
    class CurruptPickModifier : Modifier
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightmare Modifier");
            Tooltip.SetDefault("Tool Modifier");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(40);
            item.maxStack = 1;
            item.value = 3600;
            item.rare = ItemRarityID.Blue;

            item.pick = 65;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 12);
            recipe.AddIngredient(ItemID.ShadowScale, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
