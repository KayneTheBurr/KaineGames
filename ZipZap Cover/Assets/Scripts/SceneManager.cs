using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public WinCollision winScript;
    public LevelTracker levelScript;
    
    public enum LevelSelected
    {
        Menu,       //00
        Level_01,   //01
        Level_02,   //02
        Level_03,   //03
        Level_04,   //04
        Level_05,   //05
        Level_06    //06
    }
    public LevelSelected currentLevel;

    public bool levelCheck;

    // Start is called before the first frame update
    void Start()
    {
        levelScript = FindObjectOfType<LevelTracker>();
        winScript = FindObjectOfType<WinCollision>();
        levelCheck = false;
    }
    public void LevelUp()
    {
        
        if (levelScript.levelNumber == 0)
        {
            SetLevel(LevelSelected.Menu);
        }
        else if (levelScript.levelNumber == 1)
        {
            SetLevel(LevelSelected.Level_01);
        }
        else if (levelScript.levelNumber == 2)
        {
            SetLevel(LevelSelected.Level_02);
        }
        else if (levelScript.levelNumber == 3)
        {
            SetLevel(LevelSelected.Level_03);
        }
        else if (levelScript.levelNumber == 4)
        {
            SetLevel(LevelSelected.Level_04);
        }
        else if (levelScript.levelNumber == 5)
        {
            SetLevel(LevelSelected.Level_05);
        }
        else if (levelScript.levelNumber == 6)
        {
            SetLevel(LevelSelected.Level_06);
        }


    }


    // Update is called once per frame
    void Update()
    {
        if (levelScript.levelNumber < 6 && winScript.winRound == true)
        {
            if (levelCheck == false)
            {
                levelScript.levelNumber++;
                LevelUp();
                levelCheck = true;
                Debug.Log("level #:" + levelScript.levelNumber);
            }
        }

        if (levelScript.levelNumber >= 6 && winScript.winRound == true)
        {
            if (levelCheck == false)
            {
                levelScript.levelNumber = 0;
                Invoke(nameof(LaunchMenu), 2f);
                levelCheck = true;
            }
        }
        if( Input.GetKeyDown(KeyCode.Tab))
        {
            SetLevel(LevelSelected.Menu);
        }

        
    }
    public void SetLevel(LevelSelected newLevel)
    {
        currentLevel = newLevel;
        switch(currentLevel)
        {
            case LevelSelected.Menu:
                Invoke(nameof(LaunchMenu), 0.1f);
                break;
            case LevelSelected.Level_01:
                Invoke(nameof(LaunchLevel_01), 2);
                break;
            case LevelSelected.Level_02:
                Invoke(nameof(LaunchLevel_02), 2);
                break;
            case LevelSelected.Level_03:
                Invoke(nameof(LaunchLevel_03), 2);
                break;
            case LevelSelected.Level_04:
                Invoke(nameof(LaunchLevel_04), 2);
                break;
            case LevelSelected.Level_05:
                Invoke(nameof(LaunchLevel_05), 2);
                break;
            case LevelSelected.Level_06:
                Invoke(nameof(LaunchLevel_06), 2);
                break;
        }
    }


    public void LaunchMenu()
    {
        levelScript.levelNumber = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void LaunchLevel_01()
    {
        levelScript.levelNumber = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_01");
    }

    public void LaunchLevel_02()
    {
        levelScript.levelNumber = 2;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_02");
    }

    public void LaunchLevel_03()
    {
        levelScript.levelNumber = 3;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_03");
    }

    public void LaunchLevel_04()
    {
        levelScript.levelNumber = 4;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_04");
    }

    public void LaunchLevel_05()
    {
        levelScript.levelNumber = 5;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_05");
    }

    public void LaunchLevel_06()
    {
        levelScript.levelNumber = 6;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_06");
    }
}
