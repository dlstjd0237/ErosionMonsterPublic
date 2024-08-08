using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class Base : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private UnityEvent _enterEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                player.InputReader.Console.Disable();
                player.IsStop = true;
                _enterEvent?.Invoke();
            }
        }
    }

    public void ExitBase()
    {
        Vector3 pos = new Vector3(_endPoint.position.x, PlayerManager.Instance.CurrentPlayer.transform.position.y, _endPoint.position.z);
        PlayerManager.Instance.CurrentPlayer.transform.DOLocalMove(pos, 0.5f).OnComplete(() =>
        {
            PlayerManager.Instance.CurrentPlayer.InputReader.Console.Enable();
            PlayerManager.Instance.CurrentPlayer.IsStop = false;
            PlayerManager.Instance.CurrentPlayer.RigodbpdyComp.velocity = Vector3.zero;
            transform.DOKill();
        });

    }
}
