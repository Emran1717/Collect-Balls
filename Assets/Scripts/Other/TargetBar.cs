using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBar : MonoBehaviour
{
    // Start is called before the first frame update
  public static TargetBar ins;

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
        fill_Percent (0.0f);
    }

    float currentPercent = -1.0f;
    public void fill_Percent(float percent){
        Debug.Log("Fill Percent : " + percent);
        if (currentPercent != percent){
            currentPercent = percent;
            if ( percent > 1.0f )
            {
                percent = 1.0f + (percent - 1.0f) / 10.0f;
            }
            float fillScale = percent * totoalBarLegth;
            localScale.x = fillScale;
            FillBar.transform.localScale = localScale;
        }
    }
}
