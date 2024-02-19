using Microsoft.Xna.Framework;
using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Items;

public class ShadowLance : ModItem
{
    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Darkflame Lance");
        // base.Tooltip.SetDefault("Destroys your opponent's soul\nLeaves a trail of demon scythes\nThrown spear creates weaker demon scythes on enemy impact");
        Main.RegisterItemAnimation(base.Item.type, new DrawAnimationVertical(5, 6));
        ItemID.Sets.Spears[Type] = true;
    }

    public override void SetDefaults()
    {
        base.Item.damage = 42;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.width = 40;
        base.Item.height = 40;
        base.Item.useTime = 23;
        base.Item.useAnimation = 23;
        base.Item.knockBack = 7f;
        base.Item.value = 50000;
        base.Item.rare = 5;
        base.Item.shoot = base.Mod.Find<ModProjectile>("DarkflameSpearSpear").Type;
        base.Item.UseSound = SoundID.Item1;
        base.Item.autoReuse = true;
        base.Item.shootSpeed = 5.5f;
        base.Item.noMelee = true;
        base.Item.noUseGraphic = true;
        base.Item.useStyle = 5;
    }

    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("DarkflameSpearSpear").Type] < 1;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_0010: Unknown result type (might be due to invalid IL or missing references)
        SoundEngine.PlaySound(in SoundID.Item73, player.position);
        return true;
    }

    public override void AddRecipes()
    {
        Recipe recipe = base.CreateRecipe();
        recipe.AddIngredient(null, "MoltenJabber");
        recipe.AddIngredient(274);
        recipe.AddIngredient(521, 5);
        recipe.AddTile(16);
        recipe.Register();
    }
}
