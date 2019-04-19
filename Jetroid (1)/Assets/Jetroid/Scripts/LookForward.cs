using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForward : MonoBehaviour
{

    public Transform sightStart, sightEnd;

    public string layer = "Solid";
    public bool needCollision = true;
    
    private bool collision;

    void Update()
    {
        collision = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer(layer));
        
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

        if (collision == needCollision)
        {
            Debug.Log("no hit");
            transform.localScale = new Vector3(transform.localScale.x == 1 ? -1 : 1, 1, 1);
        }
    }
}
