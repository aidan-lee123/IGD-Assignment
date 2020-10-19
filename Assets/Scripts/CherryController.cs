using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{

    public float timer = 30;
    private Tweener tweener;

    public GameObject cherry;

    public GameObject start;
    public GameObject end;

    GameController game;
    public int value = 100;
    // Start is called before the first frame update
    void Start()
    {
        cherry = this.gameObject;
        tweener = GetComponent<Tweener>();
    }


    private void Awake() {
        game = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0) {
            SpawnCherry();
        }

        if(tweener.activeTween == null) {
            cherry.transform.position = new Vector3(-20, 5, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player") {
            //Debug.Log("Collected Pellet");
            game.AddToScore(value);
            cherry.transform.position = new Vector3(-20, 5, 0);
            GetComponent<Renderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    void SpawnCherry() {
        GetComponent<Renderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        cherry.transform.position = start.transform.position;

        tweener.AddTween(this.transform, this.transform.position, new Vector3(end.transform.position.x, end.transform.position.y, 0f), 5f);
        timer = 30;
    }
}
