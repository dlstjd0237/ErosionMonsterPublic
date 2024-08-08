using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoliathAttackState : EnemyState<GoliathStateEnum>
{
    private readonly int _attackCountHash = Animator.StringToHash("AttackCount");
    public GoliathAttackState(Enemy enemyBase, EnemyStateMachine<GoliathStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _enemyBase.AnimatorCompo.SetInteger(_attackCountHash, Random.Range(0, 2));
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
            _stateMachine.ChangeState(GoliathStateEnum.Idle);
    }
}
