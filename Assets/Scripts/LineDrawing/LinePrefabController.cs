using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePrefabController : MonoBehaviour
{

    public GameObject end_Cricle_obj;

    public GameObject cube_obj;
    
    void Start()
    {
        transform.localScale = new Vector3(SV.ins.lineThickness,SV.ins.lineThickness,1.0f);
    }

    public void Draw_Line_ByTwoPoints(Vector2 startPoint , Vector2 endPoint){
        gameObject.SetActive(true);
        transform.position = new Vector3(startPoint.x,startPoint.y,0.0f);
        Vector2 lineVector = endPoint - startPoint;
        float lineLength = lineVector.magnitude;
        if (lineLength < 0.0001f){
            return;
        }else{
            Quaternion quat = Quaternion.Euler(0.0f , 0.0f,Vector2.SignedAngle(new Vector2(1.0f,0.0f), lineVector));
            transform.localRotation = quat;
            float scaledLength = lineLength / SV.ins.lineThickness;
            cube_obj.transform.localScale = new Vector3(scaledLength , 1.0f, 1.0f);
            end_Cricle_obj.transform.localPosition = new Vector3( scaledLength , 0.0f, 0.0f);
        }
    }



    public void destroy(){
        gameObject.SetActive(false);
    }
}
