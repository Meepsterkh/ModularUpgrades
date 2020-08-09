using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;


namespace Moduals
{
    public class ModualsWorld : ModWorld
    {

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (genIndex == -1)
            {
                return;
            }
            tasks.Insert(genIndex + 1, new PassLegacy("Custom Biome", delegate (GenerationProgress progress)
            {
                progress.Message = "Custom Biome Progress";
                for (int i = 0; i < Main.maxTilesX / 750; i++)
                {
                    int X = WorldGen.genRand.Next(1, Main.maxTilesX - 300);
                    int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer - 200, Main.maxTilesY - 300);
                    int TileType = mod.TileType("InfusedStone");

                    WorldGen.TileRunner(X, Y, 450, WorldGen.genRand.Next(100, 500), TileType);

                    /*for (int k = 0; k < 500; k++)
                    {
                        int Xo = X + Main.rand.Next(-200, 200);
                        int Yo = Y + Main.rand.Next(-200, 200);
                        int airType = 0;
                        if (Main.tile[Xo + 1, Yo].type != airType || Main.tile[Xo, Yo + 1].type != airType || Main.tile[Xo - 1, Yo].type != airType
                        || Main.tile[Xo, Yo - 1].type != airType)
                        {
                            if (Main.tile[Xo, Yo].type == TileType)
                            {
                                WorldGen.TileRunner(Xo, Yo, (double)WorldGen.genRand.Next(2, 2), WorldGen.genRand.Next(2, 2), mod.TileType("PlexusShard"));
                            }
                        }
                        
                    }*/
                    for (int k = 0; k < 200; k++)
                    {
                        int Xo = X + Main.rand.Next(-200, 200);
                        int Yo = Y + Main.rand.Next(-200, 200);
                        if (Main.tile[Xo, Yo].type == TileType)
                        {
                            WorldGen.TileRunner(Xo, Yo, (double)WorldGen.genRand.Next(4, 5), WorldGen.genRand.Next(5, 5), mod.TileType("PlexiyBlock"));
                        }
                    }
                    for (int k = 0; k < 50; k++)
                    {
                        int Xo = X + Main.rand.Next(-100, 100);
                        int Yo = Y + Main.rand.Next(-100, 100);
                        if (Main.tile[Xo, Yo].type == TileType)
                        {
                            WorldGen.TileRunner(Xo, Yo, (double)WorldGen.genRand.Next(20, 40), WorldGen.genRand.Next(10, 15), mod.TileType("InfusedSoil"));  //   5, 10 is how big is the ore veins.    mod.TileType("CustomOreTile") is the custom ore tile,  if u want a vanila ore just do this: TileID.Cobalt, for cobalt spawn
                        }
                    }
                }

            }));
        }
    }
}