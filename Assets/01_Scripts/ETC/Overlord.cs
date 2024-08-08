using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlord : MonoBehaviour
{
    [SerializeField] private float _playerCheckerDistance;
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private Transform _spawnTrm;
    private Collider[] _contain;
    private Coroutine coroutine;

    private List<GameObject> _spawnList;
    private void Awake()
    {
        _contain = new Collider[1];
        _spawnList = new List<GameObject>();
    }


    private void Update()
    {
        if (IsPlayerDetected()) //�÷��̾ ��Ÿ� �ȿ� ��������
        {
            if (coroutine == null) //���� ����� �ڷ�ƾ�� ���ٸ�
            {
                coroutine = StartCoroutine("StartSpawn");
            }
        }
        else // �÷��̾ ��Ÿ� �ۿ� ������
        {
            if (coroutine != null) //�ڷ�ƾ�� �����ҋ�
            {
                StopCoroutine("StartSpawn");
                coroutine = null; //�η� �ٲ㼭 ��ȯ�Ǵ°� �����ְ�
                for (int i = 0; i < _spawnList.Count; ++i)
                {
                    if (_spawnList[i] != null && !_spawnList[i].GetComponent<Enemy>().IsPlayerDetected())//���� ��ȯ�� �ֵ��� �÷��̾ �i�� ���̶�� �Ⱦ�����
                    {
                        _spawnList[i].gameObject.SetActive(false);
                    }
                }
                _spawnList = new List<GameObject>();
            }
        }
    }

    private IEnumerator StartSpawn()
    {
        var Wait = new WaitForSeconds(5);
        while (true)
        {
            yield return Wait;
            for (int i = 0; i < 5; ++i)
            {
                _spawnList.Add(PoolManager.SpawnFromPool("EnemyLv1", _spawnTrm.position));
            }
        }
    }

    private Collider IsPlayerDetected()
    {
        int cnt = Physics.OverlapSphereNonAlloc(transform.position, _playerCheckerDistance, _contain, _whatIsPlayer);
        return cnt >= 1 ? _contain[0] : null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _playerCheckerDistance);
    }
}
