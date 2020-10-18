using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject link;

    //Just to know where to place pacstudent after teleporting
    public bool right = false;

    void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player") {
            Debug.Log(other.gameObject.name);
            //Have to set tween to null otherwise it wont move
            other.gameObject.GetComponent<Tweener>().activeTween = null;

            //Tween to other position with a duration of 0
            if (right) {
                other.gameObject.GetComponent<Tweener>().AddTween(other.transform, other.transform.position, new Vector3(link.transform.position.x + 1f, link.transform.position.y, 0f), 0f);
            }
            else {
                other.gameObject.GetComponent<Tweener>().AddTween(other.transform, other.transform.position, new Vector3(link.transform.position.x - 1f, link.transform.position.y, 0f), 0f);
            }
            
        }

    }
}
