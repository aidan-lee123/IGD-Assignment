﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPellet : MonoBehaviour
{

    public int value = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player") {



        }

    }
}
