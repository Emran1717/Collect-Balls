using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EObjectController : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isRail ; 
    float currentRot = 0.0f;
    const float maxRotPerFrame = 5.0f;
    const float maxMovePerFrame = 0.1f;

    GameObject rotator_obj;

    float railLength;

    float currentPos_X ;

    Vector3 rotator_Initial_LocPos ;
    void Start()
    {
        if (isRail){
            rotator_obj = transform.Find("Rotator").gameObject;
            railLength = transform.Find("RailWay").transform.localScale.x;
            rotator_Initial_LocPos = rotator_obj.transform.localPosition;
            currentPos_X = rotator_Initial_LocPos.x;
        }else{
            rotator_obj = gameObject;
        }
        currentRot = rotator_obj.transform.localEulerAngles.z;
//        Debug.Log("Current Z :" + currentRot);
    }

    public void RotateObject(){
        iTween.RotateBy(gameObject, iTween.Hash("z", 0.5f,"time", 0.3f,"easeType", iTween.EaseType.linear, "loopType", iTween.LoopType.none, "delay", 0.0f,"islocal",false));
    }

    public void Rotate_A_Little(float value, float deltaTime){
        float deltaValue = value  * 1.0f;
        Debug.Log("deltaValue : " + deltaValue);
        deltaValue = Mathf.Clamp(deltaValue, -maxRotPerFrame,maxRotPerFrame);
        currentRot += deltaValue;
        Quaternion newRot = Quaternion.Euler(0.0f,0.0f,currentRot);
        rotator_obj.transform.localRotation = newRot;
        if (isRail){
            float delatPosX = value  * 0.002f;
            delatPosX = Mathf.Clamp(delatPosX, -maxMovePerFrame,maxMovePerFrame);
            currentPos_X += delatPosX;
            currentPos_X = Mathf.Clamp(currentPos_X , -railLength/2.0f, railLength/2.0f);
            rotator_Initial_LocPos.x = currentPos_X;
            rotator_obj.transform.localPosition = rotator_Initial_LocPos;
            // move On The Rail
        }
    }
}
