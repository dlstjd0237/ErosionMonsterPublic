using UnityEngine;

public interface IDamageable
{
    void ApplyeDamage(float damage);
    void CreateParticle(Transform LookTrm);
}
