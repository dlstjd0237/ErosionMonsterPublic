using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float _attackSpeed = 0.15f;
    [SerializeField] protected float _attackMultipli = 1000f;
    [SerializeField] protected AudioClip _weaponAudioClip;
    protected WeaponStateMachine Machine;
    protected Transform _rightFireTrm;
    protected Transform _leftFireTrm;
    protected Transform _midFireTrm;
    public void Init(WeaponStateMachine machine)
    {
        Machine = machine;
        _rightFireTrm = machine.RightFireTrm;
        _leftFireTrm = machine.LeftFireTrm;
        _midFireTrm = machine.MidFireTrm;
    }
    public abstract void AttackOn();
    public abstract void AttackOff();
}
