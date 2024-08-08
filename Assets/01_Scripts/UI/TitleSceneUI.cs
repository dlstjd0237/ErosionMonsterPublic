using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleSceneUI : MonoBehaviour
{
    [SerializeField] private string gameSecenName;
    private UIDocument _doc;
    private VisualElement _contain;
    private VisualElement _background;
    private VisualElement _infoContain;
    private AudioSource _audioSource;
    private void Awake()
    {
        UAPT.UI.FixedScreen.FixedScreenSet();
        _audioSource = GetComponent<AudioSource>();
        _audioSource = GetComponent<AudioSource>();
        _doc = GetComponent<UIDocument>();
        BtnInit();
        DOTween.SetTweensCapacity(2000, 300);
    }

    private void BtnInit()
    {
        var root = _doc.rootVisualElement;
        _contain = root.Q<VisualElement>("contain");
        _background = root.Q<VisualElement>("background_image-box");
        _infoContain = root.Q<VisualElement>("info_contain-box");
        _background.ToggleInClassList("on");
        root.Q<Button>("title_start_btn").clicked += HandleStartBtnCliek;
        root.Q<Button>("title_info_btn").clicked += HandleInfoBtnCliek;
        root.Q<Button>("title_exit_btn").clicked += HandleExitBtnCliek;
        root.Q<Button>("info_exit-btn").clicked += () => { _audioSource.Play(); _infoContain.ToggleInClassList("on"); _contain.ToggleInClassList("on"); };
    }

    private void HandleInfoBtnCliek()
    {
        _audioSource.Play();
        _contain.ToggleInClassList("on");
        _infoContain.ToggleInClassList("on");
    }

    private void HandleExitBtnCliek()
    {
        _audioSource.Play();

        _contain.ToggleInClassList("on");
        _background.ToggleInClassList("on");

        Invoke(nameof(SceneExit), 0.4f);

    }

    private void SceneExit() => Application.Quit();

    private void HandleStartBtnCliek()
    {
        _audioSource.Play();

        _contain.ToggleInClassList("on");
        _background.ToggleInClassList("on");

        Invoke(nameof(SceneChange), 0.4f);
    }

    private void SceneChange() => SceneManager.LoadScene(gameSecenName);

}
