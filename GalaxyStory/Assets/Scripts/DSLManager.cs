using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Inform
{
    public int money;
    public Inform(int money)
    {
        this.money = money;
    }
}
public class DSLManager : MonoBehaviour
{
    List<Inform> informs = new List<Inform>();
    public TMP_Text[] moneyText;
    public Text tx;

    private void Awake()
    {
        if(!File.Exists(Application.persistentDataPath + "/Characters.json"))
        {
            informs.Add(new Inform(0));

            DataSave();
        }

        DataLoad();
        LoadMoney(GetMoney());
    }
    private void Start()
    {
        informs.Add(new Inform(200));
    }

    public void DataSave() {
        //string jdata_0 = JsonConvert.SerializeObject(characters);
        string jdata_1 = JsonConvert.SerializeObject(informs);
       
        //byte[] bytes_0 = System.Text.Encoding.UTF8.GetBytes(jdata_0);
        byte[] bytes_1 = System.Text.Encoding.UTF8.GetBytes(jdata_1);

        //string format_0 = System.Convert.ToBase64String(bytes_0);
        string format_1 = System.Convert.ToBase64String(bytes_1);       

        //File.WriteAllText(Application.persistentDataPath + "/Characters.json", format_0);
        File.WriteAllText(Application.persistentDataPath + "/Informs.json", format_1);
    }

    public void DataLoad()
    {
        //string jdata_0 = File.ReadAllText(Application.persistentDataPath + "/Characters.json");
        string jdata_1 = File.ReadAllText(Application.persistentDataPath + "/Informs.json");

        //byte[] bytes_0 = System.Convert.FromBase64String(jdata_0);
        byte[] bytes_1 = System.Convert.FromBase64String(jdata_1);

        //string reformat_0 = System.Text.Encoding.UTF8.GetString(bytes_0);
        string reformat_1 = System.Text.Encoding.UTF8.GetString(bytes_1);

        //characters = JsonConvert.DeserializeObject<List<Character>>(reformat_0);
        informs = JsonConvert.DeserializeObject<List<Inform>>(reformat_1);
    }

    public int GetMoney()
    {
        DataLoad();
        return informs[0].money;
    }

    public void SaveMoney(int money)
    {
        DataLoad();
        informs[0].money = money;
        DataSave();
    }

    //Modify the amount of money in the UI
    public void LoadMoney(int money)
    {
        DataLoad();
        for (int i = 0; i < moneyText.Length; i++)
            moneyText[i].text = money.ToString();
        DataSave();
    }
}
