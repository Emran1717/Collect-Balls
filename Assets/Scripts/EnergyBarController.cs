using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarController : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnergyBarController ins;

    void Awake(){
        ins = this;
    } 
    Transform FillBar;
    Vector3 localScale;
    float totoalBarLegth;
    
    void Start()
    {
        totoalBarLegth = transform.Find("Bar_Shape").transform.localScale.x;
        FillBar = transform.Find("FillShape").transform;
        localScale = FillBar.transform.localScale;
        fill_Percent (1.0f);
    }

    float currentPercent = -1.0f;
    public void fill_Percent(float percent){
//        Debug.Log("Fill Percent : " + percent);
        if (currentPercent != percent){
            currentPercent = percent;
            float fillScale = percent * totoalBarLegth;
            localScale.x = fillScale;
            FillBar.transform.localScale = localScale;
        }
    }
    
}
