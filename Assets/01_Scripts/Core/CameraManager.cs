using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoSingleton<CameraManager>
{
    private CinemachineVirtualCamera[] _cams = new CinemachineVirtualCamera[2];

    public void SetCamera(CinemachineVirtualCamera cam, int idx)
    {
        _cams[idx] = cam;
    }

    public void ShakeCamera(Vector3 offSet, float amplitudeGain, float frequencyGain, float duration)
    {
        StartCoroutine(ShakeCameraCoroutine(offSet, amplitudeGain, frequencyGain, duration));
    }

    private IEnumerator ShakeCameraCoroutine(Vector3 offSet, float amplitudeGain, float frequencyGain, float duration)
    {

        var cam1 = _cams[0].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        var cam2 = _cams[0].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cam1.m_PivotOffset = offSet;
        cam1.m_AmplitudeGain = amplitudeGain;
        cam1.m_FrequencyGain = frequencyGain;

        cam2.m_PivotOffset = offSet;
        cam2.m_AmplitudeGain = amplitudeGain;
        cam2.m_FrequencyGain = frequencyGain;
        yield return new WaitForSeconds(duration);
        cam1.m_PivotOffset = Vector3.zero;
        cam1.m_AmplitudeGain = 0;
        cam1.m_FrequencyGain = 0;

        cam2.m_PivotOffset = Vector3.zero;
        cam2.m_AmplitudeGain = 0;
        cam2.m_FrequencyGain = 0;
    }
}
