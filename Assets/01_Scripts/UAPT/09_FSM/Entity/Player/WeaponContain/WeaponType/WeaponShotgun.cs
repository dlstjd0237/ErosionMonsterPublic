using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotgun : Weapon
{
    private float spreadAngle = 45f;
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

            CameraManager.Instance.ShakeCamera(Vector3.one * 4, 5, 5, 0.4f);
            float angleStep = spreadAngle / (10 - 1);
            float startAngle = -spreadAngle / 2;

            PoolManager.SpawnFromPool("VFXSound", transform.position).GetComponent<AudioSet>().StartAudio(_weaponAudioClip);

            for (int j = 0; j < 10; ++j)
            {

                float currentAngle = startAngle + (angleStep * j);
                Quaternion rotation = Quaternion.Euler(new Vector3(0, currentAngle, 0));
                Vector3 bulletDirection = rotation * transform.forward;

                Bullet Bullet1 = PoolManager.SpawnFromPool("Bullet", _midFireTrm.transform.position).GetComponent<Bullet>();
                Bullet1.SetVelocity(bulletDirection, 150);
                Bullet1.SetAttackMultipli(_attackMultipli);

            }

            yield return Wait;

        }
    }
}
