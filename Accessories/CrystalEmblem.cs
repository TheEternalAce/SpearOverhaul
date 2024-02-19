using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Accessories;

public class CrystalEmblem : ModItem
{
    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Crystal Emblem");
        // base.Tooltip.SetDefault("12% increased melee damage\n20% increased spear velocity\n8% increased melee critical strike chance\nLife regeneration greatly increased");
    }

    public override void SetDefaults()
    {
        base.Item.width = 24;
        base.Item.height = 28;
        base.Item.value = 0;
        base.Item.rare = ItemRarityID.Lime;
        base.Item.value = 20000;
        base.Item.accessory = true;
    }

    public override void UpdateAccessory(Player player, bool showVisual)
    {
        player.GetDamage(DamageClass.Melee) += 0.12f;
        player.GetModPlayer<GlobalPlayer>().spearSpeed += 0.2f;
        player.lifeRegen += 5;
        player.GetCritChance(DamageClass.Generic) += 8f;
    }

    public override void AddRecipes()
    {
        Recipe recipe = base.CreateRecipe();
        recipe.AddIngredient(null, "SpearEmblem");
        recipe.AddIngredient(null, "SpearCrystal");
        recipe.AddIngredient(null, "SawmillBox");
        recipe.AddTile(114);
        recipe.Register();
    }
}
