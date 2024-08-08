using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missil : Projectile
{
    protected override void TriggerEvent(Collider other)
    {
        PoolManager.SpawnFromPool("MissilExplosionVFX", transform.position);
    }


}
