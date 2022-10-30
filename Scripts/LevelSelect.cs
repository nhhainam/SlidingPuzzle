using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public GameObject fullPicture;
    // Start is called before the first frame update
    void Start()
    {
        string filePath = "Sprite/Puzzle/" + Controller.image;
        Texture2D texture2D = Resources.Load(filePath, typeof(Texture2D)) as Texture2D;
        fullPicture.GetComponent<Renderer>().material.mainTexture = texture2D;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
