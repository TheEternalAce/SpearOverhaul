using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Items;

public class DemonSpear : ModItem
{
    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Demonslayer's Tollgate");
        // base.Tooltip.SetDefault("Casts a demonic blast of energy each time the spear is thrusted");
        ItemID.Sets.Spears[Type] = true;
    }

    public override void SetDefaults()
    {
        base.Item.CloneDefaults(280);
        base.Item.damage = 24;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.width = 40;
        base.Item.height = 40;
        base.Item.useTime = 27;
        base.Item.useAnimation = 27;
        base.Item.knockBack = 6.75f;
        base.Item.value = 15000;
        base.Item.rare = 3;
        base.Item.shoot = base.Mod.Find<ModProjectile>("DemonSpearSpear").Type;
        base.Item.UseSound = SoundID.Item1;
        base.Item.autoReuse = true;
        base.Item.shootSpeed = 5.5f;
        base.Item.noMelee = true;
        base.Item.noUseGraphic = true;
        base.Item.useStyle = 5;
    }

    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("DemonSpearSpear").Type] < 1;
    }

    public override void AddRecipes()
    {
        Recipe recipe = base.CreateRecipe();
        recipe.AddIngredient(null, "SpearHead");
        recipe.AddIngredient(57, 12);
        recipe.AddIngredient(86, 3);
        recipe.AddTile(16);
        recipe.Register();
    }
}
