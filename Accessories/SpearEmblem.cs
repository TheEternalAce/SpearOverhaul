using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Accessories;

public class SpearEmblem : ModItem
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Spear Emblem");
		// base.Tooltip.SetDefault("15% increased spear velocity");
	}

	public override void SetDefaults()
	{
		base.Item.width = 24;
		base.Item.height = 28;
		base.Item.value = 0;
		base.Item.rare = 4;
		base.Item.value = 20000;
		base.Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.GetModPlayer<GlobalPlayer>().spearSpeed += 0.15f;
	}
}
