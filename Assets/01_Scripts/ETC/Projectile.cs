using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    protected float _speed = 100;
    protected float _attackMultipli = 1000;
    protected Rigidbody _rig;

    protected virtual void Awake()
    {
        _rig = GetComponent<Rigidbody>();
    }
    protected virtual void OnEnable()
    {
        Invoke(nameof(SetActive), 1f);
    }

    protected abstract void TriggerEvent(Collider other);
    private void OnTriggerEnter(Collider other)
    {
        TriggerEvent(other);
        SetActive();
    }

    private void SetActive() => gameObject.SetActive(false);

    public void SetVelocity(Vector3 dir) => setVelocity(dir, _speed);

    public void SetVelocity(Vector3 dir, float speed) => setVelocity(dir, speed);
    public void SetVelocity(Vector3 dir, AudioClip clip) => setVelocity(dir, _speed, clip);
    public void SetVelocity(Vector3 dir, float speed, AudioClip clip) => setVelocity(dir, speed, clip);

    private void setVelocity(Vector3 dir, float Speed, AudioClip clip = null)
    {
        if (clip != null)
        {
            AudioSet audio = PoolManager.SpawnFromPool("VFXSound", transform.position).GetComponent<AudioSet>();
            audio.StartAudio(clip);
        }
        transform.localRotation = Quaternion.LookRotation(dir);
        _rig.velocity = dir * Speed;
    }
    /// <summary>
    /// 총알 데미지 추가 데미지 
    /// </summary>
    /// <param name="value">1000 넣으면 1 곱해짐</param>
    public void SetAttackMultipli(float value)
    {
        _attackMultipli = value;
    }
}
