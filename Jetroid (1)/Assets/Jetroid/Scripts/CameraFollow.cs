using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;

    private Transform _transform;
    public float scale = 4f;

    void Awake()
    {
        var cam = GetComponent<Camera>();
        cam.orthographicSize = (Screen.height / 2f) / scale;
    }

    // Start is called before the first frame update
    void Start()
    {
        _transform = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(_transform.position.x, _transform.position.y, transform.position.z);
        }
    }
}
