using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemInInventory : MonoBehaviour, IPointerClickHandler
{
    Image icon;
    public CanvasGroup canvas{get; private set;}
    public Item thisItem{get; set;}
    public Slot slot{get; set;}

    void Awake()
    {
        canvas = GetComponent<CanvasGroup>();
        icon = GetComponent<Image>();
    }

    public void Initialize(Item item, Slot parent)
    {
        slot = parent;
        slot.thisItem = this;
        thisItem = item;
        icon.sprite = item.sprite;
    }

    public void OnPointerClick(PointerEventData data)
    {
        if(data.button == PointerEventData.InputButton.Left)
        {
            InventoryProgram.Singleton.SetCarriedItem(this);
        }
    }
}
