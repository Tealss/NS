using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopClick : MonoBehaviour
{
    public static string TempItem;
    public GameObject Pre;

    public void OnButtonClick()
    {
        GameObject Test;
        TempItem = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(TempItem);
    }
}
