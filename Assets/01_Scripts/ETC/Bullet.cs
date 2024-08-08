using UnityEngine;

public class Bullet : Projectile
{
    protected override void TriggerEvent(Collider other)
    {

        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            var MainWeaponDamage = PlayerManager.Instance.CurrentPlayer.Stat.mainWeaponDamage.GetValue();
            damageable.ApplyeDamage(MainWeaponDamage * (_attackMultipli * 0.001f));
            damageable.CreateParticle(transform);
        }

    }

}
