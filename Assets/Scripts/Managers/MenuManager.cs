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
        LevelHelper.CurrentLevel = 0;
        SceneManager.LoadScene(1);
    }

    public void LoadNextLevel()
    {
        Object[] levels = Resources.LoadAll("ScriptableLevels");

        LevelHelper.CurrentLevel++;

        if (LevelHelper.CurrentLevel + 1 > levels.Length)
            LoadMainLevel();
        else 
            SceneManager.LoadScene(1);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
