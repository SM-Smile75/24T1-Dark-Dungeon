using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryProgram : MonoBehaviour
{
    public static InventoryProgram Singleton;
    public static ItemInInventory carriedItem;

    [SerializeField] Slot[] slots;

    [SerializeField] Transform draggables;
    [SerializeField] ItemInInventory prefabs;

    [Header("List of Items")]
    [SerializeField] Item[] items;

    void Awake()
    {
        Singleton = this;
    }

    void Update()
    {
        if (carriedItem == null) return;

        carriedItem.transform.position = Input.mousePosition;
    }

    public void SetCarriedItem(ItemInInventory item)
    {
        if(carriedItem != null)
        {
            if (item.slot.thisTag != SlotLabel.Misc && item.slot.thisTag != carriedItem.thisItem.thisLabel) return;
            item.slot.SetItem(carriedItem);
        }

        carriedItem = item;
        carriedItem.canvas.blocksRaycasts = false;
        item.transform.SetParent(draggables);
    }
}
