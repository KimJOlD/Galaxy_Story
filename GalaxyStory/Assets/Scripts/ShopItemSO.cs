using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ShopMenu", menuName ="Scriptable object/New shop item",order =1)]
public class ShopItemSO : ScriptableObject
{
    public string title;
    public string description;
    public int basecost;
}
