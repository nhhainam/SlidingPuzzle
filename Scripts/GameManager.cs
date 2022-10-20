using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class GameManager : MonoBehaviour
{
    public Puzzle puzzlePrefab;

    private SpriteAtlas atlas;

    private List<Puzzle> puzzleList = new List<Puzzle>();

    private Vector2 startPosition = new Vector2(0.0f, 0.0f);

    private Vector2 offset = new Vector2(1.55f, 1.55f);

    //public string folderName;

    public GameObject fullPicture;

    public string gameName;

    public GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        createPuzzle(7);
        createBoardEasy();
        bindImage();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void createPuzzle(int number)
    {
        for (int i = 0; i <= number; i++)
        {
            puzzleList.Add(Instantiate(puzzlePrefab, new Vector2(0.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as Puzzle);
        }
    }

    void createBoardEasy()
    {

        //puzzleList[9].transform.position = new Vector2(startPosition.x, startPosition.y + offset.y);

        puzzleList[0].transform.position = new Vector2(startPosition.x, startPosition.y);
        puzzleList[1].transform.position = new Vector2(startPosition.x + offset.x, startPosition.y);
        puzzleList[2].transform.position = new Vector2(startPosition.x + (2 * offset.x), startPosition.y);

        puzzleList[3].transform.position = new Vector2(startPosition.x, startPosition.y - offset.y);
        puzzleList[4].transform.position = new Vector2(startPosition.x + offset.x, startPosition.y - offset.y);
        puzzleList[5].transform.position = new Vector2(startPosition.x + (2 * offset.x), startPosition.y - offset.y);

        puzzleList[6].transform.position = new Vector2(startPosition.x, startPosition.y - (2 * offset.y));
        puzzleList[7].transform.position = new Vector2(startPosition.x + offset.x, startPosition.y - (2 * offset.y));
        //puzzleList[8].transform.position = new Vector2(startPosition.x + (2 * offset.x), startPosition.y - (2 * offset.y));
    }

    void createBoardMedium()
    {

        ////puzzleList[9].transform.position = new Vector2(startPosition.x, startPosition.y + offset.y);

        //puzzleList[0].transform.position = new Vector2(startPosition.x, startPosition.y);
        //puzzleList[1].transform.position = new Vector2(startPosition.x + offset.x, startPosition.y);
        //puzzleList[2].transform.position = new Vector2(startPosition.x + (2 * offset.x), startPosition.y);

        //puzzleList[3].transform.position = new Vector2(startPosition.x, startPosition.y - offset.y);
        //puzzleList[4].transform.position = new Vector2(startPosition.x + offset.x, startPosition.y - offset.y);
        //puzzleList[5].transform.position = new Vector2(startPosition.x + (2 * offset.x), startPosition.y - offset.y);

        //puzzleList[6].transform.position = new Vector2(startPosition.x, startPosition.y - (2 * offset.y));
        //puzzleList[7].transform.position = new Vector2(startPosition.x + offset.x, startPosition.y - (2 * offset.y));
        ////puzzleList[8].transform.position = new Vector2(startPosition.x + (2 * offset.x), startPosition.y - (2 * offset.y));
    }

    void createBoardHard()
    {

        ////puzzleList[9].transform.position = new Vector2(startPosition.x, startPosition.y + offset.y);

        //puzzleList[0].transform.position = new Vector2(startPosition.x, startPosition.y);
        //puzzleList[1].transform.position = new Vector2(startPosition.x + offset.x, startPosition.y);
        //puzzleList[2].transform.position = new Vector2(startPosition.x + (2 * offset.x), startPosition.y);

        //puzzleList[3].transform.position = new Vector2(startPosition.x, startPosition.y - offset.y);
        //puzzleList[4].transform.position = new Vector2(startPosition.x + offset.x, startPosition.y - offset.y);
        //puzzleList[5].transform.position = new Vector2(startPosition.x + (2 * offset.x), startPosition.y - offset.y);

        //puzzleList[6].transform.position = new Vector2(startPosition.x, startPosition.y - (2 * offset.y));
        //puzzleList[7].transform.position = new Vector2(startPosition.x + offset.x, startPosition.y - (2 * offset.y));
        ////puzzleList[8].transform.position = new Vector2(startPosition.x + (2 * offset.x), startPosition.y - (2 * offset.y));
    }

    void bindImage()
    {
        string filePath = "Sprite/Puzzle/" + gameName + "1";
        //string defaultImg = "Sprite/Puzzle/whitebox";
        string spriteName;
        for (int i = 0; i < puzzleList.Count; i++)
        {
            //if (i == puzzleList.Count)
            //{
            //    Sprite sprite = Resources.Load<Sprite>(defaultImg);
            //    puzzleList[i].GetComponent<SpriteRenderer>().sprite = sprite;

            //}
            //else
            //{
                spriteName = gameName + "1_" + i;
                puzzleList[i].GetComponent<SpriteRenderer>().sprite = LoadSprite(filePath, spriteName);
            //}


            //Texture2D tex2D = LoadSprite(filePath, spriteName);
            //Texture2D texture2D = Resources.Load(filePath, typeof(Texture2D)) as Texture2D;
            //puzzleList[i].GetComponent<Renderer>().material.mainTexture = tex2D;

        }

        Texture2D texture2D_full = Resources.Load(filePath, typeof(Texture2D)) as Texture2D;
        fullPicture.GetComponent<Renderer>().material.mainTexture = texture2D_full;

    }

    Sprite LoadSprite(string filePath, string spriteName)
    {
        Sprite[] all = Resources.LoadAll<Sprite>(filePath);

        foreach (var s in all)
        {
            if (s.name == spriteName)
            {
                return s;
            }
        }
        return null;
    }

}
