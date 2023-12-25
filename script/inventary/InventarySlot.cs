using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventarySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventaryItem inventaryItem = dropped.GetComponent<InventaryItem>();
            inventaryItem.parentAfterDrag = transform;
        }
    }

}
