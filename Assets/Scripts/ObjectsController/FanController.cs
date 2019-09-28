using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    // Start is called before the first frame update

    public float power ;
    Vector3 force_Direction;
    Vector3 force_Vector;

    private Plane fan_ground ;
    void Start()
    {
        //fan_ground = transform.Find("Plane").GetComponent<Plane>();
        Vector3 targetPoint = transform.Find("TargetPoint").transform.position;
        Vector3 basePoint = transform.position;
        Vector3 relativeVector = targetPoint - basePoint;
        force_Direction = relativeVector.normalized;
        fan_ground = new Plane(force_Direction, transform.position);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals(SV.tag_Ball)){
            BallController ball_controller = other.gameObject.GetComponent<BallController>(); 
            float dis = fan_ground.GetDistanceToPoint(other.transform.position);
            force_Vector = force_Direction * (power / dis) ;  
//            Debug.Log("force_Vector : " + force_Vector );
            ball_controller.AddForce(force_Vector);
        }  
    }
}
