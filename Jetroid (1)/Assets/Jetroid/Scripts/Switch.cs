using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public DoorTrigger[] doorTriggers;
    public bool sticky;

    private bool down = false;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        down = true;
        _animator.SetInteger("AnimState", 1);

        foreach (var trigger in doorTriggers)
        {
            trigger.Toggle(true);
        }
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (sticky && down)
        {
            return;
        }
        
        down = false;

        _animator.SetInteger("AnimState", 2);

        foreach (var trigger in doorTriggers)
        {
            if (trigger != null)
            {
                trigger.Toggle(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = sticky ? Color.red : Color.green;
        foreach (var trigger in doorTriggers)
        {
            Gizmos.DrawLine(transform.position, trigger._door.transform.position);
        }
    }
}
