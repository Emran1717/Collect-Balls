using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    // Start is called before the first frame update


    public float speed;
    float tMove;

    Vector3 current_Target_LocalPos ;
    Transform targetObject;

    float railLength;

    float currentPos_X ;
    float dx;
    const string railWayObjectName = "RailWay";

    float direction = 1.0f;

    float max_X ; 
    float min_X ;
    void Start()
    {
        bool didFound_Mover = false;

        foreach(Transform tr in transform){
            if (!tr.name.Equals(railWayObjectName)){
                targetObject = tr;
                didFound_Mover = true;
                break;
            }
        }
        if (didFound_Mover){
            direction = 1.0f;
            current_Target_LocalPos = targetObject.transform.localPosition;
            railLength = transform.Find(railWayObjectName).transform.localScale.x;
            max_X = railLength /2.0f;
            min_X = - railLength /2.0f;
            currentPos_X = targetObject.transform.localPosition.x;
            dx = 0.1f;
            if (speed > 0.0f){
                tMove = dx / speed;
                Debug.Log(" tMove : " + tMove);
                StartCoroutine(moveObject());
            }
        }else{
            Debug.Log("!!! There is no Object To Move !!!!");
        }

    }

    IEnumerator moveObject(){
        WaitForSeconds delay = new WaitForSeconds(tMove);
        while(true){
            yield return delay;
            currentPos_X += dx * direction;
            //Debug.Log("currentPos_X : " + currentPos_X);
            if (currentPos_X > max_X){
                currentPos_X = max_X;
                direction = -direction;
            }else if (currentPos_X < min_X){
                currentPos_X = min_X;
                direction = -direction;
            }
            current_Target_LocalPos.x = currentPos_X;
            targetObject.transform.localPosition = current_Target_LocalPos;
        }
    }


}
