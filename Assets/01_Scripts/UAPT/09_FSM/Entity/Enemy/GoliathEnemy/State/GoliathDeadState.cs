using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoliathDeadState : EnemyState<GoliathStateEnum>
{
    public GoliathDeadState(Enemy enemyBase, EnemyStateMachine<GoliathStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
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
