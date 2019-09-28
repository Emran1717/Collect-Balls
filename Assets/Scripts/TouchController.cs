using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    // Start is called before the first frame update
    int controlMode = 3 ; // 1-> Just Tap      2-> Swipe   3-> Draw Line

    public Camera touch_Camera;

    int RayCast_LayerMask = 0;
    int RayCast_LayerMask_JustButtons = 0;
    int RayCast_MaxDistance = 40;
    void Start()
    {
        RayCast_LayerMask = 1 << 30;
        RayCast_LayerMask_JustButtons = 1 << 31;
        if (controlMode == 1){ // just tap
            StartCoroutine(manage_MouseButtonInput_JustTap_IEn());
        }else if (controlMode == 2){ // swipe
            StartCoroutine(manage_MouseButtonInput_Swipe_IEn());
        }else if (controlMode == 3){ // Draw Line
            StartCoroutine(manage_MouseButtonInput_DrawLine_IEn());
        }
    }

    IEnumerator manage_MouseButtonInput_JustTap_IEn(){  // Tap Input
        while(true){
            yield return null;
            //Debug.Log("Downing");
            //if (Input.mous){
                if (Input.GetMouseButtonDown(0)){
                    All_EObjects_Controller.ins.Rotate_All();
                }
            //}
        }
    }  

    Vector3 lastMousePos;
    IEnumerator manage_MouseButtonInput_Swipe_IEn(){  // Tap Input
        while(true){
            yield return null;
            //Debug.Log("Downing");
            //if (Input.mous){
                if (Input.GetMouseButtonDown(0)){
                    lastMousePos = Input.mousePosition;
                }else if (Input.GetMouseButton(0)){
                    All_EObjects_Controller.ins.Rotate_A_Littile(Input.mousePosition.x - lastMousePos.x , Time.deltaTime);
                    lastMousePos = Input.mousePosition;
                }
            //}
        }
    } 

    Vector2 point_gameSpace ;
    IEnumerator manage_MouseButtonInput_DrawLine_IEn(){  // Tap Input
        while(true){
            yield return null;
            if (Input.GetMouseButtonDown(0)){
                point_gameSpace = getHitPoit_And_ClickHandle(Input.mousePosition);
                if (point_gameSpace.x > -1000){
                    LineDrawer.ins.draw_PreLine_started(point_gameSpace);
                }
            }
            if (Input.GetMouseButton(0)){
                point_gameSpace = getHitPoit(Input.mousePosition);
                if (point_gameSpace.x > -1000){
                    LineDrawer.ins.Modify_PreLine(point_gameSpace);
                }
            }
            if (Input.GetMouseButtonUp(0)){
                LineDrawer.ins.draw_PreLine_ended();
                //LineDrawer.ins.draw_PreLine_ended();
            }
        }
    }
    
    const string Tag_background = "Background";
    const string Tag_GateButton = "Button";
    Vector2 getHitPoit_And_ClickHandle(Vector3 mousePos){
        RaycastHit hit;
        Ray ray = touch_Camera.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out hit, RayCast_MaxDistance, RayCast_LayerMask_JustButtons)) {
            Debug.Log("hit.collider.tag : " + hit.collider.tag);
            if (hit.collider.tag.Equals(Tag_GateButton)){
                if (hit.collider.gameObject.name == "GateButton"){
                    hit.collider.transform.parent.transform.parent.GetComponent<SpawnBoxController>().StartIt();
                }
               Transform objectHit = hit.transform;
               //Debug.Log("hit.point : " + hit.point.x + " | " + hit.point.y);
               return new Vector3(-100000,0,0);
            }
        }else if (Physics.Raycast(ray, out hit, RayCast_MaxDistance, RayCast_LayerMask)) {

            return new Vector2(hit.point.x , hit.point.y);

        }
        return new Vector3(-100000,0,0);
    }

    Vector2 getHitPoit(Vector3 mousePos){
        RaycastHit hit;
        Ray ray = touch_Camera.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out hit, RayCast_MaxDistance, RayCast_LayerMask)) {
            return new Vector2(hit.point.x , hit.point.y);
            /* 
            if (hit.collider.tag.Equals(backgroundTag)){
                //Transform objectHit = hit.transform;
//                Debug.Log("hit.point : " + hit.point.x + " | " + hit.point.y);
            }else {
//                Debug.Log("Object Clicked !!");
            }
*/
        }
        return new Vector3(-100000,0,0);
    }


}
