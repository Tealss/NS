using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;

public class ItemOption : MonoBehaviour
{

    [Header("#Popup")]
    public GameObject popupWindow;
    private bool isPopupActive = false;
    public bool isOption = false;


    public void OnPointerEnter()
    {
        isPopupActive = true;
        popupWindow.SetActive(true);

    }

    public void OnPointerExit()
    {
        Invoke("TimeCheck", 0.001f);
    }

    public void optionON()
    {
        isOption = true;
    }
    public void optionOFF()
    {
        if (popupWindow.GetComponent<ItemOption>().isOption)
        {
            isOption = false;
            isPopupActive = false;
            popupWindow.SetActive(false);
        }
    }

    public void TimeCheck()
    {
        if (!popupWindow.GetComponent<ItemOption>().isOption)
        {
            isPopupActive = false;
            popupWindow.SetActive(false);
        }

    }

}