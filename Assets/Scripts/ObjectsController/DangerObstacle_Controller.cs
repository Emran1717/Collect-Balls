using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerObstacle_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        Trigger_Dettected(other); 
    }

    private void OnTriggerEnter(Collider other)
    {
        Trigger_Dettected(other);
    }

    private void Trigger_Dettected(Collider other){
        if (other.tag.Equals(SV.tag_Ball)){
            other.transform.gameObject.GetComponent<BallController>().Destroy_It(1);
        }else if (other.tag.Equals(SV.tag_WhiteBall)){
            Destroy(other.transform.gameObject);
        }
    }

}
