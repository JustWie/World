using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingWin : WindowBase
{
    public override void Init(Transform parent, string path)
    {
        base.Init(parent, path);

        var button = _ui.transform.Find("QuiteButton").GetComponent<Button>();
        button.onClick.AddListener(OnQuite);
    }

    private void OnQuite()
    {
        Application.Quit();
    }
}
