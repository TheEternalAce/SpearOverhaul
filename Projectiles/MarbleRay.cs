using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Projectiles;

public class MarbleRay : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Purple Arrow");
		ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 4;
		ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		base.Projectile.width = 16;
		base.Projectile.DamageType = DamageClass.Melee;
		base.Projectile.height = 16;
		base.Projectile.aiStyle = 612;
		base.Projectile.friendly = true;
		base.Projectile.hostile = false;
		base.Projectile.DamageType = DamageClass.Magic;
		base.Projectile.penetrate = 3751057;
		base.Projectile.light = 0f;
		base.Projectile.ignoreWater = true;
		base.Projectile.extraUpdates = 1;
		base.Projectile.CloneDefaults(254);
		Main.projFrames[base.Projectile.type] = 4;
		base.Projectile.width = 36;
		base.Projectile.height = 36;
		base.Projectile.timeLeft = 15;
		base.Projectile.tileCollide = false;
		base.Projectile.alpha = 125;
		base.Projectile.scale = 0.75f;
	}

	public override void AI()
	{
		base.Projectile.velocity.X = 0f;
		base.Projectile.velocity.Y = 0f;
		base.Projectile.frameCounter++;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		return true;
	}
}
