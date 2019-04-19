using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public Debris _debris;
    public int totalDebris = 10;
    
    private void OnTriggerEnter2D(Collider2D target)
    {
        print("Hit Trigger");
        if (target.gameObject.tag == "Deadly")
        {
            OnExplode();
        }
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        print("Hit Collision");
        if (target.gameObject.tag == "Deadly")
        {
            OnExplode();
        }
    }
    

    void OnExplode()
    {
        var t = transform;

        for (int i = 0; i < totalDebris; i++)
        {
            t.TransformPoint(0, -100, 0);
            var clone = Instantiate(_debris, t.position, Quaternion.identity) as Debris;
            var body2D = clone.GetComponent<Rigidbody2D>();
            body2D.AddForce(Vector3.right * Random.Range(-1000, 1000));
            body2D.AddForce(Vector3.up * Random.Range(500, 2000));
        }
        Destroy(gameObject);
    }
}
