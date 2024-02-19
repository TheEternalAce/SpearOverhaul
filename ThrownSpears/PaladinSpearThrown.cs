using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.ThrownSpears;

public class PaladinSpearThrown : ModProjectile
{
    private int dust_num = 228;

    private int dust_num2 = 6;

    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Sand Proj2");
        ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 5;
        ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
    }

    public override void SetDefaults()
    {
        base.Projectile.width = 64;
        base.Projectile.height = 64;
        base.Projectile.DamageType = DamageClass.Magic;
        base.Projectile.penetrate = 4;
        base.Projectile.friendly = true;
        base.Projectile.hostile = false;
        base.Projectile.aiStyle = 3;
        base.Projectile.tileCollide = false;
        base.Projectile.extraUpdates = 1;
        base.Projectile.timeLeft = 300;
        base.DrawOffsetX = -9;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        return false;
    }

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (hit.Crit)
        {
            Player localPlayer = Main.LocalPlayer;
            localPlayer.statLife += 2;
            localPlayer.HealEffect(2);
        }
    }

    public override void AI()
    {
        base.Projectile.rotation = base.Projectile.velocity.ToRotation() + MathHelper.ToRadians(45f);
        if (base.Projectile.spriteDirection == -1)
        {
            base.Projectile.rotation -= MathHelper.ToRadians(90f);
        }
        Dust dust = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 228, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 0, default(Color), 1.2f);
        dust.velocity = base.Projectile.velocity / 2f;
        dust.noGravity = true;
    }

    public override void OnKill(int timeLeft)
    {
        Player p = Main.player[base.Projectile.owner];
        Projectile.NewProjectile(base.Projectile.GetSource_Death(), base.Projectile.position.X + 24f, base.Projectile.position.Y + 8f, 0f, 0f, base.Mod.Find<ModProjectile>("Explosion").Type, base.Projectile.damage, 0f, p.whoAmI);
        for (int num369 = 0; num369 < 16; num369++)
        {
            int num370 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 228, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num370].velocity *= 1.4f;
            Main.dust[num370].noGravity = true;
        }
        for (int num371 = 0; num371 < 10; num371++)
        {
            int num372 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 228, 0f, 0f, 100, default(Color), 2.5f);
            Main.dust[num372].noGravity = true;
            Main.dust[num372].velocity *= 5f;
        }
    }
}
