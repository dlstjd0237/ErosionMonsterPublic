using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(WeaponRifle))]
[RequireComponent(typeof(WeaponShotgun))]
[RequireComponent(typeof(WeaponSniper))]

public class WeaponStateMachine : MonoBehaviour
{
    private Dictionary<WeaponType, Weapon> _weaponDIctionary;
    private Weapon _currentWeapon;
    public Weapon CurrentWeapon => _currentWeapon;


    public Transform RightFireTrm;
    public Transform LeftFireTrm;
    public Transform MidFireTrm;

    public void Init()
    {
        _weaponDIctionary = new Dictionary<WeaponType, Weapon>();
        _weaponDIctionary.Add(WeaponType.Rifle, GetComponent<WeaponRifle>());
        _weaponDIctionary.Add(WeaponType.Shotgun, GetComponent<WeaponShotgun>());
        _weaponDIctionary.Add(WeaponType.Sniper, GetComponent<WeaponSniper>());
        foreach (WeaponType stateEnum in Enum.GetValues(typeof(WeaponType)))
        {
            _weaponDIctionary[stateEnum].Init(this);
        }

        _currentWeapon = _weaponDIctionary[WeaponType.Rifle];

    }

    public void ChangeWeapon(WeaponType type)
    {
        _currentWeapon.AttackOff();
        _currentWeapon = _weaponDIctionary[type];
    }
}
