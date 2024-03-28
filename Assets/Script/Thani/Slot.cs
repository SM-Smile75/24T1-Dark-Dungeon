using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public ItemInInventory thisItem { get; set; }
    public SlotLabel thisTag;

    public void OnPointerClick(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Left)
        {
            if(Inventory.carriedItem == null) return;
            if(thisTag != SlotLabel.Misc && Inventory.carriedItem.thisItem.thisLabel != thisTag)
            SetItem(Inventory.carriedItem);
        }
    }

    public void SetItem(ItemInInventory item)
    {
        Inventory.carriedItem = null;

        item.slot.thisItem = null;

        thisItem = item;
        thisItem.slot = this;
        thisItem.transform.SetParent(transform);
        thisItem.canvas.blocksRaycasts = true;
    }
}
