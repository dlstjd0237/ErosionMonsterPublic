using UnityEngine;

public class AudioSet : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartAudio(AudioClip clip)
    {
        _audioSource.pitch = Random.Range(0.75f, 1f);
        _audioSource.clip = clip;
        _audioSource.Play();
        Invoke(nameof(GameObjectSetActive), 2);
    }

    private void GameObjectSetActive() => gameObject.SetActive(false);
}
