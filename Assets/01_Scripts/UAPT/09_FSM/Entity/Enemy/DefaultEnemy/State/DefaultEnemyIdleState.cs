using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyIdleState : EnemyState<DefaultStateEnum>
{
    public DefaultEnemyIdleState(Enemy enemyBase, EnemyStateMachine<DefaultStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_enemyBase.IsPlayerDetected())
        {
            PoolManager.SpawnFromPool("VFXSound", _enemyBase.transform.position).GetComponent<AudioSet>().StartAudio(_enemyBase.AttackSound);
            _stateMachine.ChangeState(DefaultStateEnum.Move);
        }
    }
}
