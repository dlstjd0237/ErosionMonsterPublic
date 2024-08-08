using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/UpdateUIBtnSO")]
public class UpgradeUIBtnSO : ScriptableObject
{
    [SerializeField] private Sprite _sprite; public Sprite Sprite { get { return _sprite; } }
    [SerializeField] private string _title; public string Title { get { return _title; } }
    [TextArea] [SerializeField] private string _info; public string Info { get { return _info; } }
    [SerializeField] private int _defaultPrice; public int DefaultPrice { get { return _defaultPrice; } }
    [SerializeField] private int _increasePrice; public int IncreasePrice { get { return _increasePrice; } }
    [SerializeField] private List<StatPieceSO> _statPiece; public List<StatPieceSO> StatPiece { get { return _statPiece; } }

     public int Level = 0;
    public int GetPrice() => _defaultPrice + (Level * _increasePrice);


}
