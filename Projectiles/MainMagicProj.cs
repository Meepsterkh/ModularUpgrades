using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Modular.Items.Cores;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular.Projectiles       //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class MainMagicProj : ModProjectile
    {
        public override void SetDefaults()
        {
            // projectile.name = "Custom Flamethrower"; //Name of the projectile, only shows this if you get killed by it
            projectile.width = 12;  //Set the hitbox width
            projectile.height = 12; //Set the hitbox height
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.ignoreWater = true;  //Tells the game whether or not projectile will be affected by water
            projectile.ranged = true;  //Tells the game whether it is a ranged projectile or not
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed, -1 infinity
            projectile.timeLeft = 200;  //The amount of time the projectile is alive for  
           //  projectile.extraUpdates = 3;
        }
        private int num = 0;
        private Color color = default;
        public void SetColor(Color newColor)
        {
            Main.NewText("color: " + num++);
            color = newColor;
        }

        private bool lightingChanged = false;
        private float[] RGB = new float[3];
        public void SetLighting(float RPercent, float GPercent, float BPercent)
        {
            Main.NewText("lighting: " + num++);
            RGB[0] = RPercent;
            RGB[1] = GPercent;
            RGB[2] = BPercent;
            lightingChanged = true;
        }

        public override void AI()
        {
            Main.NewText("ree: " + num++);
            ChangeProperties();

            if(!lightingChanged)
            {
                Lighting.AddLight(projectile.Center,
                   ((255 - projectile.alpha) * 0.15f) / 255f,  // R
                   ((255 - projectile.alpha) * 0.45f) / 255f,  // G
                   ((255 - projectile.alpha) * 0.05f) / 255f); // B
            }
            else
            {
                Lighting.AddLight(projectile.Center,
                   ((255 - projectile.alpha) * RGB[0]) / 255f,  // R
                   ((255 - projectile.alpha) * RGB[1]) / 255f,  // G
                   ((255 - projectile.alpha) * RGB[2]) / 255f); // B
            }
            if (projectile.timeLeft > 125)
            {
                projectile.timeLeft = 125;
            }
            if (projectile.ai[0] > 12f)  //this defines where the flames starts
            {
                if (Main.rand.Next(3) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.PinkFlame, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, color, 3.75f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 2.5f;
                    // int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.PinkFlame, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, color, 1.5f); //this defines the flames dust and color parcticles, like when they fall thru ground, change DustID to wat dust you want from Terraria
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            return;
        }
        private bool played = false;
        private void ChangeProperties()
        {
            Main.NewText("ree: " + num++);
            if (!played)
            {
                Main.NewText("ree: " + num++);
                Item tempItem = Main.LocalPlayer.inventory[Main.LocalPlayer.selectedItem];
                // Main.NewText(temp.Name);

                MagicCore core = (MagicCore)tempItem.modItem;
                /*MagicCore temp = new MagicCore();
                temp = mod.ItemType("TestMagicCore");
                MagicCore core = (MagicCore)temp.modItem;
                */
                if (core != null)
                {
                    if (core.penetrate != 0)
                    {
                        projectile.penetrate = core.penetrate;
                    }
                    if (core.time != 0)
                    {
                        // Main.NewText("Old Time Left: " + projectile.timeLeft + "\nNew Time Left: " + core.time);
                        projectile.timeLeft = core.time;
                        // Main.NewText("Changed: " + projectile.timeLeft);
                    }
                    if (core.coldDamage)
                    {
                        projectile.coldDamage = core.coldDamage;
                    }
                }
                played = true;
            }
        }


        /*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 80);   //this make so when the projectile/flame hit a npc, gives it the buff  onfire , 80 = 3 seconds
        }*/

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}