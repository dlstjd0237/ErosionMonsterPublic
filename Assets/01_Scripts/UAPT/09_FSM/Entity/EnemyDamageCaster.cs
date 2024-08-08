using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageCaster : MonoBehaviour
{
    private Enemy _entity;
    public void SetOwner(Enemy owner)
    {
        _entity = owner;
    }

    public void Attack()
    {
        _entity.Attack();
    }

    public void FinishAnimation()
    {
        _entity.FinishAnimation();
    }

    public void DeadAnimation()
    {
        _entity.DeadAnimation();
    }

}
