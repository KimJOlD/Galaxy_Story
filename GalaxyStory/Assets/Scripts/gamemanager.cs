using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gamemanager : MonoBehaviour
{
    public GameObject Camera;
    public Transform target;
    public Transform[] enemyZones;
    public GameObject[] enemies;
    public List<int> enemyList;
    public Image[] lifeImage;
    public GameObject gameOverSet;
    public GameObject pause;
    public int money;
    public TMP_Text moneyText;

    public int enemyCntA;
    public int enemyCntB;
    public int enemyCntC;
    public int enemyCntD;

    public player player;

    public float playTime;
    public int stage;
    public Text playTimeTxt;

    public bool isBattle;

    public Vector3 offset;

    void Awake()
    {
        enemyList = new List<int>();
    }
    void Start()
    {
        money = PlayerPrefs.GetInt("coin");
        Time.timeScale = 1;
        SetResolution();
        StartCoroutine(InBattle());
    } 

    IEnumerator InBattle()
    {
        for(int index=0; index < stage; index++)
        {
            int ran = Random.Range(0, 4);
            enemyList.Add(ran);

            switch (ran)
            {
                case 0:
                    enemyCntA +=1;
                    break;
                case 1:
                    enemyCntB +=1;
                    break;
                case 2:
                    enemyCntC +=1;
                    break;
                case 3:
                    enemyCntD +=1;
                    break;
            }
        }
        while (enemyList.Count > 0)
        {
            int ranZone = Random.Range(0, 3);
            GameObject instantEnemy = Instantiate(enemies[enemyList[0]], enemyZones[ranZone].position, enemyZones[ranZone].rotation);
            enemy enemy = instantEnemy.GetComponent<enemy>();
            enemy.target = player.transform;
            enemy.manager = this;
            enemyList.RemoveAt(0);

            yield return new WaitForSeconds(3f);
        }

        while (enemyCntA + enemyCntB + enemyCntC + enemyCntD > 0)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        StageClear();
    }

    void Update()
    {
        playTime += Time.deltaTime;

        Camera.transform.position = target.position + offset;
    }

    void LateUpdate()
    {
        int hour = (int)(playTime / 3600);
        int min = (int)((playTime - hour * 3600) / 60);
        int second = (int)(playTime % 60);

        playTimeTxt.text = string.Format("{0:00}", hour) + ":" + string.Format("{0:00}", min) + ":" + string.Format("{0:00}", second);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void SetResolution()
    {
        int setWidth = 1080;
        int setheight = 1920;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(setWidth, setheight, true);
    }
    public void UpdateLifeIcon(int life)
    {
        for (int index = 0; index < 3; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 0);
        }

        for (int index=0; index<life; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 1);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }
    public void Quit()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }
    public void StageClear()
    {
        PlayerPrefs.SetInt("coin", money);
        SceneManager.LoadScene("Clear");
    }
    public void GameOver()
    {
        PlayerPrefs.SetInt("coin", money);
        Time.timeScale = 0;
        gameOverSet.SetActive(true);
    }
}
