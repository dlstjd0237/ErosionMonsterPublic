using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int _maxTarget = 5;
    [SerializeField] private float _explosionRnage = 5;
    [SerializeField] private LayerMask _whatIsEnemy;
    [SerializeField] private AudioClip _clip;
    private Collider[] _enemyCheckColliders;

    private void OnEnable()
    {
        ExplosionFire();
        CameraManager.Instance.ShakeCamera(Vector3.one * 3, 5, 5, 0.2f);
    }
    public void ExplosionFire()
    {
        if (IsEnemyDetected())
        {
            PoolManager.SpawnFromPool("VFXSound", transform.position).GetComponent<AudioSet>().StartAudio(_clip);
            float damage = PlayerManager.Instance.PlayerStat.subWeaponDamage.GetValue();
            foreach (var item in _enemyCheckColliders)
            {
                if (item != null && item.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    damageable.ApplyeDamage(damage);
                }
            }
        }
    }

    private bool IsEnemyDetected()
    {
        _enemyCheckColliders = new Collider[_maxTarget];
        int cnt = Physics.OverlapSphereNonAlloc(transform.position, _explosionRnage, _enemyCheckColliders, _whatIsEnemy);

        return cnt > 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRnage);
    }
}
