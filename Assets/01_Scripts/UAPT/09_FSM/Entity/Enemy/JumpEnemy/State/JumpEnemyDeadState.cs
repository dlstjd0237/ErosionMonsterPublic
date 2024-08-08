using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemyDeadState : EnemyState<JumpEnemyStateEnum>
{
    public JumpEnemyDeadState(Enemy enemyBase, EnemyStateMachine<JumpEnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
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
