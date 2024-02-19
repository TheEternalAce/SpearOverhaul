using System;
using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace SpearOverhaul.Accessories;

public class HellknightGlove : ModItem
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Hellknight Gauntlet");
		// base.Tooltip.SetDefault("Melee damage increased by 15%\nGreatly increases spear size\nIncreases thrown spear velocity\nThrown spear penetration increased by 2\nMelee attacks light enemies ablaze");
		Main.RegisterItemAnimation(base.Item.type, new DrawAnimationVertical(7, 4));
	}

	public override void SetDefaults()
	{
		base.Item.width = 24;
		base.Item.height = 28;
		base.Item.value = 0;
		base.Item.rare = 4;
		base.Item.value = 30000;
		base.Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.GetModPlayer<GlobalPlayer>().spearSpeed += 0.25f;
		player.GetModPlayer<GlobalPlayer>().hellGlove = true;
		player.GetDamage(DamageClass.Melee) += 0.15f;
		player.ghostFrame = 3;
		player.ghostFade = 2.2f;
		player.GetModPlayer<GlobalPlayer>().spearDamage += (int)Math.Ceiling((double)((float)player.GetModPlayer<GlobalPlayer>().spearDamage * 0.12f));
	}

	public override void AddRecipes()
	{
		Recipe recipe = base.CreateRecipe();
		recipe.AddIngredient(null, "WarriorGlove");
		recipe.AddIngredient(175, 12);
		recipe.AddIngredient(154, 25);
		recipe.AddTile(16);
		recipe.Register();
	}
}
