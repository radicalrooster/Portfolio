using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public float closeDelay = .5f;

    private Animator _animator;
    private BoxCollider2D _colliders2D;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _colliders2D = GetComponent<BoxCollider2D>();
    }

    void EnableCollider2D()
    {
        _colliders2D.enabled = true;
    }

    void DisableCollider2D()
    {
        _colliders2D.enabled = false;
    }

    public void Open()
    {
        _animator.SetInteger("AnimState", 1);
    }

    public void Close()
    {
        StartCoroutine(CloseNow());
    }

    IEnumerator CloseNow()
    {
        yield return new WaitForSeconds(closeDelay);
        _animator.SetInteger("AnimState", 2);
    }
}
