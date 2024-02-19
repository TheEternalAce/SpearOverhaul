//using Microsoft.Xna.Framework;
//using SpearOverhaul.GlobalStuff;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace SpearOverhaul.SpearProjectiles;
public class CrystalCrusherSpear : SpearBase
{
    private bool hit;

    protected override float HoldoutRangeMax => 160;

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        for (int i = 0; i < Main.rand.Next(1, 2); i++)
        {
            if (!this.hit)
            {
                new Vector2(Projectile.velocity.X, Projectile.velocity.Y).RotatedByRandom(MathHelper.ToRadians(360f));
                int proj = Projectile.NewProjectile(target.GetSource_Death(), Projectile.Center, Projectile.velocity * 3f, 522, Projectile.damage / 2, Projectile.knockBack, Main.LocalPlayer.whoAmI);
                Main.projectile[proj].penetrate = 3;
                this.hit = true;
            }
        }
        _ = Main.player[Projectile.owner];
        if (Main.rand.NextBool(2))
        {
            target.AddBuff(24, 120);
        }
    }

    public override bool PreAI()
    {
        Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, DustID.ShadowbeamStaff, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 1f, 0, default, 1.2f);
        dust.velocity += Projectile.velocity;
        dust.noGravity = true;
        dust.scale = Main.rand.Next(150, 216) * 0.013f;
        Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, DustID.BubbleBurst_Purple, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 1f, 0, default, 1.2f);
        dust2.velocity += Projectile.velocity;
        Player projOwner = Main.player[Projectile.owner];
        Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, reverseRotation: true);
        Projectile.direction = projOwner.direction;
        projOwner.heldProj = Projectile.whoAmI;
        projOwner.itemTime = projOwner.itemAnimation;
        Projectile.position.X = ownerMountedCenter.X - ((Projectile.width / 2) + Projectile.velocity.X * 8f);
        Projectile.position.Y = ownerMountedCenter.Y - ((Projectile.height / 2) + Projectile.velocity.Y * 8f);
        dust2.noGravity = true;
        return base.PreAI();
    }
}
//public class CrystalCrusherSpear : ModProjectile
//{
//    private bool jab;

//    private int timer = 9;

//    private bool hit;

//    private bool moveBack;

//    public float movementFactor
//    {
//        get
//        {
//            return base.Projectile.ai[0] - 1.25f;
//        }
//        set
//        {
//            base.Projectile.ai[0] = value;
//        }
//    }

//    public override void SetStaticDefaults()
//    {
//        // base.DisplayName.SetDefault("Darkflame Spear");
//        ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 5;
//        ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
//    }

//    public override void SetDefaults()
//    {
//        base.Projectile.width = 28;
//        base.Projectile.height = 24;
//        base.Projectile.aiStyle = 19;
//        base.Projectile.penetrate = -1;
//        base.Projectile.scale = 1.25f;
//        base.Projectile.alpha = 0;
//        base.Projectile.hide = true;
//        base.Projectile.ownerHitCheck = true;
//        base.Projectile.DamageType = DamageClass.Melee;
//        base.Projectile.tileCollide = false;
//        base.Projectile.friendly = true;
//        base.Projectile.timeLeft = 60;
//    }

//    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
//    {
//        for (int i = 0; i < Main.rand.Next(1, 2); i++)
//        {
//            if (!this.hit)
//            {
//                new Vector2(base.Projectile.velocity.X, base.Projectile.velocity.Y).RotatedByRandom(MathHelper.ToRadians(360f));
//                int proj = Projectile.NewProjectile(target.GetSource_Death(), base.Projectile.position, base.Projectile.velocity * 3f, 522, base.Projectile.damage / 2, base.Projectile.knockBack, Main.LocalPlayer.whoAmI);
//                Main.projectile[proj].penetrate = 3;
//                this.hit = true;
//            }
//        }
//        _ = Main.player[base.Projectile.owner];
//        if (Main.rand.Next(0, 2) == 1)
//        {
//            target.AddBuff(24, 120);
//        }
//        this.jab = true;
//    }

//    public override void AI()
//    {
//        this.timer++;
//        Dust dust = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 173, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 1f, 0, default(Color), 1.2f);
//        dust.velocity += base.Projectile.velocity;
//        dust.noGravity = true;
//        dust.scale = (float)Main.rand.Next(150, 216) * 0.013f;
//        Dust dust2 = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 179, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 1f, 0, default(Color), 1.2f);
//        dust2.velocity += base.Projectile.velocity;
//        Player projOwner = Main.player[base.Projectile.owner];
//        Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, reverseRotation: true);
//        base.Projectile.direction = projOwner.direction;
//        projOwner.heldProj = base.Projectile.whoAmI;
//        projOwner.itemTime = projOwner.itemAnimation;
//        base.Projectile.position.X = ownerMountedCenter.X - ((float)(base.Projectile.width / 2) + base.Projectile.velocity.X * 8f);
//        base.Projectile.position.Y = ownerMountedCenter.Y - ((float)(base.Projectile.height / 2) + base.Projectile.velocity.Y * 8f);
//        dust2.noGravity = true;
//        if (!projOwner.frozen)
//        {
//            if (this.movementFactor == 0f)
//            {
//                this.movementFactor = 1f;
//                base.Projectile.netUpdate = true;
//            }
//            if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
//            {
//                this.movementFactor -= 0.22f;
//                this.moveBack = true;
//            }
//            else
//            {
//                this.movementFactor += 2.55f + base.Projectile.scale / 1f;
//            }
//        }
//        base.Projectile.position += base.Projectile.velocity * this.movementFactor;
//        if (projOwner.itemAnimation == 0)
//        {
//            base.Projectile.Kill();
//        }

//        GlobalProj.SpearHoming(Projectile, 10f);
//        base.Projectile.rotation = base.Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
//        if (base.Projectile.spriteDirection == -1)
//        {
//            base.Projectile.rotation -= MathHelper.ToRadians(90f);
//        }
//    }
//}
