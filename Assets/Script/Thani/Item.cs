using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum SlotLabel { Tools, PowerUps, Misc }
[CreateAssetMenu(menuName = "Items")]

public class Item : ScriptableObject
{
    public Sprite sprite;
    public SlotLabel thisLabel;
}