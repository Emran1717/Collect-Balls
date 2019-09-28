using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBowlController : MonoBehaviour
{
    // Start is called before the first frame update
    public int numCollect_ToWin ;


    Vector3 currentParentPos ;

    float delat_y = 0.05f;

    GameObject win_obj ;
    void Start()
    {
        win_obj = transform.Find("WinObject").gameObject;
        currentParentPos = transform.localPosition;
        SV.ins.totNumCollect_ToWin = numCollect_ToWin;
        SV.ins.FinalBox_Pos_Y = transform.position.y;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals(SV.tag_Ball)){
            Debug.Log("Collected");
            GameObject collectedBall = other.gameObject;
            collectedBall.tag = SV.tag_OtherBall;
            SV.ins.numCollectedBalls ++ ;
            TargetBar.ins.fill_Percent((float)SV.ins.numCollectedBalls / (float)numCollect_ToWin);
            if (SV.ins.numCollectedBalls >= numCollect_ToWin){
                if (SV.ins.numCollectedBalls == numCollect_ToWin){
                
                    moveDownEffect();
                    Show_Win_Effect();
                }else{

                }
            }else{
                moveDownEffect();
            }
            Show_Collect_Effect(collectedBall);
        }
    }
    void moveDownEffect(){
        Debug.Log("numCollected : " + SV.ins.numCollectedBalls);
        currentParentPos.y -= delat_y;
        transform.localPosition = currentParentPos;
    }

    void Show_Collect_Effect(GameObject collectedBall){
        SV.ins.totNum_Remained_ColoryBalls -- ;
        GameController.ins.check_DoContinueOrFailed();
        Destroy(collectedBall);
    }

    void Show_Win_Effect(){
        win_obj.SetActive(true);
        StartCoroutine(GameController.ins.Win_happend());
    }



}
