using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPellet : MonoBehaviour
{
    GameController game;
    public int value = 10;
    // Start is called before the first frame update
    void Awake()
    {
        game = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player") {
            //Debug.Log("Collected Pellet");
            game.AddToScore(value);
            Destroy(gameObject);
        }

    }
}
