using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using World;

public class PlayerInfoWin : WindowBase
{
    private Slider _slider;

    public override void Init(Transform parent, string path)
    {
        base.Init(parent, path);
        _slider = _ui.transform.Find("Slider").GetComponent<Slider>();

        int maxHp = EntityMgr.ins.GetPlayerData().GetMaxHp();
        _slider.maxValue = maxHp;
        RefreshInfo(maxHp);

        Show();

        //Singleton<PlayerData>.ins.UnderFireAction += RefreshInfo;
    }

    private void RefreshInfo(int value)
    {
        _slider.value = value;
    }
}
