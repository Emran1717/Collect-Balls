using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool do_MoveCamera = true; 
    bool is_ButtonOn = false;
    public int bowlNumber;
    public bool isStatic ;
    public bool isStartGate;
    public bool doStartAutomatically;
    public bool isGate ;
    public GameObject leftHand;
    public GameObject RightHand;

    float move_X = 1.0f;
    public float moveTime;
    public float move_Delay;
    
    bool hasSendCameraMoveCommand = false;
    Vector3 currentParentPos ;

    int numCollected = 0;

    public GameObject Button_obj;
    void Start()
    {
        moveTime = SV.ins.checkPoint_OpeningTime;
        move_Delay = SV.ins.checkPoint_DelayTime;
        hasSendCameraMoveCommand = false;
        numCollected = 0;
        currentParentPos = transform.localPosition;
        // start appearance
        if (isStartGate){
            is_ButtonOn = true;
            Button_obj.GetComponent<MeshRenderer>().material = SV.ins.Material_Button_On;
        }else{
            is_ButtonOn = false;
            Button_obj.GetComponent<MeshRenderer>().material = SV.ins.Material_Button_Off;
        }

        if (doStartAutomatically){
            StartIt();
        }
    }

    public void on_TheButton(){
        Debug.Log("On The Burron --- ");
        is_ButtonOn = true;
        Button_obj.GetComponent<MeshRenderer>().material = SV.ins.Material_Button_On;
    }

    bool isOpen = false;

    public void StartIt(){
        if (!isStatic){
            if (!isOpen){
                isOpen = true;
                StartCoroutine( increase_TargetBowlNumber_ByDelay());
                StartCoroutine(start_opening_gate_byDealy());
            }
        }
    }

    IEnumerator start_opening_gate_byDealy(){
        move_Delay = 0.05f;
        move_X = 2.0f;
        yield return new WaitForSeconds(move_Delay);
        iTween.MoveBy(leftHand, iTween.Hash("x", -move_X,"time", moveTime,"easeType", iTween.EaseType.linear, "loopType", iTween.LoopType.none, "delay", 0.0f,"islocal",false));
        //iTween.RotateBy(leftHand, iTween.Hash("x", Mathf.PI / 10.0f,"time", moveTime,"easeType", iTween.EaseType.linear, "loopType", iTween.LoopType.none, "delay", 0.0f,"islocal",false));
        iTween.MoveBy(RightHand, iTween.Hash("x", move_X,"time", moveTime,"easeType", iTween.EaseType.linear, "loopType", iTween.LoopType.none, "delay", 0.0f,"islocal",false));
        //iTween.RotateBy(leftHand, iTween.Hash("x",  Mathf.PI / 10.0f,"time", moveTime,"easeType", iTween.EaseType.linear, "loopType", iTween.LoopType.none, "delay", 0.0f,"islocal",false));
    }


        List<GameObject> list_collectedBalls = new List<GameObject>();
    float delat_y = 0.06f;


    private void OnTriggerStay(Collider other)
    {
//                    Debug.Log("Trigger Entered : " + other.tag );
        if (bowlNumber == SV.ins.current_TargetBowlNumber || true){
            if (other.tag.Equals(SV.tag_Ball)){
                //Debug.Log("Trigger Entered : " + other.tag );
                if (!list_collectedBalls.Contains(other.gameObject)){
                    //BallController ball = other.gameObject.GetComponent<BallController>();
                    //if (ball.isColory){
                        numCollected ++ ;
                        list_collectedBalls.Add(other.gameObject);
                        if (!hasSendCameraMoveCommand && numCollected >= SV.ins.checkPoint_NumOfBalls){
                            //Debug.Log("Camera Move !!!");
                            hasSendCameraMoveCommand = true;
                            if (do_MoveCamera){
                                StartCoroutine(CameraController.ins.moveCameraToY_byDelay_IEn(transform.position.y,SV.ins.cameraMove_DealyTime));
                            }
                            // Open Pad 
                            on_TheButton();
                        }
                    //}
                    //moveDownEffect();
                }
            }
        }
    }

    IEnumerator increase_TargetBowlNumber_ByDelay(){
        yield return new WaitForSeconds(0.5f);
        SV.ins.current_TargetBowlNumber ++ ;
    }

    void moveDownEffect(){
        Debug.Log("numCollected : " + numCollected);
        currentParentPos.y -= delat_y;
        transform.localPosition = currentParentPos;
    }
}
