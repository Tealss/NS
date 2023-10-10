using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);

    }
}

[System.Serializable]
public class Items
{
    public string itemName; // 아이템 이름
    public int itemID; // 아이템 ID 또는 고유 식별자
    public int itemQuantity; // 아이템 수량

    public Items(string name, int id)
    {
        itemName = name;
        itemID = id;
        itemQuantity = 1; // 기본적으로 아이템 수량은 1로 설정
    }
}
