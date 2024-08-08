using System.Collections;
using UnityEngine;

public class WeaponRifle : Weapon
{
    public override void AttackOff()
    {
        _leftFireTrm.gameObject.SetActive(false);
        _rightFireTrm.gameObject.SetActive(false);

        StopCoroutine("StartAttack");
    }

    public override void AttackOn()
    {
        _leftFireTrm.gameObject.SetActive(true);
        _rightFireTrm.gameObject.SetActive(true);
        StartCoroutine("StartAttack");
    }

    private IEnumerator StartAttack()
    {
        var Wait = new WaitForSeconds(_attackSpeed);

        yield return new WaitForSeconds(_attackSpeed * 1.5f);

        while (true)
        {

            CameraManager.Instance.ShakeCamera(Vector3.one * 2, 4, 4, 0.2f);
            Bullet Bullet1 = PoolManager.SpawnFromPool("Bullet", _leftFireTrm.transform.position).GetComponent<Bullet>();
            Bullet1.SetVelocity(transform.forward, _weaponAudioClip);
            Bullet1.SetAttackMultipli(_attackMultipli);
            yield return Wait;
            CameraManager.Instance.ShakeCamera(Vector3.one * 2, 4, 4, 0.2f);
            Bullet Bullet2 = PoolManager.SpawnFromPool("Bullet", _rightFireTrm.transform.position).GetComponent<Bullet>();
            Bullet2.SetVelocity(transform.forward, _weaponAudioClip);
            Bullet2.SetAttackMultipli(_attackMultipli);
            yield return Wait;

        }
    }


}
