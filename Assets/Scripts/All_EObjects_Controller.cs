using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class All_EObjects_Controller : MonoBehaviour
{

    public static All_EObjects_Controller ins;

    void Awake(){
        ins = this;

    }

    

    List<EObjectController> EObject_List = new List<EObjectController>();
    void Start()
    {
        // list all E Objects
        foreach(Transform tr in transform){
            EObject_List.Add(tr.GetComponent<EObjectController>());

        }
    }

    public void Rotate_All(){
        int num_EObjects = EObject_List.Count;
        for (int i=0;i<num_EObjects;i++)
        {
            EObject_List[i].RotateObject();
        }
    }

    public void Rotate_A_Littile(float value, float deltaTime){
        int num_EObjects = EObject_List.Count;
        for (int i=0;i<num_EObjects;i++)
        {
            EObject_List[i].Rotate_A_Little(value,deltaTime);
        }
    }
}
