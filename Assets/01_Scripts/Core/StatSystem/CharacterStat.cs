using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : ScriptableObject
{
    public Stat maxHealth;
    public Stat maxEnergy;
    public Stat maxCrystal;
    public Stat crystalBonus;
    public Stat energyBonus;
    public Stat erosionRate;
    public Stat maxShield;
    public Stat mainWeaponDamage;
    public Stat subWeaponDamage;
    public Stat fireDamage;
    public Stat ignitePercent;
    public Stat maxNuclearBomb;
    public Stat maxAmmo;
    public Stat moveSpeed;
    public Stat moveSpeedMultiply;
    protected Entity _owner;

    protected Dictionary<StatType, Stat> _statDictionary;

    public virtual void SetOwner(Entity owner)
    {
        _owner = owner;
    }

    public void AddStatPoint(StatType stat, int point)
    {
        _statDictionary[stat].AddModifier(point);
    }
    public virtual void IncreaseStatBy(int modifyValue, float duration, Stat statToModify)
    {
        _owner.StartCoroutine(StatModifyCoroutine(modifyValue, duration, statToModify));
    }

    private IEnumerator StatModifyCoroutine(int modifyValue, float duration, Stat statToModify)
    {
        statToModify.AddModifier(modifyValue);
        yield return new WaitForSeconds(duration);
        statToModify.RemoveModifier(modifyValue);
    }

    protected virtual void OnEnable()
    {
        _statDictionary = new Dictionary<StatType, Stat>();
    }


    public int GetMaxHealth()
    {
        return maxHealth.GetValue();
    }


}