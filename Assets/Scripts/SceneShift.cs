using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneShift : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
