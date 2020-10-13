using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField]
    private Transform[] transformArray;

    private KeyCode lastInput;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            Debug.Log("S");
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            Debug.Log("D");
        }

        if (!isMoving) {

        }

    }

    public void Move(KeyCode direction) {

    }
}
