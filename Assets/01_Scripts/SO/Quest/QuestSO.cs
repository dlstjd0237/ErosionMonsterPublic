using UnityEngine;

[CreateAssetMenu(menuName = "SO/QuestSO")]
public class QuestSO : ScriptableObject
{
    [SerializeField] private int _sequence; public int Sequence { get { return _sequence; } }
    [SerializeField] private string _questInfo; public string QuestInfo { get { return _questInfo; } }
    [SerializeField] private int _goal; public int Goal { get { return _goal; } set { _goal = value; } }
}
