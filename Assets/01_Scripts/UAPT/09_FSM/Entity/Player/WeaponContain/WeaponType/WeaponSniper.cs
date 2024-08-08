using System.Collections;
using UnityEngine;

public class WeaponSniper : Weapon
{
    public override void AttackOff()
    {
        StopCoroutine("StartAttack");
    }

    public override void AttackOn()
    {
        StartCoroutine("StartAttack");
    }

    private IEnumerator StartAttack()
    {
        var Wait = new WaitForSeconds(_attackSpeed);

        yield return new WaitForSeconds(_attackSpeed * 1.5f);

        while (true)
        {
            CameraManager.Instance.ShakeCamera(new Vector3(1, 4, 1), 4, 4, 0.2f);
            Bullet Bullet1 = PoolManager.SpawnFromPool("Bullet", _midFireTrm.transform.position).GetComponent<Bullet>();
            Bullet1.SetVelocity(transform.forward, 450, _weaponAudioClip);
            Bullet1.SetAttackMultipli(_attackMultipli);
            yield return Wait;

        }
    }
}
