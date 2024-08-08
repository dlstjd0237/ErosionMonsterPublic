using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class StateBarUI : MonoBehaviour
{
    [SerializeField] private Image _healthFillBar;
    [SerializeField] private Image _energyFillBar;
    [SerializeField] private Image _ammoFillBar;
    [SerializeField] private Image _weaponImage;
    [SerializeField] private Image[] _crystalContainFillBar;
    [SerializeField] private TextMeshProUGUI _crystalValueText;
    [SerializeField] private TextMeshProUGUI _energyValueText;
    [SerializeField] private TextMeshProUGUI _HealthValueText;
    [SerializeField] private TextMeshProUGUI _ammoValueText;


    private void OnEnable()
    {
        PlayerManager.Instance.CrystalValueChangeEvent += HandleCrystalChange;
        PlayerManager.Instance.EnergyValueChangeEvent += HandleEnergyChange;
        PlayerManager.Instance.CurrentPlayer.HealthCompo.HealthValueChangeEvent += HandleHealthChange;
        PlayerManager.Instance.AmmoValueChangeEvent += HandleAmmoChange;
        PlayerManager.Instance.AmmoFiilChangeEvent += HandleAmmoFiilChange;
        HandleAmmoChange(0);
        HandleCrystalChange(PlayerManager.Instance.CurrentCrystal);
    }


    private void OnDestroy()
    {
        PlayerManager.Instance.CrystalValueChangeEvent -= HandleCrystalChange;
        PlayerManager.Instance.EnergyValueChangeEvent -= HandleEnergyChange;
        PlayerManager.Instance.CurrentPlayer.HealthCompo.HealthValueChangeEvent -= HandleHealthChange;
        PlayerManager.Instance.AmmoValueChangeEvent -= HandleAmmoChange;
        PlayerManager.Instance.AmmoFiilChangeEvent -= HandleAmmoFiilChange;
    }

    private void HandleHealthChange(float value)
    {
        int maxValue = PlayerManager.Instance.PlayerStat.maxHealth.GetValue();
        float pre = (value / maxValue) * 100;
        _HealthValueText.text = $"{(int)pre}%";
        _healthFillBar.DOFillAmount(value / maxValue, 0.4f);
    }
    private void HandleEnergyChange(float value)
    {
        int maxValue = PlayerManager.Instance.PlayerStat.maxEnergy.GetValue();
        float pre = (value / maxValue) * 100;
        _energyValueText.text = $"{(int)pre}%";
        _energyFillBar.DOFillAmount(value / maxValue, 0.4f);
    }

    private void HandleCrystalChange(int value)
    {
        int maxValue = PlayerManager.Instance.PlayerStat.maxCrystal.GetValue();
        _crystalValueText.text = $"{value}/{maxValue}";
        _crystalContainFillBar[0].DOFillAmount(((float)value / maxValue), 0.4f);
        _crystalContainFillBar[1].DOFillAmount(((float)value / maxValue), 0.4f);
    }

    private void HandleAmmoFiilChange(float value)
    {
        _ammoFillBar.DOFillAmount(value, 0.1f);
    }
    private void HandleAmmoChange(int value)
    {
        int maxValue = PlayerManager.Instance.PlayerStat.maxAmmo.GetValue();
        _ammoValueText.text = $"{value}/{maxValue}";

    }

    public void ChangeWeaponImage(Sprite sprite)
    {
        _weaponImage.sprite = sprite;
    }
}
