using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 150f;
    public Vector2 maxVelocity = new Vector2(60, 100);

    public float jetSpeed = 200f;
    public bool standing;
    public float standingThreshold = 4f;
    public float airSpeedMultiplier = .3f;

    private Rigidbody2D rb2D;
    private SpriteRenderer renderer2D;
    private PlayerController controller;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var absVelx = Mathf.Abs(rb2D.velocity.x);
        var absVely = Mathf.Abs(rb2D.velocity.y);

        if (absVely <= standingThreshold)
        {
            standing = true;
        }
        else
        {
            standing = false;
        }

        var forceX = 0f;
        var forceY = 0f;

        if (controller.moving.x != 0)
        {
            if (absVelx < maxVelocity.x)
            {
                var newSpeed = speed * controller.moving.x;
                
                forceX = standing ? newSpeed : (newSpeed * airSpeedMultiplier);  
                
                renderer2D.flipX = forceX < 0;
                //Debug.Log(forceX);
            }
            animator.SetInteger("AnimState", 3);
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }

        if (controller.moving.y > 0)
        {
            if (absVely < maxVelocity.y)
            {
                forceY = jetSpeed * controller.moving.y;
            }
            animator.SetInteger("AnimState", 1);
        }else if (absVely > 0 && !standing)
        {
            animator.SetInteger("AnimState", 2);
        }
        rb2D.AddForce(new Vector2(forceX, forceY));
    }
}


//TODO: Vliegt naar rechts als je in de "lucht" bent en links in drukt status: DONE
