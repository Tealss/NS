using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class ShopPopupClick : MonoBehaviour
{
 
    public void OnButtonClick()
    {
        
        GameObject Pre = Resources.Load<GameObject>(ShopClick.TempItem);
        GameObject Inven = GameObject.Find("Main Camera");
        Transform Pos = Inven.transform;
        Pos = Pos.Find("Canvas");
        Pos = Pos.Find("Background");
        Pos = Pos.Find("Iventory");
        Pos = Pos.Find("Scroll View");
        Pos = Pos.Find("Viewport");
        Pos = Pos.Find("Content");

        GameObject item = Instantiate(Pre, Pos);

        //Pos = Pos.Find("Canvas");
        //Pos = Pos.Find("Background");
        //Pos = Pos.Find("Iventory");
        //Pos = Pos.Find("Scroll View");
        //Pos = Pos.Find("Viewport");
        //Pos = Pos.Find("Content");

    }
}
