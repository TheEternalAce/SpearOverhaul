using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Projectiles;

public class DemonEnergyBall : ModProjectile
{
	private int dust_num = 65;

	private int dust_num2 = 14;

	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Demon Energy Ball");
		ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		base.Projectile.width = 7;
		base.Projectile.height = 10;
		base.Projectile.aiStyle = 1;
		base.Projectile.DamageType = DamageClass.Magic;
		base.Projectile.friendly = true;
		base.Projectile.hostile = false;
		base.Projectile.penetrate = 3;
		base.Projectile.timeLeft = 600;
		base.Projectile.light = 0f;
		base.Projectile.ignoreWater = true;
		base.Projectile.tileCollide = true;
		base.Projectile.extraUpdates = 6;
	}

	public override void AI()
	{
		base.Projectile.aiStyle = 0;
		int dust = Dust.NewDust(new Vector2(base.Projectile.position.X - base.Projectile.velocity.X, base.Projectile.position.Y), 0, 0, this.dust_num);
		Main.dust[dust].velocity *= 0f;
		Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * 0.013f;
		Main.dust[dust].noGravity = true;
	}

	public override void OnKill(int timeLeft)
	{
		for (int i = 0; i < 8; i++)
		{
			Vector2 position = base.Projectile.position;
			int dust = Dust.NewDust(position, 1, 1, this.dust_num);
			Main.dust[dust].velocity *= 3f;
			Main.dust[dust].scale = (float)Main.rand.Next(115, 155) * 0.013f;
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(position, 1, 1, this.dust_num2);
			Main.dust[dust2].velocity *= 3f;
			Main.dust[dust2].scale = (float)Main.rand.Next(115, 155) * 0.013f;
			Main.dust[dust2].noGravity = true;
		}
	}
}
