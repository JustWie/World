using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerListener : EventTrigger
{
    public delegate void VoidDelegate(GameObject go);
    public VoidDelegate onSelect;
    public VoidDelegate onDeselect;
    public VoidDelegate onBeginDrag;
    public VoidDelegate onDrag;
    public VoidDelegate onEndDrag;

    public override void OnSelect(BaseEventData eventData)
    {
        onSelect?.Invoke(gameObject);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        onDeselect?.Invoke(gameObject);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        onBeginDrag?.Invoke(gameObject);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        onDrag?.Invoke(gameObject);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        onEndDrag?.Invoke(gameObject);
    }

    public static EventTriggerListener Get(GameObject go)
    {
        EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
        if (listener == null)
        {
            listener = go.AddComponent<EventTriggerListener>();
        }
        return listener;
    }
}
