using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public player player;
    public Text timeText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timeText.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;
        string formattedTime = currentTime.ToString("HH:mm:ss");

        timeText.text = "Time : " + formattedTime;

    }
}
