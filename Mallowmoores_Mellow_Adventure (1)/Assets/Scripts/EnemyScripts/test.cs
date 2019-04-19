    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
     
    public class CameraReposition : MonoBehaviour {
     
        [SerializeField] private Camera[] cameras;
        [SerializeField] private Transform pos;
        [SerializeField] private float WaitTime = 0.2f;
     
        public bool forceRePosition;
     
        void Start ()
        {
            StartCoroutine(ForceRePosition(WaitTime));
        }
       
        IEnumerator ForceRePosition (float waitTime)
        {
            while (forceRePosition)
            {
                yield return new WaitForSeconds(waitTime);
     
                RePosition();
            }
        }
     
        public void RePosition ()
        {
            cameras[0].gameObject.transform.position = pos.position;
            cameras[1].gameObject.transform.position = pos.position;
        }
    }
