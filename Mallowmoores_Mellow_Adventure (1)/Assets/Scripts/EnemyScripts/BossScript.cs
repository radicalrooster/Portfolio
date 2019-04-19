using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using UnityEngine;

public class BossScript : MonoBehaviour {


    public GameObject ball;
    public GameObject beam;
    public bool beamspawned;
    private bool beamrotate;
    private float fireRate = 0.2f;
    public float ballVelocity;
    public float shotsPerSeconds = 0.5f;
    public enum FightingStates
    {
        Idle,
        Ball,
        Beam,
        Enraged
    }

    public FightingStates currentFightState; 
    
    private void Start()
    {
        currentFightState = FightingStates.Idle;
        beamspawned = false;
        beamrotate = true;
    }

    private void Update()
    {
        
        Debug.Log(beamrotate);


        switch (currentFightState)
        {
            case FightingStates.Idle:
                
                break;
            case FightingStates.Ball:
                
                break;
            case FightingStates.Beam:

                break;
            case FightingStates.Enraged:
                Debug.Log("The boss is enraged!");
                break;
        }


        if(currentFightState == FightingStates.Ball){
            //InvokeRepeating("fire", 0.00001f, fireRate);
            //StartCoroutine(ForceFire(2));
            beamspawned = false;
            float mogelijkheid = Time.deltaTime * shotsPerSeconds;
            if (Random.value < mogelijkheid) {
            fire ();
        }
        }
        if(currentFightState == FightingStates.Beam && beamspawned == false){
            beamAttack ();
            
        }
        if(currentFightState == FightingStates.Beam && beamspawned == true){
            beamRotation();
        }
        if(currentFightState != FightingStates.Beam){
            Destroy (GameObject.Find ("Boss Beam(Clone)"));
            beam.SetActive(true);
        }
    }
    
    void beamAttack () {
        Vector3 startPositie = transform.position + new Vector3 (0, 0, 0);
		GameObject beamattack = Instantiate(beam, startPositie, Quaternion.identity) as GameObject;
        beamspawned = true;
        beam.SetActive(false);
    }
    void beamRotation () {
        //GameObject.FindWithTag("Beam").transform.eulerAngles += new Vector3 (0, 0, -0.5f);
        if(GameObject.FindWithTag("Beam").transform.rotation.z < -70){
            beamrotate = false;
        }else if(GameObject.FindWithTag("Beam").transform.rotation.z > 70){
            beamrotate = true;
        }

        if(beamrotate == false){
            GameObject.FindWithTag("Beam").transform.eulerAngles += new Vector3 (0, 0, -0.5f);
        }else if(beamrotate == true){
            GameObject.FindWithTag("Beam").transform.eulerAngles += new Vector3 (0, 0, 0.5f);
        }
        
        	
        
    }

    void fire () {
		Vector3 startPositie = transform.position + new Vector3 (Random.Range(-9, 9), 1.2f, 0);
		GameObject straal = Instantiate(ball, startPositie, Quaternion.identity) as GameObject;
		straal.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -ballVelocity, 0);
	}
}
