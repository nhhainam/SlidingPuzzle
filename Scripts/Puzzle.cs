using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public bool clicked = false;
    public bool moved = false;

    public bool goLeft;
    public bool goRight;
    public bool goDown;
    public bool goUp;

    public Vector2 moveAmount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePuzzle();
    }

    private void OnMouseDown()
    {
        clicked = true;
    }

    private void OnMouseUp()
    {
        clicked = false;
        moved = false;
    }

    void MovePuzzle()
    {
        if (goLeft)
        {
            transform.position = new Vector2(transform.position.x - moveAmount.x, transform.position.y);
            goLeft = false;
            moved = true;
        }
        else if (goRight)
        {
            transform.position = new Vector2(transform.position.x + moveAmount.x, transform.position.y);
            goRight = false;
            moved = true;
        }
        else if (goUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveAmount.y);
            goUp = false;
            moved = true;
        }
        else if (goDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveAmount.y);
            goDown = false;
            moved = true;
        }
    }
}
