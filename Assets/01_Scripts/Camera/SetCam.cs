using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SetCam : MonoBehaviour
{
    [SerializeField]
    private int idx;
    private CinemachineVirtualCamera _cam;
    private void Awake()
    {
        _cam = GetComponent<CinemachineVirtualCamera>();
        CameraManager.Instance.SetCamera(_cam, idx);
    }
}
