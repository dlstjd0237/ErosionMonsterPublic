using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemyAttackState : EnemyState<JumpEnemyStateEnum>
{
    public JumpEnemyAttackState(Enemy enemyBase, EnemyStateMachine<JumpEnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _agent.isStopped = true;
        Transform playerTrm = PlayerManager.Instance.CurrentPlayer.transform;
        _enemyBase.transform.DOLookAt(playerTrm.position, 0.3f);
        _enemyBase.transform.DOJump(playerTrm.position, 10, 1, 0.75f);
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
            _stateMachine.ChangeState(JumpEnemyStateEnum.Idle);
    }
}
