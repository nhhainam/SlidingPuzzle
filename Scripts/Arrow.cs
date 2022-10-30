using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
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
        string arrow = gameObject.name;
        switch (arrow)
        {
            case "RightArrow":
                SceneManager.LoadScene(sceneName);
                break;
            case "LeftArrow":
                SceneManager.LoadScene(sceneName);
                break;
            default:
                // code block
                break;
        }
    }
}
