using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UAPT.Utile;
using UnityEngine.Events;

public class BaseUI : MonoBehaviour
{
    private UIDocument _doc;
    private Dictionary<TabBarType, Button> _tabBarDictionary;
    private Dictionary<WeaponType, Button> _weaponBtnDictionary;

    private TabBarType _currentType = TabBarType.Upgrade;
    private VisualElement _infoContain;

    private Slider _masterSlider;
    private Slider _musicSlider;
    private Slider _sFXSlider;

    [SerializeField] private UnityEvent _baseExit;
    [SerializeField] private UnityEvent<Sprite> _weaponChangeEvent;
    [SerializeField] private WeaponSOList _weaponSOList;

    [Header("AudioSetting")]
    [SerializeField] private AudioClip _hoverSound;
    [SerializeField] private AudioClip _clikeSound;
    [SerializeField] private AudioClip _upGradeSound;
    #region Upgrade UI Setting
    private VisualElement[] _btnContainer = new VisualElement[3];
    [SerializeField] private List<UpgradeUIBtnSO> _upgradeUIBtn1;
    [SerializeField] private List<UpgradeUIBtnSO> _upgradeUIBtn2;
    [SerializeField] private List<UpgradeUIBtnSO> _upgradeUIBtn3;
    [SerializeField] private VisualTreeAsset _treeAsset;
    #endregion
    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        TabbarDictionaryInit(); //텝바 기능이랑 딕셔너리 추가
        UpgradeBtnInit();  //업그레이드 버튼 UI에 추가
        WeaponBtnInit();
        SettingSliderInit();
        _doc.rootVisualElement.Q<Label>("base_ui_exit-btn").RegisterCallback<ClickEvent>(evt =>
        {
            ToggleRootElement();
            _baseExit?.Invoke();
        });
    }

    private void SettingSliderInit()
    {
        var soundManager = SoundManager.Instance;

        var root = _doc.rootVisualElement;

        root.Q<Button>("exit-btn").clicked += () => Application.Quit();

        _masterSlider = root.Q<Slider>("master_audio-slider");
        _masterSlider.value = 0.5f;
        _musicSlider = root.Q<Slider>("sound_audio-slider");
        _musicSlider.value = 0.5f;
        _sFXSlider = root.Q<Slider>("vfx_audio-slider");
        _sFXSlider.value = 0.5f;

        soundManager.VolumeSetMaster(0.5f);
        soundManager.VolumeSetMusic(0.5f);
        soundManager.VolumeSetSFX(0.5f);

        _masterSlider.RegisterCallback<ChangeEvent<float>>(evt =>
        {
            soundManager.VolumeSetMaster(evt.newValue);
        });
        _musicSlider.RegisterCallback<ChangeEvent<float>>(evt =>
        {
            soundManager.VolumeSetMusic(evt.newValue);
        });
        _sFXSlider.RegisterCallback<ChangeEvent<float>>(evt =>
        {
            soundManager.VolumeSetSFX(evt.newValue);
        });
    }

    private void WeaponBtnInit()
    {
        VisualElement root = _doc.rootVisualElement.Q<VisualElement>("aircraft_ui_info_contain-box");
        Label titleLabel = root.Q<Label>("weapon_info_title-label");
        Label descriptionLabel = root.Q<Label>("weapon_info-label");
        _weaponBtnDictionary = new Dictionary<WeaponType, Button>();
        for (int i = 0; i < 3; ++i)
        {
            WeaponSO so = _weaponSOList.SOList[i];
            string key = so.WeaponType.ToString().ToLower();

            Button btn = root.Q<Button>($"weapon_choice_{key}-btn");
            btn.RegisterCallback<MouseEnterEvent>(evt =>
            {
                PoolManager.SpawnFromPool("VFXSound", transform.position).GetComponent<AudioSet>().StartAudio(_hoverSound);
                titleLabel.text = so.WeaponName;
                descriptionLabel.text = so.Description;
            });
            btn.RegisterCallback<MouseOutEvent>(evt =>
            {
                titleLabel.text = "공격 모드";
                descriptionLabel.text = "다양한 모드로 즐겨보세요.";
            });
            btn.RegisterCallback<ClickEvent>(evt =>
            {
                PoolManager.SpawnFromPool("VFXSound", transform.position).GetComponent<AudioSet>().StartAudio(_clikeSound);

                PlayerManager.Instance.CurrentPlayer.WeaponMachine.ChangeWeapon(so.WeaponType);
                _weaponChangeEvent?.Invoke(so.WeaponSprite);
            });
            _weaponBtnDictionary.Add(so.WeaponType, btn);
        }
    }

    public void ToggleRootElement() =>
        ToolKitUtile.SetToggle(_doc.rootVisualElement.Q<VisualElement>("base_ui_contain-box"), "on");
    private void UpgradeBtnInit()
    {
        var root = _doc.rootVisualElement;
        _btnContainer[0] = root.Q<VisualElement>("upgrade_ui_airframe_btn_contain-box");
        _btnContainer[1] = root.Q<VisualElement>("upgrade_ui_weapons__btn_contain-box");
        _btnContainer[2] = root.Q<VisualElement>("upgrade_ui_crystal_btn_contain-box");


        for (int i = 0; i < _upgradeUIBtn1.Count; i++)
        {
            if (i % 2 == 0)
                AddUpgradeBtn(_btnContainer[0], _upgradeUIBtn1[i], true);
            else
                AddUpgradeBtn(_btnContainer[0], _upgradeUIBtn1[i], false);
        }

        for (int i = 0; i < _upgradeUIBtn2.Count; i++)
        {
            if (i % 2 == 0)
                AddUpgradeBtn(_btnContainer[1], _upgradeUIBtn2[i], true);
            else
                AddUpgradeBtn(_btnContainer[1], _upgradeUIBtn2[i], false);
        }

        for (int i = 0; i < _upgradeUIBtn3.Count; i++)
        {
            if (i % 2 == 0)
                AddUpgradeBtn(_btnContainer[2], _upgradeUIBtn3[i], true);
            else
                AddUpgradeBtn(_btnContainer[2], _upgradeUIBtn3[i], false);
        }
    }

    private void AddUpgradeBtn(VisualElement contain, UpgradeUIBtnSO BaseSo, bool angle)
    {
        var so = Instantiate(BaseSo);
        var templet = _treeAsset.Instantiate().Q<VisualElement>();

        templet.Q<VisualElement>("upgrade_ui_btn_contain-box").style.backgroundImage = so.Sprite.texture;
        templet.Q<Label>("upgrade_ui_info-label").text = so.Info;

        var infoLabel = templet.Q<Label>("upgrade_ui_title-label");
        infoLabel.text = so.Title;

        var priceLabel = templet.Q<Label>("upgrade_ui_price-label");
        priceLabel.text = $"Crystal x{so.GetPrice().ToString()}";

        var Btn = templet.Q<Button>("upgrade_ui-btn");
        Btn.RegisterCallback<ClickEvent>(evt =>
        {
            if (so.GetPrice() <= PlayerManager.Instance.CurrentCrystal)
            {
                priceLabel.text = $"Crystal x{ so.DefaultPrice + (so.Level * so.IncreasePrice)}";
                QuestManager.Instance.Goal(3);

                for (int i = 0; i < so.StatPiece.Count; ++i)
                {
                    StatPieceSO pieceSO = so.StatPiece[i];
                    PlayerManager.Instance.CurrentPlayer.Stat.AddStatPoint(pieceSO.StatType, pieceSO.AddPointAmount);
                }
                PoolManager.SpawnFromPool("VFXSound", transform.position).GetComponent<AudioSet>().StartAudio(_upGradeSound);
                PlayerManager.Instance.CrystalUseSOLevelUP(so.GetPrice(), ref so);
            }

        });
        Btn.RegisterCallback<MouseEnterEvent>(evt =>
        {
            PoolManager.SpawnFromPool("VFXSound", transform.position).GetComponent<AudioSet>().StartAudio(_hoverSound);

            infoLabel.style.unityBackgroundImageTintColor = new Color(1, 1, 1, 1);
            infoLabel.style.color = new Color(0, 0, 0, 1);
        });
        Btn.RegisterCallback<MouseOutEvent>(evt =>
        {
            infoLabel.style.unityBackgroundImageTintColor = new Color(1, 1, 1, 0);
            infoLabel.style.color = new Color(1, 1, 1, 1);
        });
        if (angle == true)
        {
            templet.style.alignItems = Align.FlexEnd;
        }
        contain.Add(templet);
    }

    private void TabbarDictionaryInit()
    {
        _infoContain = _doc.rootVisualElement.Q<VisualElement>("base_ui_info_contain-box");
        _tabBarDictionary = new Dictionary<TabBarType, Button>();
        foreach (TabBarType item in Enum.GetValues(typeof(TabBarType)))
        {
            _tabBarDictionary.Add(item, _doc.rootVisualElement.Q<Button>($"tabbar_ui_{item.ToString().ToLower()}-btn"));
        }

        foreach (TabBarType item in Enum.GetValues(typeof(TabBarType)))
        {
            _tabBarDictionary[item].RegisterCallback<ClickEvent>(evt =>
            {
                PoolManager.SpawnFromPool("VFXSound", transform.position).GetComponent<AudioSet>().StartAudio(_clikeSound);

                _infoContain.style.left = (int)item * 1536 * -1;
                foreach (TabBarType item2 in Enum.GetValues(typeof(TabBarType)))
                {
                    _tabBarDictionary[item2].RemoveFromClassList("on");
                }
                _currentType = item;
                _tabBarDictionary[item].AddToClassList("on");
            });
            _tabBarDictionary[item].RegisterCallback<MouseEnterEvent>(evt =>
            {
                PoolManager.SpawnFromPool("VFXSound", transform.position).GetComponent<AudioSet>().StartAudio(_hoverSound);
            });
        }
        _tabBarDictionary[TabBarType.Upgrade].AddToClassList("on");
    }


}
