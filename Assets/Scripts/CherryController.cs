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
    // Start is called before the first frame update
    void Start()
    {
        cherry = this.gameObject;
        tweener = GetComponent<Tweener>();
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

    void SpawnCherry() {
        this.enabled = true;
        cherry.transform.position = start.transform.position;

        tweener.AddTween(this.transform, this.transform.position, new Vector3(end.transform.position.x, end.transform.position.y, 0f), 5f);
        timer = 30;
    }
}
