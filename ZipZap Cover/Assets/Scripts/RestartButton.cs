using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public Button restartButton;

    public Canvas endCanvas;



    // Start is called before the first frame update

    private void OnEnable()
    {
        restartButton.onClick.AddListener(() => ButtonPress(restartButton));
        
    }

    private void ButtonPress(Button buttonPressed)
    {
        Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        if (buttonPressed == restartButton)
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
        }
    }
}
