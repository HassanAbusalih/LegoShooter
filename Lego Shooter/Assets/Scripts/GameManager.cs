using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Armaan's Scene");
    }
}
