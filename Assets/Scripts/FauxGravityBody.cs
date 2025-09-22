using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour
{

    public FauxGravityAttractor attractor;
    private Transform myTransform;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false; // We don't want to use the built-in gravity system.
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        attractor.Attract(transform);

    }
}
