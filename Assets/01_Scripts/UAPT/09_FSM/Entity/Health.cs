using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    public UnityEvent DeadEvent;
    public event Action<float> HealthValueChangeEvent;

    private Entity _owner;
    private float _maxHealth;
    private float _currentHealth;
    private float _maxShield;
    private float _currentShield;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _deadSound;
    public void Initialized(Entity owner)
    {
        _owner = owner;
        _maxHealth = owner.Stat.maxHealth.GetValue();
        _currentHealth = _maxHealth;
    }

    public void HealthHealing(float value)
    {
        _maxHealth = _owner.Stat.maxHealth.GetValue();
        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, _maxHealth);
        HealthValueChangeEvent?.Invoke(_currentHealth);
    }


    public void ApplyeDamage(float damage)
    {
        if (_hitSound != null)
            PoolManager.SpawnFromPool("VFXSound", transform.position).GetComponent<AudioSet>().StartAudio(_hitSound);

        if (_owner.name == "Player")
            CameraManager.Instance.ShakeCamera(Vector3.one * 10, 10, 10, 0.2f);
        if (_currentShield != 0)
        {
            var defaultDamage = damage;
            damage = Mathf.Max(damage - _currentShield, 0);
            if (damage == 0)
            {
                _currentShield -= defaultDamage;
            }
            else if (damage > 0)
            {
                _currentShield = 0;
            }
        }
        _currentHealth = Mathf.Max(_currentHealth - damage, 0);
        if (_currentHealth <= 0)
        {
            if(_deadSound != null)
                PoolManager.SpawnFromPool("VFXSound", transform.position).GetComponent<AudioSet>().StartAudio(_deadSound);

            DeadEvent?.Invoke();
        }
        HealthValueChangeEvent?.Invoke(_currentHealth);
    }

    public void CreateParticle(Transform LookTrm)
    {
    }

}
