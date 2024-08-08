using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum JumpEnemyStateEnum
{
    Idle,
    Move,
    Attack,
    Dead
}


public class JumpEnemy : Enemy
{
    public EnemyStateMachine<JumpEnemyStateEnum> StateMachine { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine<JumpEnemyStateEnum>();

        foreach (JumpEnemyStateEnum stateEnum in Enum.GetValues(typeof(JumpEnemyStateEnum)))
        {
            string typeName = stateEnum.ToString();
            Type t = Type.GetType($"JumpEnemy{typeName}State");

            try
            {
                var enemyState = Activator.CreateInstance(t, this, StateMachine, typeName) as EnemyState<JumpEnemyStateEnum>;
                StateMachine.AddState(stateEnum, enemyState);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }

        }
    }

    private void OnEnable()
    {
        StateMachine.Initalize(JumpEnemyStateEnum.Idle, this);

    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.FixedUpdateState();
    }


    public override void FinishAnimation()
    {
        StateMachine.CurrentState.AnimationFinishTrigger();
    }

    public override void Dead()
    {
        QuestManager.Instance.Goal(5);
        StateMachine.ChangeState(JumpEnemyStateEnum.Dead);
    }
}
