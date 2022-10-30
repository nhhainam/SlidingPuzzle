using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        string button = gameObject.name;
        switch (button)
        {
            case "ExitButton":
                Application.Quit();
                break;
            case "BackButton":
                SceneManager.LoadScene(sceneName);
                break;
            case "EasyButton":
                Controller.level = "1";
                SceneManager.LoadScene(sceneName);
                break;
            case "MediumButton":
                Controller.level = "2";
                SceneManager.LoadScene(sceneName);
                break;
            case "HardButton":
                Controller.level = "3";
                SceneManager.LoadScene(sceneName);
                break;
            default:
                // code block
                break;
        }
    }
}
