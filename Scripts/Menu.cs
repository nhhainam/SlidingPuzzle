using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject leftArrow;
    private GameObject rightArrow;

    // Start is called before the first frame update
    void Start()
    {
        leftArrow = GameObject.Find("LeftArrow");
        rightArrow = GameObject.Find("RightArrow");

        if (SceneManager.GetActiveScene().name.Equals("MenuSelect"))
        {
            leftArrow.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name.Equals("MenuSelect2"))
        {
            rightArrow.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
