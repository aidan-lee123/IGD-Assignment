using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    public GameObject item;
    private Tweener tweener;

    [SerializeField]
    public List<Transform> tweenPoints;

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

    }
}
