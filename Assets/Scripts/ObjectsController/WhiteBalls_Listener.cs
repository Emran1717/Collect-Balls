using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBalls_Listener : MonoBehaviour
{
    // Start is called before the first frame update
    public int group_number ;
    bool isActive;
    void Start()
    {
        isActive = true;
    }

    void OnCollisionEnter(Collision collision) {
        if (isActive){
            if (collision.gameObject.tag.Equals(SV.tag_Ball)){
                //Debug.Log("White Ball _ Collistion");
                //int collidedBall_groupNumber = collision.gameObject.GetComponent<BallController>().group_Number;
                if (!SV.ins.isBallsGroup_colory[group_number]){
                    SV.ins.isBallsGroup_colory[group_number] = true;
                    isActive = false;
                    colory_allBallsOfGroup(group_number);
                    this.enabled = false;
                }
            }
        }
    }

    void colory_allBallsOfGroup(int gNumber){
        //Debug.Log("Started Collring Balls ... ");
        int numBalls = SV.ins.All_Balls.Count;
        for (int i  = 0;  i < numBalls; i ++){
            if (SV.ins.All_Balls[i].group_Number == gNumber){
                SV.ins.All_Balls[i].Color_it_RandomLy();
                SV.ins.All_Balls[i].isColory = true;
            }
        }
    }

}
