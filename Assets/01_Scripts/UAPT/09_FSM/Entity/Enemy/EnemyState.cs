using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState<T> where T : Enum
{
    protected EnemyStateMachine<T> _stateMachine;
    protected Enemy _enemyBase;
    protected bool _endTriggerCalled;
    protected int _animBoolHash;
    protected NavMeshAgent _agent;

    public EnemyState(Enemy enemyBase, EnemyStateMachine<T> stateMachine, string animBoolName)
    {
        _enemyBase = enemyBase;
        _agent = enemyBase.Agent;
        _stateMachine = stateMachine;
        _animBoolHash = Animator.StringToHash(animBoolName);
    }

    public virtual void UpdateState()
    {

    }

    public virtual void FixedUpdateState()
    {

    }

    public virtual void Enter()
    {
        _endTriggerCalled = false;
        _enemyBase.AnimatorCompo.SetBool(_animBoolHash, true);
    }

    public virtual void Exit()
    {
        _enemyBase.AnimatorCompo.SetBool(_animBoolHash, false);
    }

    public void AnimationFinishTrigger()
    {
        _endTriggerCalled = true;
    }

}
