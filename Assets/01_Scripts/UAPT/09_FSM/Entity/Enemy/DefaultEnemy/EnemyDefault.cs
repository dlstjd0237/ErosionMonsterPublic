using System;
using UnityEngine;

public enum DefaultStateEnum
{
    Idle,
    Move,
    Attack,
    Dead
}


public class EnemyDefault : Enemy
{
    public EnemyStateMachine<DefaultStateEnum> StateMachine { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine<DefaultStateEnum>();

        foreach (DefaultStateEnum stateEnum in Enum.GetValues(typeof(DefaultStateEnum)))
        {
            string typeName = stateEnum.ToString();
            Type t = Type.GetType($"DefaultEnemy{typeName}State");

            try
            {
                var enemyState = Activator.CreateInstance(t, this, StateMachine, typeName) as EnemyState<DefaultStateEnum>;
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
        StateMachine.Initalize(DefaultStateEnum.Idle, this);

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
        QuestManager.Instance.Goal(4);

        StateMachine.ChangeState(DefaultStateEnum.Dead);
    }
}
