using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private string _weaponName; public string WeaponName { get { return _weaponName; } }
    [SerializeField] private Sprite _weaponSprite; public Sprite WeaponSprite { get { return _weaponSprite; } }
    [TextArea]
    [SerializeField] private string _description; public string Description { get { return _description; } }
    [SerializeField] private WeaponType _weaponType; public WeaponType WeaponType { get { return _weaponType; } }
}
