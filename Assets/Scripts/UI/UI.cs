using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using World;

public class UI
{
    Transform _canvas;
    UISettingWin _settingWin;
    TopMsgWin _topMsgWin;
    PlayerInfoWin _playerInfoWin;
    UIBagWin _bagWin;
    UISysWin _sysWin;

    public void Init()
    {
        GameObject ui = Lib.CreateGameObject("UI/UI");
        _canvas = ui.transform.Find("Canvas");

        Button button = _canvas.transform.Find("Button").GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        Button settingButton = _canvas.transform.Find("SettingButton").GetComponent<Button>();
        settingButton.onClick.AddListener(OnSettingButtonClick);
        Button bagButton = _canvas.transform.Find("BagButton").GetComponent<Button>();
        bagButton.onClick.AddListener(OnBagButtonClick);
        Button sysButton = _canvas.transform.Find("SysButton").GetComponent<Button>();
        sysButton.onClick.AddListener(OnSysButtonClick);

        InitWin();
    }

    private void InitWin()
    {
        _settingWin = new UISettingWin();
        _settingWin.Init(_canvas, "UI/SettingWin");

        _topMsgWin = new TopMsgWin();
        _topMsgWin.Init(_canvas, "UI/TopMsg");

        _playerInfoWin = new PlayerInfoWin();
        _playerInfoWin.Init(_canvas, "UI/PlayerInfo");

        _bagWin = new UIBagWin();
        _bagWin.Init(_canvas, "UI/BagWin");

        _sysWin = new UISysWin();
        _sysWin.Init(_canvas, "UI/SynthesisWin");
        _sysWin.buttonClick = OnBagButtonClick;
    }

    private void OnButtonClick()
    {
        //var atk = Singleton<PlayerData>.ins.GetATK();
        //Singleton<BossData>.ins.UnderFire(atk);
        EntityMgr.ins.XXX();
    }

    private void OnSettingButtonClick()
    {
        _settingWin.Show();
    }

    private void OnBagButtonClick()
    {
        BagMgr.ins.RefreshItem();
        _bagWin.Show();
    }

    private void OnSysButtonClick()
    {
        _sysWin.Show();
    }
}
