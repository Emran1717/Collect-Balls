using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController ins ;

    float delatY = -13.0f;
    Vector3 cameraPos ;

    void Awake(){
        ins = this;
    }

    void Start()
    {
        cameraPos = transform.localPosition;
    }

    public IEnumerator moveCameraToY_byDelay_IEn(float y , float delayTime){
        yield return new WaitForSeconds(delayTime);
        //cameraPos.y = Mathf.Max(y , SV.ins.FinalBox_Pos_Y) + delatY ;
        float newY =  y +  delatY ;
        if (newY < cameraPos.y )
        {
            cameraPos.y = y +  delatY ;
    //        Debug.Log("Final Y : " + cameraPos.y );
            iTween.MoveTo(gameObject, iTween.Hash("position", cameraPos,"time", SV.ins.cameraMove_MoveTime,"easeType", iTween.EaseType.easeInOutQuad, "loopType", iTween.LoopType.none, "delay", 0.0f,"islocal",false));            
        }
    }
}
