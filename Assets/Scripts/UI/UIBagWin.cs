using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using World;

public class UIBagWin : WindowBase
{
    private Transform _content;
    private Dictionary<string, UIBagItem> _items = null;

    public override void Init(Transform parent, string path)
    {
        base.Init(parent, path);

        _items = new Dictionary<string, UIBagItem>();

        var scrollView = _ui.transform.Find("Scroll View");
        var viewport = scrollView.Find("Viewport");
        _content = viewport.Find("Content");

        var button = _ui.transform.Find("Button").GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    public void RefreshContent()
    {
        var data = Singleton<BagData>.ins.GetBagData();
        foreach (string type in data.Keys)
        {
            UIBagItem item = null;
            if (!_items.ContainsKey(type))
            {
                item = UIBagItem.Create(_content, type);
                _items.Add(type, item);
            }
            else
                item = _items[type];

            if (data[type].Count <= 0)
            {
                item.Destroy();
                _items.Remove(type);
            }
            else
                item.count.text = data[type].Count.ToString();
        }
    }

    private void OnButtonClick()
    {
        Singleton<BagData>.ins.DeleteItem("ComplementItem", 1);
        RefreshContent();
    }
}
