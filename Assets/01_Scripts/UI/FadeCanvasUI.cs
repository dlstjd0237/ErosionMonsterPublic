using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class FadeCanvasUI : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    [SerializeField] private string _changeSceneName;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeInToSceneChange()
    {
        _canvasGroup.DOFade(1, 3).OnComplete(() => SceneManager.LoadScene(_changeSceneName));
    }
}
