using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfOfViewBallDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // make Place
        float cameraZ = - GameObject.Find("Main Camera").transform.position.z;
        float degRad = SV.ins.Camera_FieldOfView_Vertical /2.0f / 180.0f * Mathf.PI;
        float tan = Mathf.Tan(degRad);
        float y = tan * cameraZ + 0.5f;
        transform.localPosition = new Vector3(0.0f,-y,cameraZ);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals(SV.tag_Ball)){
            other.transform.gameObject.GetComponent<BallController>().Destroy_It(0);
        }  
    }
}
