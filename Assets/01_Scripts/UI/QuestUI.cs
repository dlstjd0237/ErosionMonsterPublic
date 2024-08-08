using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DG.Tweening;
public class QuestUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questInfo;
    [SerializeField] private TextMeshProUGUI _questGoal;

    private void Awake()
    {
        QuestManager.Instance.CurrentQuestChangedEvent += HandleQuestChanged;
        QuestManager.Instance.GoalEvent += HandleGoalChanged;
    }



    private void OnDisable()
    {
        QuestManager.Instance.CurrentQuestChangedEvent -= HandleQuestChanged;
        QuestManager.Instance.GoalEvent -= HandleGoalChanged;

    }

    private void FixedUpdate()
    {
        var questManager = QuestManager.Instance;
        HandleGoalChanged(questManager.GoalPercent, questManager.CurrentQuestSO.Goal);
        HandleQuestChanged(questManager.CurrentQuestSO);
    }
    private void HandleGoalChanged(int a, int b)
    {
        _questGoal.SetText($"{a}/{b}");
    }
    private void HandleQuestChanged(QuestSO SO)
    {
        //Sequence seq = DOTween.Sequence();
        //seq.Append(_questInfo.DOFade(0, 2));
 /*       seq.AppendCallback(() => */_questInfo.SetText(SO.QuestInfo);
        //seq.Append(_questInfo.DOFade(1, 2));
        //seq.OnComplete(() => seq.Kill());

    }
}
