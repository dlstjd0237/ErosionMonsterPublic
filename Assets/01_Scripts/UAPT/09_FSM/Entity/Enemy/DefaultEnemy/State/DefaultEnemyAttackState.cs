using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DefaultEnemyAttackState : EnemyState<DefaultStateEnum>
{
    public DefaultEnemyAttackState(Enemy enemyBase, EnemyStateMachine<DefaultStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _agent.isStopped = true;
        _enemyBase.transform.DOLookAt(PlayerManager.Instance.CurrentPlayer.transform.position, 0.3f);
       
    }

    public override void Exit()
    {
        _agent.isStopped = false;

        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
            _stateMachine.ChangeState(DefaultStateEnum.Idle);
    }
}
