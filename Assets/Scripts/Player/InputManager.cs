using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject item;
    private Tweener tweener;

    [SerializeField]
    private List<Transform> tweenPoints;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();

    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform point in tweenPoints) {
            tweener.AddTween(item.transform, item.transform.position, new Vector3(point.position.x, point.position.y, 0f), 1f);

        }
        /*
        if (Input.GetKeyDown(KeyCode.A)) {
            tweener.AddTween(item.transform, item.transform.position, new Vector3(-2.0f, 0.0f, 0.0f), 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            tweener.AddTween(item.transform, item.transform.position, new Vector3(2.0f, 0.0f, 0.0f), 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            tweener.AddTween(item.transform, item.transform.position, new Vector3(0.0f, -2.0f, 0f), 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            tweener.AddTween(item.transform, item.transform.position, new Vector3(0.0f, 2.0f, 0f), 1.5f);
        }
        */
    }
}
