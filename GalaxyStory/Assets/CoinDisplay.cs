using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    //private TMP_Text coinUI;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        //coinUI = GetComponent<TMP_Text>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //string[] temp = coinUI.text.Split(':');
        //coinUI.text = temp[0] + ":" + PlayerPrefsManager.coins;

        string[] temp = text.text.Split(':');
        text.text = temp[0] + ":" + PlayerPrefsManager.coins;

        ////coinUI.text = "" + coins.ToString();
    }
}
