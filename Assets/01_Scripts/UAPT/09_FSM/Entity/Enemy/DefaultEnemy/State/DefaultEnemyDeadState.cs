using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyDeadState : EnemyState<DefaultStateEnum>
{
    public DefaultEnemyDeadState(Enemy enemyBase, EnemyStateMachine<DefaultStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _agent.isStopped = true;
    }

    public override void Exit()
    {
        _agent.isStopped = false;
        base.Exit();
    }
}
