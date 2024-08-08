using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoliathMoveState : EnemyState<GoliathStateEnum>
{
    private Player _player;
    private Vector3 _lastPlayerPos;
    private bool _playerFind=false;
    public GoliathMoveState(Enemy enemyBase, EnemyStateMachine<GoliathStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _playerFind = false;
        _lastPlayerPos = Vector3.zero;
        _player = PlayerManager.Instance.CurrentPlayer;
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        if (_enemyBase.IsPlayerDetected())
        {
            _playerFind = false;
            var playerPos = _player.transform.position;
            _agent.SetDestination(playerPos);
            if (_enemyBase.IsAttackRangeDetected())
                _stateMachine.ChangeState(GoliathStateEnum.Attack);

        }
        else if (!_enemyBase.IsPlayerDetected())
        {
            if (_playerFind == false)
            {
                _playerFind = true;
                _lastPlayerPos = _player.transform.position;
                _lastPlayerPos.y = _enemyBase.transform.localPosition.y;
                _agent.SetDestination(_lastPlayerPos);
            }
            if (Vector3.Distance(_lastPlayerPos, _enemyBase.transform.localPosition) <= 0.1f)
                _stateMachine.ChangeState(GoliathStateEnum.Idle);
        }


    }
}
