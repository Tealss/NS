using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public CanvasGroup popupPanel;
    public Text popupText;

    public delegate void PopupDelegate(string message);
    public static event PopupDelegate OnPopup;
    void Start()
    {
        OnPopup += ShowPopup;
    }
    public void ShowPopup(string message)
    {
        popupText.text = message;
        popupPanel.alpha = 1;
        popupPanel.blocksRaycasts = true;
    }

    public void ClosePopup()
    {
        popupPanel.alpha = 0;
        popupPanel.blocksRaycasts = false;
    }

    public void RaisePopupEvent(string message)
    {
        OnPopup?.Invoke(message);
    }

}
