using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCrystal : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    private Transform _player;


    private void Start()
    {
        _player = PlayerManager.Instance.CurrentPlayer.transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager.Instance.AddCrystal(1);
            gameObject.SetActive(false);
        }
    }

}
