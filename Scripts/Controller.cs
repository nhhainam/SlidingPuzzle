using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Controller : MonoBehaviour
{
    public Puzzle puzzlePrefabs;

    private List<Puzzle> puzzleList = new List<Puzzle>();
    private List<Vector3> puzzlePositions = new List<Vector3>();
    private List<Vector3> winPositions = new List<Vector3>();
    private List<int> randomNumbers = new List<int>();
    private bool isFinished = false;
    public static string image;
    public static string level;
    public GameObject fullPicture;
    public int row;

    private Vector2 startPosition = new Vector2(-5.3f, 3.1f);

    private Vector2 puzzleSize = new Vector2(1.65f, 1.65f);

    public LayerMask collisionMask;

    Ray rayUp, rayDown, rayLeft, rayRight;
    RaycastHit hit;

    private BoxCollider collider;

    private Vector2 colliderSize;

    private Vector2 colliderCenter;

    public GameFinish gameFinish;

    public int playerMoved;

    // Start is called before the first frame update
    void Start()
    {
        // SpawnPuzzle(4, 4);
        // SetStartPosition(4, 4);
        // bindImage();
        // ShufflePuzzle();
        switch (level)
        {
            case "1":
                row = 2;
                startPosition = new Vector2(-5.3f, 2.2f);
                puzzleSize = new Vector2(2.19f, 2.19f);
                SpawnPuzzle(3, 3);
                SetStartPosition(3, 3);
                bindImage();
                ShufflePuzzle();
                break;
            case "2":
                row = 3;
                startPosition = new Vector2(-6.3f, 2.5f);
                puzzleSize = new Vector2(1.65f, 1.65f);
                SpawnPuzzle(4, 4);
                SetStartPosition(4, 4);
                bindImage();
                ShufflePuzzle();
                break;
            case "3":
                row = 4;
                startPosition = new Vector2(-6.3f, 2.6f);
                puzzleSize = new Vector2(1.35f, 1.35f);
                SpawnPuzzle(5, 5);
                SetStartPosition(5, 5);
                bindImage();
                ShufflePuzzle();
                break;
            default:
                // code block
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePuzzle();
    }

    void SpawnPuzzle(int row, int col)
    {
        for (int i = 0; i < row * col - 1; i++)
        {
            puzzleList.Add(Instantiate(puzzlePrefabs, new Vector2(0.0f, 0.0f), Quaternion.identity) as Puzzle);
            puzzleList[i].GetComponent<BoxCollider>().size = puzzleSize / 0.95f;
        }
    }

    void SetStartPosition(int row, int col)
    {
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                float temp1 = startPosition.x + j * puzzleSize.x;
                float temp2 = startPosition.y - i * puzzleSize.y;
                float temp3 = col * i + row;
                Debug.Log(temp1 + " " + temp2 + " " + temp3);
                if (i == col - 1 && j == row - 1)
                {
                    continue;
                }

                puzzleList[col * i + j].transform.position = new Vector2(startPosition.x + j * puzzleSize.x,
                    startPosition.y - i * puzzleSize.y);
                Vector2 temp = new Vector2(startPosition.x + j * puzzleSize.x,
                    startPosition.y - i * puzzleSize.y);
                winPositions.Add(temp);
            }
        }
    }

    void MovePuzzle()
    {
        foreach (Puzzle puzzle in puzzleList)
        {
            puzzle.moveAmount = puzzleSize;
            if (puzzle.clicked)
            {
                collider = puzzle.GetComponent<BoxCollider>();
                colliderSize = collider.size;
                float moveAmount = puzzleSize.x;
                float direction = Mathf.Sign(moveAmount);

                float x = (puzzle.transform.position.x - colliderSize.x / 2) + colliderSize.x / 2;
                float yUp = puzzle.transform.position.y + colliderSize.y / 2 * direction;
                float yDown = puzzle.transform.position.y + colliderSize.y / 2 * -direction;
                rayUp = new Ray(new Vector2(x, yUp), new Vector2(0, direction));
                rayDown = new Ray(new Vector2(x, yDown), new Vector2(0, -direction));
                Debug.DrawRay(rayUp.origin, rayUp.direction);
                Debug.DrawRay(rayDown.origin, rayDown.direction);

                float y = (puzzle.transform.position.y - colliderSize.y / 2) + colliderSize.y / 2;
                float xLeft = puzzle.transform.position.x + colliderSize.x / 2 * -direction;
                float xRight = puzzle.transform.position.x + colliderSize.x / 2 * direction;
                ;
                rayLeft = new Ray(new Vector2(xLeft, y), new Vector2(-direction, 0));
                rayRight = new Ray(new Vector2(xRight, y), new Vector2(direction, 0));
                Debug.DrawRay(rayLeft.origin, rayLeft.direction);
                Debug.DrawRay(rayRight.origin, rayRight.direction);

                if ((Physics.Raycast(rayUp, out hit, 1.0f, collisionMask) == false) && (puzzle.moved == false) &&
                    (puzzle.transform.position.y+0.3f) < startPosition.y)
                {
                    Debug.Log("MoveUp");
                    puzzle.goUp = true;
                    playerMoved++;
                }

                if ((Physics.Raycast(rayDown, out hit, 1.0f, collisionMask) == false) && (puzzle.moved == false))
                {
                    if (((puzzle.transform.position.y-0.3f) > (startPosition.y - row * puzzleSize.y)))
                    {
                        Debug.Log("MoveDown");
                        puzzle.goDown = true;
                        playerMoved++;
                    }
                }

                if (Physics.Raycast(rayLeft, out hit, 1.0f, collisionMask) == false && puzzle.moved == false &&
                    (puzzle.transform.position.x-0.3f) > startPosition.x)
                {
                    Debug.Log("MoveLeft");
                    puzzle.goLeft = true;
                    playerMoved++;
                }

                if (Physics.Raycast(rayRight, out hit, 1.0f, collisionMask) == false && puzzle.moved == false &&
                    (puzzle.transform.position.x+0.3f) < (startPosition.x + row * puzzleSize.x))
                {
                    Debug.Log("MoveRight");
                    puzzle.goRight = true;
                    playerMoved++;
                }

                checkFinish();
            }
        }
    }

    int CountInversion(List<int> ListNumbers)
    {
        int numberInversions = 0;
        for (int i = 0; i < ListNumbers.Count - 1; i++)
        {
            for (int j = i + 1; j < ListNumbers.Count; j++)
            {
                if (randomNumbers[i] > ListNumbers[j])
                {
                    numberInversions++;
                }
            }
        }

        return numberInversions;
    }

    private bool checkFinish()
    {
        gameFinish.Sync(playerMoved);
        isFinished = false;
        for (int i = 0; i < puzzleList.Count; i++)
        {
            if (!(puzzleList[i].transform.position == winPositions[i]))
            {
                return isFinished;
            }
        }
        Debug.Log("finish");
        isFinished = true;
        if (isFinished)
        {
            Finish();
        }
        return isFinished;
    }
    List<int> GenerateRandomPuzzle()
    {
        int number;
        int numberInversions = 0;

        foreach (Puzzle p in puzzleList)
        {
            number = Random.Range(0, puzzleList.Count);
            while (randomNumbers.Contains(number))
            {
                number = Random.Range(0, puzzleList.Count);
            }

            Debug.Log(number);
            randomNumbers.Add(number);
            if (puzzleList.IndexOf(p) == puzzleList.Count - 1)
            {
                numberInversions = CountInversion(randomNumbers);
                if (numberInversions % 2 == 1)
                {
                    randomNumbers.Clear();
                    GenerateRandomPuzzle();
                }
            }
        }

        return randomNumbers;
    }



    void ShufflePuzzle()
    {
        int number;
        int numberInversions = 0;
        foreach (Puzzle p in puzzleList)
        {
            puzzlePositions.Add(p.transform.position);
        }

        GenerateRandomPuzzle();

        for (int i = 0; i < puzzleList.Count; i++)
        {
            Puzzle p = puzzleList[i];
            p.transform.position = puzzlePositions[randomNumbers[i]];
        }
    }
    void bindImage()
    {
        string filePath = "Sprite/Puzzle/" + image + level;
        //string defaultImg = "Sprite/Puzzle/whitebox";
        string spriteName;
        for (int i = 0; i < puzzleList.Count; i++)
        {
            spriteName = image + level + "_" + i;
            puzzleList[i].GetComponent<SpriteRenderer>().sprite = LoadSprite(filePath, spriteName);
        }

        Texture2D texture2D = Resources.Load(filePath, typeof(Texture2D)) as Texture2D;
        fullPicture.GetComponent<Renderer>().material.mainTexture = texture2D;


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
    public void Finish()
    {
        gameFinish.Setup(playerMoved);
    }
}
