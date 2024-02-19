using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.ThrownSpears;

public class MarbleSpearThrown : ModProjectile
{
	private int time;

	protected override bool CloneNewInstances => false;

	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Marble Spear");
	}

	public override void SetDefaults()
	{
		base.Projectile.aiStyle = 1;
		base.Projectile.timeLeft = 1200;
		base.Projectile.friendly = true;
		base.Projectile.hostile = false;
		base.Projectile.width = 16;
		base.Projectile.DamageType = DamageClass.Melee;
		base.Projectile.height = 16;
		base.Projectile.penetrate = 1;
		base.Projectile.ignoreWater = false;
		base.Projectile.tileCollide = true;
		base.Projectile.scale = 1.25f;
		base.Projectile.light = 0f;
		base.Projectile.DamageType = DamageClass.Melee;
		base.Projectile.extraUpdates = 1;
		base.DrawOriginOffsetY = -14;
		base.DrawOffsetX = -14;
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		_ = Main.player[Main.myPlayer];
		target.HasBuff(base.Mod.Find<ModBuff>("BloodDebuff").Type);
		if (target.HasBuff(base.Mod.Find<ModBuff>("BloodDebuff2").Type))
		{
			target.AddBuff(base.Mod.Find<ModBuff>("BloodDebuff3").Type, 180);
			target.AddBuff(base.Mod.Find<ModBuff>("BloodDebuff").Type, 240);
		}
		else if (target.HasBuff(base.Mod.Find<ModBuff>("BloodDebuff").Type))
		{
			target.AddBuff(base.Mod.Find<ModBuff>("BloodDebuff2").Type, 180);
			target.AddBuff(base.Mod.Find<ModBuff>("BloodDebuff").Type, 240);
		}
		target.AddBuff(base.Mod.Find<ModBuff>("BloodDebuff").Type, 240);
	}

	public override void AI()
	{
		if (Main.rand.Next(0, 2) == 1)
		{
			Dust dust = Dust.NewDustDirect(base.Projectile.position - new Vector2(base.Projectile.velocity.X * 2f, base.Projectile.velocity.Y * 2f), base.Projectile.height, base.Projectile.width, 204, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 0, default(Color), 1.2f);
			dust.velocity = base.Projectile.velocity / 2f;
			dust.noGravity = true;
		}
		if (Main.rand.Next(0, 2) == 1)
		{
			Dust dust2 = Dust.NewDustDirect(base.Projectile.position - new Vector2(base.Projectile.velocity.X * 2f, base.Projectile.velocity.Y * 2f), base.Projectile.height, base.Projectile.width, 63, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 0, default(Color), 1.2f);
			dust2.velocity = base.Projectile.velocity / 2f;
			dust2.noGravity = true;
		}
		_ = Main.player[Main.myPlayer];
		base.Projectile.rotation = base.Projectile.velocity.ToRotation() + MathHelper.ToRadians(45f);
		if (base.Projectile.spriteDirection == -1)
		{
			base.Projectile.rotation -= MathHelper.ToRadians(90f);
		}
		if (base.Projectile.timeLeft < 1150)
		{
			base.Projectile.velocity.X *= 0.97f;
			base.Projectile.aiStyle = 1;
			base.Projectile.velocity.Y += 0.17f;
		}
		else
		{
			base.Projectile.aiStyle = 0;
		}
	}

	public override void OnKill(int timeLeft)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		_ = Main.player[Main.myPlayer];
		SoundEngine.PlaySound(in SoundID.Dig, base.Projectile.position);
		for (int i = 0; i < 8; i++)
		{
			int num370 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 0, 0f, 0f, 7, default(Color), 1.5f);
			Main.dust[num370].velocity *= 1.4f;
			Main.dust[num370].noGravity = true;
		}
	}
}