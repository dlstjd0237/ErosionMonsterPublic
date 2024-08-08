using UnityEngine;

public class Crystal : MonoBehaviour, IDamageable
{
    [SerializeField] private Transform _vFXTrm;
    [SerializeField] private int _miningCount = 5;
    [SerializeField] private int _addCrystalAmount = 1;
    [SerializeField] private int _maxMingCount = 5;
    private int _currentMaxMingCount = 0;
    private int _currentMiningCount = 0;

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        _currentMaxMingCount = 0;
        _currentMiningCount = 0;
    }

    private void Mining()
    {
        _currentMiningCount += 1;
        if (_currentMiningCount >= _miningCount)
        {
            _currentMaxMingCount++;
            _currentMiningCount = 0;
            for (int i = 0; i < _addCrystalAmount; i++)
            {
                QuestManager.Instance.Goal(1);

            }
            PlayerManager.Instance.AddCrystal(_addCrystalAmount);
            if (_currentMaxMingCount >= _maxMingCount)
            {
                gameObject.SetActive(false);
                Invoke(nameof(ReSpawnCrystal), 60);
            }
        }
    }

    private void ReSpawnCrystal()
    {
        Init();
        gameObject.SetActive(true);
    }


    public void ApplyeDamage(float damage)
    {
        Mining();
    }

    public void CreateParticle(Transform LookTrm)
    {
        Quaternion rotationOffset = Quaternion.Euler(0, 180, 0);
        GameObject obj = PoolManager.SpawnFromPool("CrystalCrashVFX", _vFXTrm.position);
        obj.transform.LookAt(LookTrm.position);
        obj.transform.rotation *= rotationOffset;
    }
}
