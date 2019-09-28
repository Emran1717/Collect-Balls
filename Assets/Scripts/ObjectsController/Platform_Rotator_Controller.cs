using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Rotator_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float motorSpeed; 
    public HingeJoint hingeJoint;
    void Start()
    {
        var motor = hingeJoint.motor;
        motor.force = 10.0f;
        motor.targetVelocity = motorSpeed;
        motor.freeSpin = false;
        hingeJoint.motor = motor;
        hingeJoint.useMotor = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
