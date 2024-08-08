using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoSingleton<QuestManager>
{
    [SerializeField]
    private QuestListSO _questSOList;
    [SerializeField]
    private Dictionary<int, QuestSO> _questDictionary;
    [SerializeField]
    private AudioClip _completeSound;

    private QuestSO _currentQuestSO = null;
    public QuestSO CurrentQuestSO
    {
        get => _currentQuestSO;
        set
        {
            CurrentQuestChangedEvent?.Invoke(_currentQuestSO);
            _currentQuestSO = value;
        }
    }
    public event Action<QuestSO> CurrentQuestChangedEvent;

    private int _questCompleteCount = 1;
    private int _goalPercent = 0;
    public int GoalPercent => _goalPercent;
    public event Action<int, int> GoalEvent;

    private void Start()
    {
        _questDictionary = new Dictionary<int, QuestSO>();
        for (int i = 0; i < _questSOList.QuestList.Count; ++i)
        {
            _questDictionary.Add(_questSOList.QuestList[i].Sequence, _questSOList.QuestList[i]);
        }
        _currentQuestSO = _questDictionary[_questCompleteCount];

    }

    public QuestSO GetQuest(int Sequence) => _questDictionary[Sequence];

    public void Goal(int questNum)
    {
        if (questNum != _currentQuestSO.Sequence) return;

        var MaxGoal = CurrentQuestSO.Goal;
        _goalPercent += 1;
        GoalEvent?.Invoke(_goalPercent, MaxGoal);
        if (_goalPercent >= MaxGoal)
        {
            _goalPercent = 0;
            _questCompleteCount += 1;
            CurrentQuestSO = _questDictionary[_questCompleteCount];
            PoolManager.SpawnFromPool("VFXSound", transform.position).GetComponent<AudioSet>().StartAudio(_completeSound);
        }
    }
}
