using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular.Items.Modifiers.Magic
{
    class TimeModifier : Modifier
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Magic Modifier");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(40);
            item.maxStack = 99;
            item.value = 100;
            item.rare = ItemRarityID.Blue;
            item.damage = 0;
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            time = 2;
            return base.PreDrawInInventory(spriteBatch, position, frame, drawColor, itemColor, origin, scale);
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/

    }
}
