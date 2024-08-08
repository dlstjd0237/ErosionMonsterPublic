using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoliathIdleState : EnemyState<GoliathStateEnum>
{
    public GoliathIdleState(Enemy enemyBase, EnemyStateMachine<GoliathStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_enemyBase.IsPlayerDetected())
        {
            PoolManager.SpawnFromPool("VFXSound", _enemyBase.transform.position).GetComponent<AudioSet>().StartAudio(_enemyBase.AttackSound);
            _stateMachine.ChangeState(GoliathStateEnum.Move);
        }
    }
}
