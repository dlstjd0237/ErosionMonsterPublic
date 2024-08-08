using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerManager : MonoSingleton<PlayerManager>
{
    private Player _currentPlayer;
    public Player CurrentPlayer => _currentPlayer;

    public event Action<int> CrystalValueChangeEvent; //크리스탈 값 변경 이벤트
    public event Action<int> TotalCrystalValueChangeEvent;
    public event Action<int> AmmoValueChangeEvent;
    public event Action<int> TotalEnemyKillValueChangeEvent; //에너미 총 처치 수량 변경 되었을때
    public Action<float> EnergyValueChangeEvent; //에너지 값 변경 이벤트
    public Action<float> AmmoFiilChangeEvent;


    private int _totalCrystal = 0;
    private int _totalEnemyKill = 0;
    public int TotalEnemyKill
    {
        get => _totalEnemyKill;
        set => _totalEnemyKill = value;
    }

    private int _currentCrystal = 0;
    public int CurrentCrystal
    {
        get => _currentCrystal;
        set
        {

            CrystalValueChangeEvent?.Invoke(value);

            _currentCrystal = value;
        }
    }
    private int _currentAmmo = 0;
    public int CurrentAmmo
    {
        get => _currentAmmo;
        set
        {
            AmmoValueChangeEvent?.Invoke(value);
            _currentAmmo = value;
        }
    }
    private CharacterStat _playerStat;
    public CharacterStat PlayerStat => _playerStat;

    public void SetOwner(Player player)
    {
        _currentPlayer = player;
        _playerStat = player.Stat;
        _totalCrystal = 0;
        _totalEnemyKill = 0;
        _currentCrystal = 0;
        _currentAmmo = 0;
    }

    public void CrystalUseSOLevelUP(int amount, ref UpgradeUIBtnSO so)
    {
        _currentCrystal -= amount;
        so.Level++;
        CrystalValueChangeEvent?.Invoke(_currentCrystal);
    }

    public void KillEnemy()
    {
        _totalEnemyKill += 1;
        TotalEnemyKillValueChangeEvent?.Invoke(_totalEnemyKill);
    }

    public void AddCrystal(int amount)
    {
        if (_currentCrystal != _currentPlayer.Stat.maxCrystal.GetValue())
        {
            _totalCrystal += amount;

            TotalCrystalValueChangeEvent?.Invoke(_totalCrystal);
        }
        CurrentCrystal = Mathf.Min(CurrentCrystal += amount, _currentPlayer.Stat.maxCrystal.GetValue());
    }

    public void AddEnergy(int amount)
    {

        _currentPlayer.EnergyComp.AddEnergy(amount);
    }
}
