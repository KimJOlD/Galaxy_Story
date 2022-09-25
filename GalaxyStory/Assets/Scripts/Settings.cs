using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject settings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

}
