using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{

    public int state_no = 1;

    GameController game;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        game = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move() {

    }

    public void Eaten() {
        game.AddToScore(300);
        StartCoroutine(GhostDead());
    }

    private IEnumerator GhostDead() {
        yield return new WaitForSeconds(3);
        state_no = 1;
    }

    public void SetState(int state) {
        state_no = state;

        switch (state) {
            case 1: {

                break;
            }
            case 2: {

                break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player") {
            switch (state_no) {
                //Walking State
                case 1:
                    //Pacman dies
                    other.GetComponent<PacStudentController>().Hit();
                    break;
                case 2:
                    //Pacman Eats
                    Eaten();
                    break;
            }
        }

    }
}
