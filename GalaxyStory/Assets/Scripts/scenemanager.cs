using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadClear()
    {
        SceneManager.LoadScene("Clear");
    }
    public void LoadFail()
    {
        SceneManager.LoadScene("Fail");
    }
    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void Store()
    {
        SceneManager.LoadScene("Store");
    }
    public void StoryMenu()
    {
        SceneManager.LoadScene("StoryMenu");
    }
    public void Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    
    
}
