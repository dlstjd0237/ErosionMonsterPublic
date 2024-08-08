using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/QuestListSO")]
public class QuestListSO : ScriptableObject
{
    [SerializeField] private List<QuestSO> _questList; public List<QuestSO> QuestList { get { return _questList; } }
}
