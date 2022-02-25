using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISysWin : WindowBase
{
    public delegate void ButtonClick();
    public ButtonClick buttonClick;

    public override void Init(Transform parent, string path)
    {
        base.Init(parent, path);

        var btnGroup = _ui.transform.Find("BtnGroup");
        for (int i = 0; i < btnGroup.childCount; i++)
        {
            Button button = btnGroup.GetChild(i).GetComponent<Button>();
            button.onClick.AddListener(() => OnButtonClick(button));
        }
        Button confirmBtn = _ui.transform.Find("ConfirmBtn").GetComponent<Button>();
    }

    private void OnButtonClick(Button button)
    {
        buttonClick?.Invoke();
    }
}
