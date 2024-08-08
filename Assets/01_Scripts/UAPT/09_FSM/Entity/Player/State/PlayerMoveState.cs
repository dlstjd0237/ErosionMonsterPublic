using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        Move();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (Mathf.Abs(_input.InputY) <= 0.05f)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    private void Move()
    {
        Vector3 moveDir = new Vector3(0, 0, _input.InputY);
        Vector3 motion = _player.transform.TransformDirection(moveDir);
        _player.RigodbpdyComp.MovePosition(_player.transform.position + motion * Time.deltaTime * _player.Stat.moveSpeed.GetValue());
    }
}
