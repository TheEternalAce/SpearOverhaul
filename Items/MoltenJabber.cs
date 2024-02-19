using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Items;

public class MoltenJabber : ModItem
{
    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Hellknight Thruster");
        // base.Tooltip.SetDefault("Has a chance to burn enemies");
        ItemID.Sets.Spears[Type] = true;
    }

    public override void SetDefaults()
    {
        base.Item.damage = 29;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.width = 40;
        base.Item.height = 40;
        base.Item.useTime = 22;
        base.Item.useAnimation = 22;
        base.Item.knockBack = 7f;
        base.Item.value = 30000;
        base.Item.rare = 4;
        base.Item.shoot = base.Mod.Find<ModProjectile>("MoltenJabberSpear").Type;
        base.Item.UseSound = SoundID.Item1;
        base.Item.autoReuse = true;
        base.Item.shootSpeed = 5.33f;
        base.Item.noMelee = true;
        base.Item.noUseGraphic = true;
        base.Item.useStyle = 5;
    }

    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("MoltenJabberSpear").Type] < 1;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_000b: Unknown result type (might be due to invalid IL or missing references)
        SoundEngine.PlaySound(in SoundID.Item73, position);
        return true;
    }

    public override void AddRecipes()
    {
        Recipe recipe = base.CreateRecipe();
        recipe.AddIngredient(null, "SpearHead");
        recipe.AddIngredient(175, 18);
        recipe.AddIngredient(154, 5);
        recipe.AddTile(16);
        recipe.Register();
    }
}
