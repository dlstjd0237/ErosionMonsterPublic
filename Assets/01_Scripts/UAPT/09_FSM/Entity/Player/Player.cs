using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Random = UnityEngine.Random;
[RequireComponent(typeof(PlayerStateMachine))]
public class Player : Entity
{
    public PlayerStateMachine StateMachine { get; private set; }
    public InputReader InputReader => _inputReader;

    public bool IsStop { get; set; }

    public GameObject[] FireObj;
    public Transform MissilTrm;
    [HideInInspector] public Rigidbody RigodbpdyComp;
    [HideInInspector] public Energy EnergyComp;

    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CinemachineVirtualCamera _camFollowCam;

    [SerializeField] private WeaponStateMachine _weaponMachine;
    public WeaponStateMachine WeaponMachine => _weaponMachine;

    private Collider _collider;
    protected override void Awake()
    {

        base.Awake();
        _collider = gameObject.GetComponent<Collider>();
        RigodbpdyComp = gameObject.GetComponent<Rigidbody>();
        EnergyComp = gameObject.GetComponent<Energy>();

        EnergyComp.SetOwner(this);
        _inputReader = Instantiate(_inputReader);
        _inputReader.Console.Enable();
        _weaponMachine.Init();

        StateMachine = new PlayerStateMachine();
        PlayerManager.Instance.SetOwner(this);
        foreach (PlayerStateEnum stateEnum in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string typeName = stateEnum.ToString();
            try
            {
                Type t = Type.GetType($"Player{typeName}State");
                PlayerState state = Activator.CreateInstance(t, this, StateMachine) as PlayerState;

                StateMachine.AddState(stateEnum, state);
            }
            catch (Exception ex)
            {
                Debug.LogError($"{typeName} is loading error!");
                Debug.LogError(ex);
            }
        }
    }
    private void Start()
    {
        StateMachine.Initialize(PlayerStateEnum.Idle, this);
        StartCoroutine("AmmoFiilCharge");
        StartCoroutine("EnergyHealingCoroutine");
    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.FixedUpdateState();
    }

    public void HandleDead()
    {
        _collider.enabled = false;
        _inputReader.Console.Disable();
        StartCoroutine(DeadCoroutine());
    }

    private IEnumerator DeadCoroutine()
    {
        var wait = new WaitForSeconds(0.1f);
        Vector3 playerPos = transform.position;

        for (int i = 0; i < 20; ++i)
        {
            Vector3 randPos = new Vector3(Random.Range(playerPos.x - 3, playerPos.x + 4), Random.Range(playerPos.y, playerPos.y + 1), Random.Range(playerPos.z - 3, playerPos.z + 4));
            PoolManager.SpawnFromPool("BulletExplosion", randPos);
            randPos = new Vector3(Random.Range(playerPos.x - 3, playerPos.x + 4), Random.Range(playerPos.y, playerPos.y + 1), Random.Range(playerPos.z - 3, playerPos.z + 4));
            PoolManager.SpawnFromPool("BulletExplosion", randPos);
            yield return wait;
        }
    }

    public void BoosterOn()
    {
        _camFollowCam.Priority = 15;
        StopCoroutine("EnergyHealingCoroutine");
        StartCoroutine("BoosterCoroutine");
        Stat.moveSpeed.AddModifier(40 * (Stat.moveSpeedMultiply.GetValue() / 1000));
    }
    public void BoosterOff()
    {
        _camFollowCam.Priority = 5;
        StartCoroutine("EnergyHealingCoroutine");
        StopCoroutine("BoosterCoroutine");
        Stat.moveSpeed.RemoveModifier(40 * (Stat.moveSpeedMultiply.GetValue() / 1000));
    }

    private IEnumerator EnergyHealingCoroutine()
    {
        var Wait = new WaitForSeconds(0.25f);
        while (true)
        {
            yield return Wait;
            EnergyComp.AddEnergy(0.5f);
        }
    }
    private IEnumerator BoosterCoroutine()
    {
        var Wait = new WaitForSeconds(0.05f);
        while (true)
        {
            if (EnergyComp.RemoveEnergy(1) == false)
            {
                BoosterOff();
            }
            yield return Wait;
        }
    }

    public void AttackOn()
    {
        _weaponMachine.CurrentWeapon.AttackOn();
    }
    public void AttackOff()
    {
        _weaponMachine.CurrentWeapon.AttackOff();
    }

    private IEnumerator AmmoFiilCharge()
    {
        float currentTime = 0;
        var wait = new WaitForSeconds(1);
        while (true)
        {
            if (PlayerManager.Instance.CurrentAmmo < PlayerManager.Instance.CurrentPlayer.Stat.maxAmmo.GetValue())
            {

                currentTime += 1;
                yield return wait;

                if (currentTime >= 15)
                {
                    currentTime = 0;
                    PlayerManager.Instance.CurrentAmmo += 1;
                }
                PlayerManager.Instance.AmmoFiilChangeEvent?.Invoke(currentTime / 15);
            }
            else
            {
                yield return wait;

            }


        }
    }

}
