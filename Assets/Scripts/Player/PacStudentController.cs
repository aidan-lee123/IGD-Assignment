using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    //For Tweening
    private Tweener tweener;
    public int[,] map;

    private KeyCode lastInput;
    private KeyCode currentInput;
    private bool isMoving = false;

    //The lower the faster
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        map = GameObject.Find("Level Generator").GetComponent<LevelGenerator>().levelMap;
        CheckDirection(KeyCode.None);
        this.transform.position = new Vector2(1, -1);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.W)) {
            lastInput = KeyCode.W;
            //Move(lastInput);
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            lastInput = KeyCode.A;
            //Move(lastInput);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            lastInput = KeyCode.S;
           // Move(lastInput);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            lastInput = KeyCode.D;
            //Move(lastInput);
        }

        if (currentInput == KeyCode.None) {
            currentInput = lastInput;
        }

        if (!isMoving) {
            isMoving = true;
            if (CheckDirection(lastInput) == true){
                currentInput = lastInput;
            }
            //Debug.Log(currentInput);
            Move(currentInput);

        }
        
    }

    public void Move(KeyCode direction) {

        if(lastInput == KeyCode.None) {
            isMoving = false;
            return;
        }


        switch (direction) {
            case KeyCode.W:
                if (CheckDirection(KeyCode.W)) {
                    this.transform.rotation = Quaternion.Euler(0, 0, 90);
                    tweener.AddTween(this.transform, this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y + 1f, 0f), speed);
                }
                break;
            case KeyCode.A:
                if (CheckDirection(KeyCode.A)) {
                    this.transform.rotation = Quaternion.Euler(0, 0, 180);
                    tweener.AddTween(this.transform, this.transform.position, new Vector3(this.transform.position.x - 1f, this.transform.position.y, 0f), speed);
                }
                break;
            case KeyCode.S:
                if (CheckDirection(KeyCode.S)) {
                    this.transform.rotation = Quaternion.Euler(0, 0, -90);
                    tweener.AddTween(this.transform, this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y - 1f, 0f), speed);
                }
                break;
            case KeyCode.D:
                if (CheckDirection(KeyCode.D)) {
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                    tweener.AddTween(this.transform, this.transform.position, new Vector3(this.transform.position.x + 1f, this.transform.position.y, 0f), speed);
                }
                break;
        }


        isMoving = false;

    }

    public bool CheckDirection(KeyCode direction) {
        bool clear = false;

        int[,] surroundingMap = new int[3, 3];
        int xCount = -1;
        int yCount = -1;

        string array = "";

        int xPos = (int) this.transform.position.x;
        int yPos = (int) this.transform.position.y;
        for (int x = 0; x < 3; x++) {

            for (int y = 0; y < 3; y++) {

                try {
                    //Gotta * by -1 otherwise map is upside down
                    //I also messed up the way arrays work ages ago so x and y are swapped in every scenario
                    //meaning i needed to swap it here to get it to work and that took me actually ages to figure out
                    surroundingMap[x, y] = map[Mathf.FloorToInt(-yPos) + xCount, Mathf.FloorToInt(xPos) + yCount];
                }
                catch {
                    surroundingMap[x, y] = 0;
                }
                array += "{" + surroundingMap[x, y] + "}, ";
                yCount++;
            }
            yCount = -1;
            array += "\n";
            xCount++;
        }


        /*
        00 01 02
        10 11 12
        20 21 22
        */

        switch (direction) {
            case KeyCode.W:
                if (surroundingMap[0, 1] == 5 || surroundingMap[0, 1] == 6 || surroundingMap[0, 1] == 0) {
                    clear = true;
                    currentInput = direction;
                }
                break;
            case KeyCode.A:
                if (surroundingMap[1, 0] == 5 || surroundingMap[1, 0] == 6 || surroundingMap[1, 0] == 0) {
                    clear = true;
                    currentInput = direction;
                }
                break;
            case KeyCode.S:
                if (surroundingMap[2, 1] == 5 || surroundingMap[2, 1] == 6 || surroundingMap[2, 1] == 0) {
                    clear = true;
                    currentInput = direction;
                }
                break;
            case KeyCode.D:
                if (surroundingMap[1, 2] == 5 || surroundingMap[1, 2] == 6 || surroundingMap[1, 2] == 0) {
                    clear = true;
                    currentInput = direction;
                }
                break;
            default:
                break;
        }
        return clear;
    }
}
