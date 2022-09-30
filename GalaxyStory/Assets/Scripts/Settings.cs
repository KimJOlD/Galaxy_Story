using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject settings;
    public Button On;
    public Button Off;
    
    void Start()
    {
        if(PlayerPrefs.GetInt("vbr")==1)
        {
            vibrate = true;
            OnOn();
            OffOff();
        }
        else
        {
            vibrate = false;
            OnOff();
            OffOn();
        }
    }

    void Update()
    {
        
    }
    public void Option()
    {
        Time.timeScale = 0;
        settings.SetActive(true);
    }
    public void Quit()
    {
        Time.timeScale = 1;
        settings.SetActive(false);
    }
    public bool vibrate;
    public void VbrOn()
    {
        vibrate = true;
        OnOn();
        OffOff();
        PlayerPrefs.SetInt("vbr", 1);
    }
    public void VbrOff()
    {
        vibrate = false;
        OnOff();
        OffOn();
        PlayerPrefs.SetInt("vbr", 0);
    }
    void OnOn()
    {
        ColorBlock Oncolor = On.colors;

        Oncolor.normalColor = new Color(1f, 1f, 1f, 1f);
        On.colors = Oncolor;
    }
    void OnOff()
    {
        ColorBlock Oncolor = On.colors;

        Oncolor.normalColor = new Color(0.5f, 0.5f, 0.5f, 1f);
        On.colors = Oncolor;
    }
    void OffOn()
    {
        ColorBlock OffColor = Off.colors;

        OffColor.normalColor = new Color(1f, 1f, 1f, 1f);
        Off.colors = OffColor;
    }
    void OffOff()
    {
        ColorBlock OffColor = Off.colors;

        OffColor.normalColor = new Color(0.5f, 0.5f, 0.5f, 1f);
        Off.colors = OffColor;
    }
}
