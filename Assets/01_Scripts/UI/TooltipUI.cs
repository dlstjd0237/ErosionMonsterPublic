using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class TooltipUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _killingAmountText;
    [SerializeField] private TextMeshProUGUI _crystalAmountText;
    [SerializeField] private TextMeshProUGUI _distanceText;



    [Header("DistanceTextRef")]
    [SerializeField] private Player _player;
    [SerializeField] private Transform _baseTrm;

    private void OnEnable()
    {
        var playerManager = PlayerManager.Instance;
        playerManager.TotalCrystalValueChangeEvent += HandleTotalCrystal;
        playerManager.TotalEnemyKillValueChangeEvent += HandleTotalEnemyKill;
    }
    private void OnDisable()
    {
        var playerManager = PlayerManager.Instance;
        playerManager.TotalCrystalValueChangeEvent -= HandleTotalCrystal;
        playerManager.TotalEnemyKillValueChangeEvent -= HandleTotalEnemyKill;

    }


    private void HandleTotalEnemyKill(int totalEnemyKill)
    {
        _killingAmountText.SetText($"TotalEnemyKill : {totalEnemyKill}");
    }

    private void HandleTotalCrystal(int totalCrystal)
    {
        _crystalAmountText.SetText($"TotalCrystal : {totalCrystal}");
    }

    private void Update()
    {
        _distanceText.SetText($"Distance : {Mathf.RoundToInt(Vector3.Distance(_player.transform.position, _baseTrm.position))}m");
    }

}
