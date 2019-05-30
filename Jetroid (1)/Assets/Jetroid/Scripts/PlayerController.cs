﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector2 moving = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moving.x = moving.y = 0;

        if (Input.GetKey("d"))
        {
            moving.x = 1;
        }else if (Input.GetKey("a"))
        {
            moving.x = -1;
        }

        if (Input.GetKey("w"))
        {
            moving.y = 1;
        }else if (Input.GetKey("s"))
        {
            moving.y = -1;
        }
    }
}
