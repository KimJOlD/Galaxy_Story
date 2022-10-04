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
            itemNumber[i] = PlayerPrefs.GetInt("itemNumber_" + i);                //���ŵ� �� �ҷ�����
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
            itemNumber[i] = PlayerPrefs.GetInt("itemNumber_" + i);                //���ŵ� �� �ҷ�����
            //this.GetComponentsInChildren<Button>();
            if (itemNumber[i] == 1)
            {
                //this.GetComponentsInChildren<Button>(false);
                //this.GetComponent<Button>().enabled = false;

            }
            //
        }
    }

    //public void Addcoins()                            //���ξ��
    //{
    //    coins++;
    //    coinUI.text = "" + coins.ToString();
    //    CheckPurchaseable();
    //}

    public void CheckPurchaseable()                         //���Ź�ư Ȱ��ȭ üũ
    {
        //if ()                                                    //      if (PurchaseItem �� ����ƾ��ٸ�)  
        //{                                                        //     {
        //                                                         //     ���� ��ư setactive ����;
        //                                                         //     �ٲٱ� ��ư�� setactive ����;
        //                                                         //                                              --------------�̷��� ��ü ��ư�� ������ Ŀ���� �ؼ�
        //                                                         //                                                            ������ ��ư�� �����ؾ��ҵ�
        //}                                                        //     }          
        //else                                                       // else   
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].basecost)           //���� ������ �ִ� ������ �������� ���ݰ� ���ų� Ŭ ��
                myPurchaseBtns[i].interactable = true;      //���Ź�ư Ȱ��ȭ
            else                                            //�ƴϸ� ��Ȱ��ȭ
                myPurchaseBtns[i].interactable = false;

        }


    }


    public int[] itemNumber = new int[8];



    public void ChangeItem()
    {

        //GameObject.Find("�ڽ�Ƭ�̸�").SetActive(true);            // ���� ��ư ���,�ڽ�Ƭ �����ʿ��ѵ� �������,,,
        // �ٸ� scene�� �ִ� ���ӿ�����Ʈ setactive �����״� 

    }


    public void PurchaseItem(int btnNo)                              //�����ϱ�
    {
        //if ()                                                        //  if (void purchaseitem �� �ѹ��� �������� �ʾҴٸ�)
        //{                                                             

        if (itemNumber[btnNo] == 0)
        {

            if (coins >= shopItemsSO[btnNo].basecost)                //���� ������ �ִ� ������ �������� ���ݰ� ���ų� Ŭ ��
            {
                coins = coins - shopItemsSO[btnNo].basecost;         //���ο��� ������ ���� ����
                coinUI.text = "" + coins.ToString();                 //�����Է�
                CheckPurchaseable();                                 //�ٽ� ���Ź�ư Ȱ��ȭ üũ

                itemNumber[btnNo] = 1;                               //���Ű� ����
                PlayerPrefs.SetInt("itemNumber_" + btnNo, 1);

            }
            else
            {
                ChangeItem();
            }
        }


        //}
        // else                                                         // �����߾��ٸ�
        //     ChangeItem();                                            // ������ �ٲٱ� 

    }


    public void LoadPanels()                              //������ �̸� ���� �ҷ�����
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTXt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "" + shopItemsSO[i].basecost.ToString();

        }
    }
}
