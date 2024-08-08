using UnityEngine;

public class PoolReturn : MonoBehaviour
{
    private void OnDisable()
    {
        PoolManager.ReturnToPool(gameObject);
    }
}
