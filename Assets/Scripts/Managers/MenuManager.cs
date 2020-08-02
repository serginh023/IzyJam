using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void LoadMainLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void GamePlayLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
