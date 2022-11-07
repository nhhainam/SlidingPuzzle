using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour
{
    public Text moveText;

    public void Setup(int move)
    {
        gameObject.SetActive(true);
        moveText.text = "Your moves: " + move.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("MenuSelect");
    }
}
