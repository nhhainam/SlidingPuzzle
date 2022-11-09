using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour
{
    public TextMeshProUGUI moveText;

    public TextMeshProUGUI syncMove;

    public void Setup(int move)
    {
        gameObject.SetActive(true);
        moveText.text = "Your moves: " + move.ToString();
        syncMove.text = "Your moves: " + move.ToString();
    }

    public void Sync(int move)
    {
        moveText.text = "Your moves: " + move.ToString();
        syncMove.text = "Your moves: " + move.ToString();
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
