using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    private Player _player;

    private float _currentEnergy;

    public void SetOwner(Player onwer)
    {
        _player = onwer;
        _currentEnergy = _player.Stat.maxEnergy.GetValue();

        AddEnergy(0);
    }

    /// <summary>
    /// 추가할 값
    /// </summary>
    /// <param name="value"></param>
    public void AddEnergy(float value)
    {
        _currentEnergy = Mathf.Min(_currentEnergy + value, _player.Stat.maxEnergy.GetValue());
        PlayerManager.Instance.EnergyValueChangeEvent?.Invoke(_currentEnergy);
    }

    /// <summary>
    /// 줄일 값
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool RemoveEnergy(float value)
    {
        _currentEnergy = Mathf.Max(_currentEnergy - value, 0);
        PlayerManager.Instance.EnergyValueChangeEvent?.Invoke(_currentEnergy);
        if (_currentEnergy == 0)
        {
            return false;
        }

        return true;
    }
}
