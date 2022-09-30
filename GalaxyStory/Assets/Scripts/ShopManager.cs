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
    public GameObject aaa;




    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        coinUI.text = "" + coins.ToString();
        LoadPanels();
        CheckPurchaseable();

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            itemNumber[i] = PlayerPrefs.GetInt("itemNumber_" + i);                //구매된 값 불러오기
            //this.GetComponentsInChildren<Button>();
            if (itemNumber[i] == 1)
            {
                //this.GetComponent<Button>()
                //this.GetComponent<Button>().enabled = false;
            }
            //
        }

    }
    void enabledBtn()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            itemNumber[i] = PlayerPrefs.GetInt("itemNumber_" + i);                //구매된 값 불러오기
            //this.GetComponentsInChildren<Button>();
            if (itemNumber[i] == 1)
            {
                //this.GetComponentsInChildren<Button>(false);
                //this.GetComponent<Button>().enabled = false;

            }
            //
        }
    }

    //public void Addcoins()                            //코인얻기
    //{
    //    coins++;
    //    coinUI.text = "" + coins.ToString();
    //    CheckPurchaseable();
    //}

    public void CheckPurchaseable()                         //구매버튼 활성화 체크
    {
        //if ()                                                    //      if (PurchaseItem 이 실행됐었다면)  
        //{                                                        //     {
        //                                                         //     이전 버튼 setactive 꺼짐;
        //                                                         //     바꾸기 버튼이 setactive 켜짐;
        //                                                         //                                              --------------이러면 전체 버튼이 꺼졌다 커졌다 해서
        //                                                         //                                                            눌렀던 버튼과 연결해야할듯
        //}                                                        //     }          
        //else                                                       // else   
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].basecost)           //만약 가지고 있는 코인이 아이템의 가격과 같거나 클 때
                myPurchaseBtns[i].interactable = true;      //구매버튼 활성화
            else                                            //아니면 비활성화
                myPurchaseBtns[i].interactable = false;

        }


    }


    public int[] itemNumber = new int[8];



    public void ChangeItem()
    {

        //GameObject.Find("코스튬이름").SetActive(true);            // 구매 버튼 목록,코스튬 연결필요한데 어떻게하지,,,
        // 다른 scene에 있는 게임오브젝트 setactive 껐다켰다 

    }


    public void PurchaseItem(int btnNo)                              //구매하기
    {
        //if ()                                                        //  if (void purchaseitem 을 한번도 실행하지 않았다면)
        //{                                                             

        if (itemNumber[btnNo] == 0)
        {

            if (coins >= shopItemsSO[btnNo].basecost)                //만약 가지고 있는 코인이 아이템의 가격과 같거나 클 때
            {
                coins = coins - shopItemsSO[btnNo].basecost;         //코인에서 아이템 가격 차감
                coinUI.text = "" + coins.ToString();                 //코인입력
                CheckPurchaseable();                                 //다시 구매버튼 활성화 체크

                itemNumber[btnNo] = 1;                               //구매값 저장
                PlayerPrefs.SetInt("itemNumber_" + btnNo, 1);

            }
            else
            {
                ChangeItem();
            }
        }


        //}
        // else                                                         // 실행했었다면
        //     ChangeItem();                                            // 아이템 바꾸기 

    }


    public void LoadPanels()                              //아이템 이름 가격 불러오기
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTXt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "" + shopItemsSO[i].basecost.ToString();

        }
    }
}
