using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerGroundState : PlayerState
{
    private Camera _cam;

    public PlayerGroundState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _cam = Camera.main;
        _input.AttackEvent += HandleAttack;
        _input.SubAttackEvent += HandleSubAttack;
        _input.BoosterEvent += HandleBooster;
    }



    private void HandleBooster(bool value)
    {
        if (value)
        {
            _player.BoosterOn();
        }
        else
        {
            _player.BoosterOff();
        }
    }

    private void HandleAttack(bool value)
    {
        if (value)//°ø°ÝÁß
        {
            _player.AttackOn();
        }
        else
        {
            _player.AttackOff();
        }
    }

    public override void Exit()
    {
        _input.AttackEvent -= HandleAttack;
        _input.SubAttackEvent -= HandleSubAttack;
        _input.BoosterEvent -= HandleBooster;

        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_player.IsStop) return;

        RaycastHit hit = Utile.GetMouseToRay(_cam);

        Vector3 targetPos = new Vector3(hit.point.x, _player.transform.position.y, hit.point.z);
        Vector3 direction = (targetPos - _player.transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(direction);
        _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation, lookRot, Time.deltaTime * 20);
    }
    private void HandleSubAttack()
    {
        if (PlayerManager.Instance.CurrentAmmo > 0)
        {
            PlayerManager.Instance.CurrentAmmo -= 1;
            Missil missil = PoolManager.SpawnFromPool("Missil", _player.MissilTrm.position).GetComponent<Missil>();
            missil.SetVelocity(_player.transform.forward);

        }
    }


}
