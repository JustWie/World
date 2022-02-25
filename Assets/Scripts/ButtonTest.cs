using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using World;

public class ButtonTest : MonoBehaviour
{
    private Sprite normalSprite;
    private Sprite highlightedSprite;
    private Sprite pressedSprite;
    private Sprite disabledSprite;
    // Start is called before the first frame update
    void Start()
    {
        normalSprite = Lib.CreateSprite("MainItem_Common");
        highlightedSprite = Lib.CreateSprite("MainItem_Excellent");
        pressedSprite = Lib.CreateSprite("MainItem_Perfect");
        disabledSprite = Lib.CreateSprite("MainItem_Inferior");

        Button button = transform.Find("Button").GetComponent<Button>();
        button.GetComponent<Image>().sprite = normalSprite;
        //将按钮变化模式改为 SpriteSwap
        button.transition = Selectable.Transition.SpriteSwap;
        //设置变化状态
        SpriteState state = new SpriteState();
        state.highlightedSprite = highlightedSprite;
        state.pressedSprite = pressedSprite;
        state.disabledSprite = disabledSprite;
        button.spriteState = state;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
