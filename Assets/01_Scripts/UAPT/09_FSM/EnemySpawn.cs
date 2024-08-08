using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private Transform[] _spawnTrm;
    private List<Enemy> _enemyList = new List<Enemy>();

    private void Start()
    {
        StartCoroutine(EnemySpawnCoroutine());
    }

    public void AllKillEnemy()
    {
        foreach (var item in _enemyList)
        {
            item.gameObject.SetActive(false);
        }
        _enemyList.Clear();
    }

    private IEnumerator EnemySpawnCoroutine()
    {
        var wait = new WaitForSeconds(15);
        while (true)
        {
            yield return wait;
            foreach (var item in _enemyList)
            {
                if (!item.IsPlayerDetected())
                {
                    item.gameObject.SetActive(false);
                }
            }
            _enemyList.Clear();


            for (int i = 0; i < 15; ++i)
            {
                int randEnemy = Random.Range(0, 100);
                int rand = Random.Range(0, _spawnTrm.Length);
                if (randEnemy > 80)
                {
                    _enemyList.Add(PoolManager.SpawnFromPool("EnemyLv2", _spawnTrm[rand].position).GetComponent<Enemy>());

                }
                else
                {
                    for (int j = 0; j < 6; j++)
                    {
                        _enemyList.Add(PoolManager.SpawnFromPool("EnemyLv1", _spawnTrm[rand].position).GetComponent<Enemy>());
                    }
                }

            }

        }
    }
}
