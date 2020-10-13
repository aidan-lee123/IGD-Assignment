using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    //For Tweening
    private Tweener tweener;
    private int[,] map;

    private KeyCode lastInput;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        map = GameObject.Find("Level Generator").GetComponent<LevelGenerator>().levelMap;

        this.transform.position = new Vector2(1, -1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            Debug.Log("W");
            lastInput = KeyCode.W;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("A");
            lastInput = KeyCode.A;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            Debug.Log("S");
            lastInput = KeyCode.S;
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            Debug.Log("D");
            lastInput = KeyCode.D;
        }

        if (!isMoving) {
            isMoving = true;
            Move(lastInput);
        }

    }

    public void Move(KeyCode direction) {

        if(lastInput == KeyCode.None) {
            isMoving = false;
            return;
        }


        switch (direction) {
            case KeyCode.W:
                tweener.AddTween(this.transform, this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y + 1f, 0f), 1f);
                break;
            case KeyCode.A:
                tweener.AddTween(this.transform, this.transform.position, new Vector3(this.transform.position.x - 1f, this.transform.position.y, 0f), 1f);
                break;
            case KeyCode.S:
                tweener.AddTween(this.transform, this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y - 1f, 0f), 1f);
                break;
            case KeyCode.D:
                tweener.AddTween(this.transform, this.transform.position, new Vector3(this.transform.position.x + 1f, this.transform.position.y, 0f), 1f);
                break;
        }


        isMoving = false;

    }

    public bool CheckDirection(KeyCode direction) {
        bool clear = true;



        return clear;
    }
}
