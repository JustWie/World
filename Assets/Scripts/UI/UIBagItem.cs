using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using World;

public class UIBagItem
{
    public Image image { get; private set; }
    public Text name { get; private set; }
    public Text count { get; private set; }
    private Image _bg;
    private GameObject _item;

    public UIBagItem(Transform parent)
    {
        _item = Lib.CreateGameObject("UI/Item");
        _item.transform.SetParent(parent);

        _bg = _item.GetComponent<Image>();
        var button = _item.transform.Find("Button").GetComponent<Button>();
        var listener = EventTriggerListener.Get(button.gameObject);
        listener.onSelect = OnSelect;
        listener.onDeselect = OnDeselect;
        button.onClick.AddListener(() => OnClick(button));

        image = button.GetComponent<Image>();
        name = button.transform.Find("Desc").GetComponent<Text>();
        count = button.transform.Find("Count").GetComponent<Text>();
    }

    ~UIBagItem(){}

    public static UIBagItem Create(Transform parent, string type)
    {
        UIBagItem item = new UIBagItem(parent);
        item.image.sprite = Lib.CreateSprite(type);
        item.name.text = type;
        return item;
    }

    public void Destroy()
    {
        Object.Destroy(_item);
    }

    private void OnSelect(GameObject go)
    {
        _bg.color = Color.green;
    }

    private void OnDeselect(GameObject go)
    {
        _bg.color = new Color(0, 0, 0, 0);
    }

    private void OnClick(Button button)
    {

    }
}
