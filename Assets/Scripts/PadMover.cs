using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadMover : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera camera_2D;

    float defaultY ;

    float x_Min ;
    float x_Max;

    void Start()
    {

        float padLength = transform.Find("Pad").transform.localScale.x;
        x_Min = -5.0f + padLength /2.0f;
        x_Max = -x_Min;
//        camera_2D = GameObject.Find("Camera_2D").GetComponent<Camera>();
        defaultY = transform.position.y;
        //StartCoroutine(manage_MouseButtonInput_IEn());
    }

    bool fingrIsDown; 
    IEnumerator manage_MouseButtonInput_IEn(){  // Tap Input
        while(true){
            yield return null;
            //Debug.Log("Downing");
            //if (Input.mous){
                if (Input.GetMouseButtonDown(0)){
                    Debug.Log("Finger Down");
                    fingrIsDown = true;
                    // started Touch
                }
                if (fingrIsDown && Input.GetMouseButton(0)){
//                    Debug.Log("Move");
                    // started Touch
                    Debug.Log("Mouse Position : " + Input.mousePosition);
                    Vector2 touchWorldPoint = camera_2D.ScreenToWorldPoint (Input.mousePosition);
                    movePad_toX(touchWorldPoint.x);
                }
                if (Input.GetMouseButtonUp(0)){
                    Debug.Log("Finger Up");
                    // started Touch
                    fingrIsDown = false;
                } 
            //}
        }
    }  

    private void movePad_toX(float x){
        Debug.Log("x : " + x);
        x = Mathf.Clamp(x,x_Min,x_Max);
        transform.position = new Vector3(x,defaultY,0.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
