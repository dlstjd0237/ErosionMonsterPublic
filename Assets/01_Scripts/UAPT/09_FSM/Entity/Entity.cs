using UnityEngine;

public class Entity : MonoBehaviour
{
    [HideInInspector]public Health HealthCompo;
    public CharacterStat Stat;

    [Header("Collision info")]
    protected LayerMask _whatIsEnemy;


    protected virtual void Awake()
    {
        HealthCompo = gameObject.GetComponent<Health>();
        HealthCompo.Initialized(this);



        Stat = Instantiate(Stat);
        Stat.SetOwner(this);
    }


    //public virtual bool IsRightWallDetected()
    //{
    //    return Physics.Raycast(_wallChecker.position, _wallChecker.right, _wallCheckDistance, _whatIsWall);
    //}



}
