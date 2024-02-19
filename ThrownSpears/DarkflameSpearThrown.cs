using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.ThrownSpears;

public class DarkflameSpearThrown : ModProjectile
{
	private int time;

	protected override bool CloneNewInstances => false;

	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Darkflame Spear");
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
		base.DrawOriginOffsetY = -21;
		base.DrawOffsetX = -21;
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		_ = Main.player[Main.myPlayer];
		int proj = Projectile.NewProjectile(target.GetSource_Death(), base.Projectile.position, new Vector2(0f, 0f), 45, base.Projectile.damage / 3, 0f, base.Projectile.owner);
		Main.projectile[proj].timeLeft = 60;
		Main.projectile[proj].scale = 0.75f;
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
		Dust dust = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 65, base.Projectile.velocity.X * 0.4f, base.Projectile.velocity.Y * 0.4f, 0, default(Color), 1.5f);
		dust.velocity = base.Projectile.velocity / 2f;
		dust.noGravity = true;
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