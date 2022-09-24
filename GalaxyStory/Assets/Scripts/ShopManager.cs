using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
            shopPanelsGO[i].SetActive(true);
        coinUI.text = "" + coins.ToString();
        LoadPanels();
        CheckPurchaseable();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Addcoins()
    {
        coins++;
        coinUI.text = "" + coins.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].basecost)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
           
        }
        

    }

    //void DisablePurchaseButton()
    //{
    //    myPurchaseBtns.interactable = false;
    //    myPurchaseBtns.trasform

    //}

    public void PurchaseItem(int btnNo)
    {
        if (coins >= shopItemsSO[btnNo].basecost)
        {
            coins = coins - shopItemsSO[btnNo].basecost;
            coinUI.text = "" + coins.ToString();
            CheckPurchaseable();

        }
    }


    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTXt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "" + shopItemsSO[i].basecost.ToString();

        }
    }
}
