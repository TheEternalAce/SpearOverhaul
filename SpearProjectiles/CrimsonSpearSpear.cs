//using Microsoft.Xna.Framework;
//using SpearOverhaul.GlobalStuff;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

namespace SpearOverhaul.SpearProjectiles;
public class CrimsonSpearSpear : SpearBase
{
    protected override float HoldoutRangeMax => 120;
}
//public class CrimsonSpearSpear : ModProjectile
//{
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
//        // base.DisplayName.SetDefault("Crimson Spear");
//        ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 5;
//        ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
//    }

//    public override void SetDefaults()
//    {
//        base.Projectile.width = 24;
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
//    }

//    public override void AI()
//    {
//        Dust dust = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 117, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 25, default(Color), 1.2f);
//        dust.velocity += base.Projectile.velocity * 0.3f;
//        dust.velocity *= 0.2f;
//        dust.noGravity = true;
//        Player projOwner = Main.player[base.Projectile.owner];
//        Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, reverseRotation: true);
//        base.Projectile.direction = projOwner.direction;
//        projOwner.heldProj = base.Projectile.whoAmI;
//        projOwner.itemTime = projOwner.itemAnimation;
//        base.Projectile.position.X = ownerMountedCenter.X - ((float)(base.Projectile.width / 2) - base.Projectile.velocity.X);
//        base.Projectile.position.Y = ownerMountedCenter.Y - ((float)(base.Projectile.height / 2) - base.Projectile.velocity.Y);
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
//                if (!this.moveBack)
//                {
//                    Projectile.NewProjectile(base.Projectile.GetSource_Death(), base.Projectile.Center.X + base.Projectile.velocity.X * 4f, base.Projectile.Center.Y + base.Projectile.velocity.Y * 4f, base.Projectile.velocity.X / 2f, base.Projectile.velocity.Y / 2f, base.Mod.Find<ModProjectile>("CrimsonEnergyBall").Type, base.Projectile.damage, base.Projectile.knockBack / 2f, projOwner.whoAmI);
//                    this.moveBack = true;
//                }
//            }
//            else
//            {
//                this.movementFactor += 2.55f;
//            }
//        }
//        base.Projectile.position += base.Projectile.velocity * this.movementFactor;
//        if (projOwner.itemAnimation == 0)
//        {
//            base.Projectile.Kill();
//        }

//        GlobalProj.SpearHoming(Projectile, 5.5f);
//        base.Projectile.rotation = base.Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
//        if (base.Projectile.spriteDirection == -1)
//        {
//            base.Projectile.rotation -= MathHelper.ToRadians(90f);
//        }
//    }
//}
