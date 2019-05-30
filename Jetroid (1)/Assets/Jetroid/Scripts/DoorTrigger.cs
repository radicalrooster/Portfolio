using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    public Door _door;
    public bool ignoreTrigger;

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(ignoreTrigger)
            return;

        if (target.gameObject.tag == "Player")
        {
            _door.Open();
        }
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            _door.Close();
        }
    }

    public void Toggle(bool value)
    {
        if (value)
        {
            _door.Open();
        }
        else
        {
            _door.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = ignoreTrigger ? Color.gray : Color.green;

        var bc2D = GetComponent<BoxCollider2D>();
        var pos = bc2D.transform.position;
        
        var newPos = new Vector2(pos.x + bc2D.offset.x, pos.y + bc2D.offset.y);
        Gizmos.DrawWireCube(newPos, new Vector2(bc2D.size.x, bc2D.size.y));
    }
}
