using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Body })]
public class CrystalChestplate : ModItem
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Crystalized Cloak");
		// base.Tooltip.SetDefault("10% increased spear velocity\n5% increased melee damage and critical strike chance");
	}

	public override void SetDefaults()
	{
		base.Item.width = 18;
		base.Item.height = 18;
		base.Item.value = 55000;
		base.Item.rare = 6;
		base.Item.defense = 18;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetModPlayer<GlobalPlayer>().spearSpeed += 0.1f;
		player.GetDamage(DamageClass.Melee) += 0.05f;
		player.GetCritChance(DamageClass.Generic) += 5f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = base.CreateRecipe();
		recipe.AddIngredient(391, 10);
		recipe.AddIngredient(502, 10);
		recipe.AddIngredient(520, 5);
		recipe.AddTile(134);
		recipe.Register();
		Recipe recipe2 = base.CreateRecipe();
		recipe2.AddIngredient(1198, 10);
		recipe2.AddIngredient(502, 10);
		recipe2.AddIngredient(520, 5);
		recipe2.AddTile(134);
		recipe2.Register();
	}
}
