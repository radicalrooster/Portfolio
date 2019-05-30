using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class CameraAngle : MonoBehaviour
{
  
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //trying to make the camera get into a specific angle relative to the player depending on which side the camera is facing
        if (_touching_Hor)
        {
            camera.position = 
        }
    }

    public void OnCollisionEnter(Collision other)
    {    
        // if you touch the horizontal facing floor tiles set the horizontal bool to true.
        // gonna try to make this into a state machine later this is proof of concept.
        if (other = floor_Hor) 
        {
            touching_Hor = true; 
        }
    }
}
