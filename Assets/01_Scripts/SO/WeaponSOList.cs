using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponSOList  ")]
public class WeaponSOList : ScriptableObject
{
    [SerializeField] private List<WeaponSO> _list; public List<WeaponSO> SOList { get { return _list; } }
}
