using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using World;

public class TopMsgWin : WindowBase
{
    private Slider _slider;
    private Image _fill;
    private Image _image;
    private Text _text;

    public override void Init(Transform parent, string path)
    {
        base.Init(parent, path);
        _image = _ui.transform.Find("Image").GetComponent<Image>();
        _slider = _ui.transform.Find("Slider").GetComponent<Slider>();
        _fill = _slider.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
        _text = _ui.transform.Find("Text").GetComponent<Text>();

        var name = EntityMgr.ins.GetEntityData(1).GetName();
        _image.sprite = Lib.CreateSprite(name);

        int maxHp = EntityMgr.ins.GetEntityData(1).GetMaxHp();
        _slider.maxValue = maxHp;
        RefreshMsg(1, maxHp);

        Show();

        WorldEvent.ins.RefreshHpAction += RefreshMsg;
    }

    private void RefreshMsg(int uuid, int value)
    {
        if (EntityMgr.ins.IsPlayer(uuid))
            return;

        _slider.value = value;
        _text.text = value.ToString();

        int maxHp = EntityMgr.ins.GetEntityData(1).GetMaxHp();
        if (maxHp * 2 / 3 < value && value <= maxHp)
        {
            if (_text.color != Color.green)
            {
                _text.color = Color.green;
                _fill.color = Color.green;
            }
        }
        else if (maxHp / 3 < value)
        {
            if (_text.color != Color.yellow)
            {
                _text.color = Color.yellow;
                _fill.color = Color.yellow;
            }
        }
        else
        {
            if (_text.color != Color.red)
            {
                _text.color = Color.red;
                _fill.color = Color.red;
            }
        }
    }
}
