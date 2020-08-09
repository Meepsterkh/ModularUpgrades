﻿using Microsoft.Xna.Framework;
using Modular.Projectiles;
using Terraria;
using Terraria.ID;

namespace Modular.Items.Cores.Magic
{
    class TestMagicCore : MagicCore
    {
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.HoldingOut;   //The way your Weapon will be used, 1 is the regular sword swing for example
            item.noMelee = true; //so the item's animation doesn't do damage

            item.magic = true;
            item.mana = 1;
            item.damage = 19;
            item.width = 42;
            item.height = 16;
            item.useTime = 6;   //How fast the Weapon is used.
            item.useAnimation = 20;     //How long the Weapon is used for.
            item.knockBack = 3.25f;
            item.UseSound = SoundID.Item34;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.shootSpeed = 4.5f; //This defines the projectile speed when shoot , for flamethrower this make how far the flames can go

            MainMagicProj moddedProj = new MainMagicProj();
            // moddedProj.SetColor(new Color(new Vector3(0, 0, 0)));
            // moddedProj.SetLighting(0f, 0f, 0f);
            item.shoot = moddedProj.projectile.type;
        }
    }
}