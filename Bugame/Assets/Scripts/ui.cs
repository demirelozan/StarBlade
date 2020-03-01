using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Ege");
    }
    public void exit()
    {
        Application.Quit();
    }
}
