using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
public abstract class Enemy : Entity
{
    private Collider[] _enemyCheckColliders;

    [SerializeField] protected LayerMask _whatIsPlayer;

    [HideInInspector] public NavMeshAgent Agent;
    [HideInInspector] public Animator AnimatorCompo;
    [HideInInspector] public EnemyDamageCaster DamageCasterCompo;
    [HideInInspector] public bool IsAttack = false;
    public AudioClip AttackSound;
    public float RunAwayDistance;
    public float AttackDistance;
    public float DamageCasterDistance;
    [Range(0, 100)]
    public int DropMaxCrystal;
    [Range(0, 100)]
    public int DropMinCrystal;
    [Range(0, 100)]
    public int DropEnergy;


    public Transform DamageCasterTrm;
    protected override void Awake()
    {
        base.Awake();
        Transform visualTrm = transform.Find("Visual");

        AnimatorCompo = visualTrm.GetComponent<Animator>();
        DamageCasterCompo = visualTrm.GetComponent<EnemyDamageCaster>();
        DamageCasterCompo.SetOwner(this);
        Agent = GetComponent<NavMeshAgent>();
        _enemyCheckColliders = new Collider[1];
        Agent.speed = Stat.moveSpeed.GetValue();
    }

    public virtual Collider IsPlayerDetected()
    {
        int cnt = Physics.OverlapSphereNonAlloc(transform.position, RunAwayDistance, _enemyCheckColliders, _whatIsPlayer);

        return cnt >= 1 ? _enemyCheckColliders[0] : null;
    }

    public virtual Collider IsAttackRangeDetected()
    {
        int cnt = Physics.OverlapSphereNonAlloc(DamageCasterTrm.position, AttackDistance, _enemyCheckColliders, _whatIsPlayer);

        return cnt >= 1 ? _enemyCheckColliders[0] : null;
    }

    public virtual void Attack()
    {
        int cnt = Physics.OverlapSphereNonAlloc(transform.position, DamageCasterDistance, _enemyCheckColliders, _whatIsPlayer);
        Debug.Log(cnt);
        if (cnt > 0)
        {
            if (_enemyCheckColliders[0].transform.TryGetComponent<Player>(out Player player))
            {

                player.HealthCompo.ApplyeDamage(Stat.mainWeaponDamage.GetValue());
            }
        }
    }

    public abstract void FinishAnimation();

    public void DeadAnimation()//죽는 애니메이션이 끝났을때
    {
        var playerManager = PlayerManager.Instance;

        playerManager.KillEnemy(); //에너미 죽었을때 이벤트 실행

        int dropCrystalAmount = Random.Range(DropMinCrystal, DropMaxCrystal + 1); //드롭할 크리스탈 수
        playerManager.AddEnergy(DropEnergy);  //플레이어 에너지 추가

        for (int i = 0; i < dropCrystalAmount; ++i)
        {
            Vector3 randomPos = new Vector3(Random.Range(transform.position.x - 3, transform.position.x + 4), transform.position.y,
                Random.Range(transform.position.z - 3, transform.position.z + 4));
            PoolManager.SpawnFromPool("DropCrystal", randomPos);
        }

        gameObject.SetActive(false);

    }

    public abstract void Dead(); //막 죽었을때



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RunAwayDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, AttackDistance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(DamageCasterTrm.position, DamageCasterDistance);
        Gizmos.color = Color.white;

    }


}
