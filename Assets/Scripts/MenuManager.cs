using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadMapOne()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadMapTwo()
    {
        SceneManager.LoadScene("Level2");
    }
}
