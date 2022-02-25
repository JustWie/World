using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using World;

public class WindowBase
{
    protected GameObject _ui;
    private Transform _parent;

    public virtual void Init(Transform parent, string path)
    {
        _parent = parent;
        _ui = Lib.CreateGameObject(path);
        _ui.transform.SetParent(parent);
        _ui.transform.localPosition = Vector3.zero;

        _ui.SetActive(false);

        var transform = _ui.transform.Find("CloseButton");
        if (transform)
        {
            var closeButton = transform.GetComponent<Button>();
            closeButton.onClick.AddListener(Hide);
        }
    }

    public void Show()
    {
        if (_ui && !_ui.activeSelf)
        {
            _ui.transform.SetParent(null);
            _ui.transform.SetParent(_parent);
            _ui.SetActive(true);
        }
    }

    private void Hide()
    {
        if (_ui && _ui.activeSelf)
        {
            _ui.SetActive(false);
        }
    }
}
