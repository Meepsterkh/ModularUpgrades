using Modular.UI;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Modular.Items.Modifiers;

namespace Modular.Items.Cores
{
    class Core : ModItem
    {
        public int modifiedSlots = 0;
        public bool IsModified => modifiedSlots != 0;

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"ModifiedSlots", modifiedSlots}
            };
        }

        public override void Load(TagCompound tag)
        {
            modifiedSlots = tag.GetInt("ModifiedSlots");
        }

        // NetSend and NetRecieve allow the countdownTimer value to be synced correctly even as the item is tossed out into the world and picked up by other players
        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(modifiedSlots);
        }

        public override void NetRecieve(BinaryReader reader)
        {
            modifiedSlots = reader.ReadInt32();
        }
        private int coreType = 0;
        private Core TestCases(Core coreItem, Item modifierItem)
        {
            switch (coreType)
            {
                case 0: // new
                    if (coreItem is ToolCore core)
                    {
                        coreItem.SetToolModifiers(modifierItem, core);
                        coreType = 1;
                    }
                    else if (coreItem is MagicCore core1)
                    {
                        coreItem.SetMagicModifiers(modifierItem, core1);
                        coreType = 2;
                    }
                    break;
                case 1: // tools
                    if (!(coreItem is ToolCore))
                    {
                        return null;
                    }
                    coreItem.SetToolModifiers(modifierItem, (ToolCore)coreItem);
                    break;
                case 2: // magic
                    if (!(coreItem is MagicCore))
                    {
                        return null;
                    }
                    coreItem.SetMagicModifiers(modifierItem, (MagicCore)coreItem);
                    break;
            }
            return coreItem;
        }

        //Set modifiers on a core
        public Core SetModifiers(UIItemSlot[] modifierSlotArr)
        {

            // shortcut for core
            Core coreItem = this;
            // for each modifier slot
            for (int i = 0; i < modifierSlotArr.Length; i++)
            {
                Item modifierItem = modifierSlotArr[i].item;
                // if has a modifier
                if (!modifierItem.IsAir)
                {
                    // if is not a modifier
                    if (!(modifierItem.modItem is Modifier))
                    {
                        // Warn and leave
                        Main.NewText("Slot " + i++ + " is not a Modifier!!!", Microsoft.Xna.Framework.Color.OrangeRed);
                        break;
                    }

                    coreItem = TestCases(coreItem, modifierItem);
                }
            }

            // if modified return item
            if (coreItem.IsModified)
            {
                return coreItem;
            }
            // if not modified
            Main.NewText("Add Modifiers to Modify", Microsoft.Xna.Framework.Color.OrangeRed);
            return null;
        }

        // For Tools
        private void SetToolModifiers(Item modifier, ToolCore core)
        {

            // if has this modification
            if (modifier.pick != 0)
            {
                //modify this item
                core.item.pick = modifier.pick;
                //set modified to true
                core.modifiedSlots++;
            }
            else if (modifier.axe != 0)
            {
                core.item.axe = modifier.axe;
                core.modifiedSlots++;
            }
            else if (modifier.hammer != 0)
            {
                core.item.hammer = modifier.hammer;
                core.modifiedSlots++;
            }
        }

        // For Magic Weapons
        private void SetMagicModifiers(Item modifier, MagicCore core)
        {
            Main.NewText(modifier.Name);
            // Projectile coreProj = core.item.ammo;
            if (modifier.damage != 0)
            {
                core.item.damage = modifier.damage;
                core.modifiedSlots++;
            }
            else if (modifier.shootSpeed != 0)
            {
                core.item.shootSpeed = modifier.shootSpeed;
                core.modifiedSlots++;
            }
            else if (modifier.autoReuse)
            {
                core.item.autoReuse = modifier.autoReuse;
                core.modifiedSlots++;
            }
            else
            {
                Modifier mod = modifier.modItem as Modifier;
                Main.NewText(mod.time);
                if (mod.penetrate != 0)
                {
                    core.penetrate = mod.penetrate;
                    core.modifiedSlots++;
                }
                else if (mod.time != 0)
                {
                    core.time = mod.time;
                    core.modifiedSlots++;
                }
                else if (mod.coldDamage)
                {
                    core.coldDamage = mod.coldDamage;
                    core.modifiedSlots++;
                }
            }
        }
    }
}
