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

    public AudioClip pacStudentMove;
    public AudioClip pacStudentPellet;
    public AudioSource audioSource;

    //The lower the faster
    public float speed = 1f;

    GameController game;

    private void Awake() {
        game = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        map = GameObject.Find("Level Generator").GetComponent<LevelGenerator>().levelMap;
        audioSource = GetComponent<AudioSource>();

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
                if (CheckSound(KeyCode.W)) {
                    tweener.AddTween(this.transform, this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y + 1f, 0f), speed);
                    this.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                break;
            case KeyCode.A:
                if (CheckSound(KeyCode.A)) {
                    tweener.AddTween(this.transform, this.transform.position, new Vector3(this.transform.position.x - 1f, this.transform.position.y, 0f), speed);
                    this.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                break;
            case KeyCode.S:
                if (CheckSound(KeyCode.S)) {
                    tweener.AddTween(this.transform, this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y - 1f, 0f), speed);
                    this.transform.rotation = Quaternion.Euler(0, 0, -90);
                }
                break;
            case KeyCode.D:
                if (CheckSound(KeyCode.D)) {
                    tweener.AddTween(this.transform, this.transform.position, new Vector3(this.transform.position.x + 1f, this.transform.position.y, 0f), speed);
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
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


    //this is the same as checkdirecion except this one also sets the sound becasue
    //i wasn't sure how to do this otherwise besides with a raycast but I thought
    // That that would have some strange effects
    public bool CheckSound(KeyCode direction) {
        bool clear = false;

        int[,] surroundingMap = new int[3, 3];
        int xCount = -1;
        int yCount = -1;

        string array = "";

        int xPos = (int)this.transform.position.x;
        int yPos = (int)this.transform.position.y;
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
            case KeyCode.W: {
                    if (surroundingMap[0, 1] == 5 || surroundingMap[0, 1] == 6) {
                        clear = true;
                        ChangeAudio(2);
                        currentInput = direction;
                    }

                    else if (surroundingMap[0, 1] == 0) {
                        clear = true;
                        ChangeAudio(1);
                        currentInput = direction;
                    }
                    break;
                }
            case KeyCode.A: {
                    if (surroundingMap[1, 0] == 5 || surroundingMap[1, 0] == 6) {
                        clear = true;
                        ChangeAudio(2);
                        currentInput = direction;
                    }
                    if (surroundingMap[1, 0] == 0) {
                        clear = true;
                        ChangeAudio(1);
                        currentInput = direction;
                    }
                    break;
                }
            case KeyCode.S: {
                    if (surroundingMap[2, 1] == 5 || surroundingMap[2, 1] == 6) {
                        clear = true;
                        ChangeAudio(2);
                        currentInput = direction;
                    }
                    if (surroundingMap[2, 1] == 0) {
                        clear = true;
                        ChangeAudio(1);
                        currentInput = direction;
                    }
                    break;
                }
            case KeyCode.D: {
                    if (surroundingMap[1, 2] == 5 || surroundingMap[1, 2] == 6) {
                        clear = true;
                        ChangeAudio(2);
                        currentInput = direction;
                    }
                    if (surroundingMap[1, 2] == 0) {
                        clear = true;
                        ChangeAudio(1);
                        currentInput = direction;
                    }
                    break;
                }
            default:
                break;
        }
        return clear;
    }

    public void ChangeAudio(int clipNo) {
        switch (clipNo) {
            case 1:
                audioSource.PlayOneShot(pacStudentMove, 0.7f);
                break;
            case 2:
                audioSource.PlayOneShot(pacStudentPellet, 0.7f);
                break;
        }
    }

    public void Hit() {
        game.RemoveLife();
        tweener.activeTween = null;
        tweener.AddTween(this.transform, this.transform.position, new Vector3(1, -1, 0f), 0f);
    }
}