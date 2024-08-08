using System;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stat/Player")]
public class PlayerStat : CharacterStat
{
    protected override void OnEnable()
    {
        base.OnEnable();

        Type playerStatType = typeof(PlayerStat);

        foreach (StatType statType in Enum.GetValues(typeof(StatType)))
        {
            string fieldName = LowerFirstChar(statType.ToString()); //enum�� �ձ��ڸ� �ҹ��ں���

            try
            {
                FieldInfo playerStatField = playerStatType.GetField(fieldName);
                Stat stat = playerStatField.GetValue(this) as Stat;
                _statDictionary.Add(statType, stat);
            }
            catch (Exception ex)
            {
                Debug.LogError($"There are no stat filed in player : {fieldName}, msg: {ex.Message}");
            }
        }

    }

    public Stat GetStatByType(StatType statType)
    {
        return _statDictionary[statType];
    }

    private string LowerFirstChar(string input)
    {
        return char.ToLower(input[0]) + input.Substring(1);
    }
}