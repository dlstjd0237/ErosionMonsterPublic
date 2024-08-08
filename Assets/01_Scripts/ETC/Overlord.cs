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
        if (IsPlayerDetected()) //플레이어가 사거리 안에 들어왔을떄
        {
            if (coroutine == null) //만약 실행된 코루틴이 없다면
            {
                coroutine = StartCoroutine("StartSpawn");
            }
        }
        else // 플레이어가 사거리 밖에 있을때
        {
            if (coroutine != null) //코루틴이 존재할떄
            {
                StopCoroutine("StartSpawn");
                coroutine = null; //널로 바꿔서 소환되는거 막아주고
                for (int i = 0; i < _spawnList.Count; ++i)
                {
                    if (_spawnList[i] != null && !_spawnList[i].GetComponent<Enemy>().IsPlayerDetected())//만약 소환된 애들이 플레이어를 쫒는 중이라면 안없에기
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
