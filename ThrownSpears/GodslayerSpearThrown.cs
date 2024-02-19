using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.ThrownSpears;

public class GodslayerSpearThrown : ModProjectile
{
    private int time;

    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("God's Spear");
    }

    public override void SetDefaults()
    {
        base.Projectile.aiStyle = 1;
        base.Projectile.timeLeft = 1200;
        base.Projectile.friendly = true;
        base.Projectile.hostile = false;
        base.Projectile.width = 48;
        base.Projectile.DamageType = DamageClass.Melee;
        base.Projectile.height = 12;
        base.Projectile.penetrate = 1;
        base.Projectile.ignoreWater = false;
        base.Projectile.tileCollide = true;
        base.Projectile.scale = 1.25f;
        base.Projectile.light = 0f;
        base.Projectile.DamageType = DamageClass.Melee;
        base.Projectile.extraUpdates = 1;
        base.DrawOriginOffsetY = -32;
        base.DrawOriginOffsetX = 0f;
    }

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        //IL_00f3: Unknown result type (might be due to invalid IL or missing references)
        Projectile.NewProjectile(target.GetSource_Death(), target.Center.X - 70f, target.Center.Y - 35f, 0f, 0f, base.Mod.Find<ModProjectile>("LightExplosion").Type, 0, Projectile.knockBack, Main.LocalPlayer.whoAmI);
        Projectile.NewProjectile(target.GetSource_Death(), target.Center.X - 70f, target.Center.Y - 35f, base.Projectile.velocity.X, base.Projectile.velocity.Y, base.Mod.Find<ModProjectile>("Explosion").Type, Projectile.damage, Projectile.knockBack, Main.LocalPlayer.whoAmI);
        SoundEngine.PlaySound(in SoundID.Item89, base.Projectile.position);
        for (int i = 0; i < 12; i++)
        {
            Dust dust = Dust.NewDustDirect(base.Projectile.Center, base.Projectile.height, base.Projectile.width, 228, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 200, default(Color), 1.5f);
            dust.velocity = base.Projectile.velocity * 2f;
            dust.velocity *= 0.5f;
        }
        if (Main.rand.Next(0, 3) == 1)
        {
            target.AddBuff(69, 300);
        }
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
            Dust dust = Dust.NewDustDirect(base.Projectile.position, base.Projectile.width, base.Projectile.height, 57, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 0, default(Color), 1.25f);
            dust.velocity *= 0f;
            dust.noGravity = true;
            dust.scale = (float)Main.rand.Next(90, 125) * 0.013f;
            Dust dust2 = Dust.NewDustDirect(base.Projectile.position, base.Projectile.width, base.Projectile.height, 228, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 0, default(Color), 1.5f);
            dust2.velocity *= 0f;
            dust2.noGravity = true;
            dust2.scale = (float)Main.rand.Next(90, 125) * 0.013f;
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
        for (int i = 0; i < 12; i++)
        {
            int num372 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 7, 0f, 0f, 100);
            Main.dust[num372].noGravity = true;
            Main.dust[num372].velocity *= 2f;
            int dust1 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 228, 1f, 1f, 0, default(Color), 2f);
            Main.dust[dust1].velocity *= Main.rand.NextFloat(6f, 8f);
            Main.dust[dust1].noGravity = true;
        }
    }
}
