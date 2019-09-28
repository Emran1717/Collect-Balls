using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public int group_Number;
    public bool isColory;
    //public bool isEnteredToBowl = false;

    Rigidbody ball_rigidBody;
    void Start()
    {
      ball_rigidBody = GetComponent<Rigidbody>();
      //  isEnteredToBowl =false;
      if (!isColory){
          start_WhiteBallListener();
      }
    }

    public void entered_toBowl(){
       // isEnteredToBowl = true;
    }

    public void start_WhiteBallListener(){
        WhiteBalls_Listener whiteBalls_Listener =  GetComponent<WhiteBalls_Listener>();
        whiteBalls_Listener.group_number = group_Number;
        whiteBalls_Listener.enabled = true;
    }

    public void Color_It_White(){
        GetComponent<MeshRenderer>().material = SV.ins.Material_WhiteColor;
    }

    public void Color_it_RandomLy(){
        SV.ins.totNum_Remained_ColoryBalls ++ ;
        int ballColorNumber = Random.Range(0,SV.ins.totNum_BallColors);
        GetComponent<MeshRenderer>().material = SV.ins.Materials_BallColors[ballColorNumber];
        isColory = true;
        gameObject.tag = SV.tag_Ball;
    }  

    public void Destroy_It(int Mode){ // 0-> No Need Effects 1-> NeedsEffect
        SV.ins.totNum_Remained_ColoryBalls -- ;
        GameController.ins.check_DoContinueOrFailed();
        Destroy(gameObject);
    }  

    public void AddForce(Vector3 forceVector){
        ball_rigidBody.AddForce(forceVector);
    }  

}
