using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectmanager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public player player;

    GameObject[] bullet;
    GameObject[] targetPool;

    void Awake()
    {
        bullet = new GameObject[20];

        Generate();
    }

    void Generate()
    {
        for(int index=0; index< bullet.Length; index++)
        {
            bullet[index] = Instantiate(bulletPrefab, player.bulletPos.position, player.bulletPos.rotation);
            bullet[index].SetActive(false);
            
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "bullet":
                targetPool = bullet;
                break;
        }
        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!bullet[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }
        return null;
    }
}
 