using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoliathStateEnum
{
    Idle,
    Move,
    Attack,
    Dead
}

public class GoliathEnemy : Enemy
{
    public EnemyStateMachine<GoliathStateEnum> StateMachine { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine<GoliathStateEnum>();

        foreach (GoliathStateEnum stateEnum in Enum.GetValues(typeof(GoliathStateEnum)))
        {
            string typeName = stateEnum.ToString();
            Type t = Type.GetType($"Goliath{typeName}State");

            try
            {
                var enemyState = Activator.CreateInstance(t, this, StateMachine, typeName) as EnemyState<GoliathStateEnum>;
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
        StateMachine.Initalize(GoliathStateEnum.Idle, this);

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
        QuestManager.Instance.Goal(6);

        StateMachine.ChangeState(GoliathStateEnum.Dead);
    }
}
