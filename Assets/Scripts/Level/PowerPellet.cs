using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : MonoBehaviour
{
    GameController game;

    // Start is called before the first frame update
    void Awake() {
        game = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player") {

            game.PowerPelletEaten();
            Destroy(gameObject);
        }

    }

}
