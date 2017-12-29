using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public float Speed;
    public float Torque;

    Rigidbody _rig;

	// Use this for initialization
	void Start () {
        _rig = GetComponent<Rigidbody>();
    }
	
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        _rig.velocity = transform.forward * Speed * v;
        _rig.angularVelocity = transform.up * Torque * h;
    }
}
