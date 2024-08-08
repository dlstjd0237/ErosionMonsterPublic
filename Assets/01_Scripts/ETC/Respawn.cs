using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System;
using UnityEngine.Events;

public class Respawn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _respawnText;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _spawnTrm;
    [SerializeField] private Transform _spawningParticleTrm;
    [SerializeField] private UnityEvent _spawnEvent;
    private AudioSource _audio;
    private Coroutine _respawnCoroutine;
    private void OnEnable()
    {
        _audio = GetComponent<AudioSource>();
        _inputReader.ReSpawnEvent += HandleReSpawn;
    }

    private void HandleReSpawn()
    {
        StartRespawn();
    }

    private void OnDisable()
    {
        _inputReader.ReSpawnEvent -= HandleReSpawn;
    }

    public void StartRespawn()
    {
        if (_respawnCoroutine != null)
        {
            StopCoroutine("RespawnCourutine");
            _respawnCoroutine = null;
        }

        _spawningParticleTrm.gameObject.SetActive(true);
        _respawnCoroutine = StartCoroutine("RespawnCourutine");
    }

    public void StopRespawn()
    {
        _spawningParticleTrm.gameObject.SetActive(false);

        StopCoroutine("RespawnCourutine");
        _respawnCoroutine = null;
    }

    private IEnumerator RespawnCourutine()
    {
        _audio.Stop();
        _audio.volume = 0.5f;
        _audio.Play();
        for (int i = 3; i >= 0; --i)
        {
            var Text = Instantiate(_respawnText, transform);
            RectTransform rect = Text.rectTransform;
            rect.anchoredPosition = new Vector3(0, 0);
            if (i == 0)
            {
                QuestManager.Instance.Goal(2);

                Text.SetText($"귀환에 성공 하였습니다.");
                _spawnEvent?.Invoke();
                _spawningParticleTrm.gameObject.SetActive(false);
                Player player = PlayerManager.Instance.CurrentPlayer;
                player.HealthCompo.HealthHealing(player.Stat.maxHealth.GetValue());
                player.transform.position = new Vector3(_spawnTrm.position.x, player.transform.position.y, _spawnTrm.position.z);
                DOTween.To(() => _audio.volume, x => _audio.volume = x, 0, 1);
                _audio.Stop();
            }
            else
                Text.SetText($"귀환까지 {i}초 남았습니다.");
            Text.DOFade(0, 1);
            DOTween.To(() => rect.anchoredPosition, x => rect.anchoredPosition = x, new Vector2(0, 200), 1).OnComplete(() =>
            {
                Destroy(Text);
            });
            yield return new WaitForSeconds(1);
        }

    }
}
