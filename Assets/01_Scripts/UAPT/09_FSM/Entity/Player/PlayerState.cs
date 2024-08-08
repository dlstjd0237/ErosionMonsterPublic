using UnityEngine;

public abstract class PlayerState
{
    protected PlayerStateMachine _stateMachine;
    protected Player _player;
    protected InputReader _input;

    protected bool _triggerCall;

    public PlayerState(Player player, PlayerStateMachine stateMachine)
    {
        _player = player;
        _stateMachine = stateMachine;
        _input = player.InputReader;

    }

    //���¸� �������� �� ������ �Լ�
    public virtual void Enter()
    {
        _triggerCall = false; //�ִϸ��̼��� �� �������� ����� �Ҹ��� ��
    }

    //���¸� ������ ������ �Լ�
    public virtual void Exit()
    {

    }

    public virtual void UpdateState()
    {

    }
    public virtual void FixedUpdateState()
    {

    }


    public virtual void AnimationFinishTrigger()
    {
        _triggerCall = true;
    }
}
