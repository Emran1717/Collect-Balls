using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SV : MonoBehaviour
{


    public static SV ins    ;

    public const string tag_Ball = "Ball";  
    public const string tag_OtherBall = "Ball-Other";  
    public const string tag_WhiteBall = "WhiteBall"; 

/*
    public const Vector3[] random_Directions = new {
        new Vector3(2.0f,5.0f,-1.0f);
    };
 */
 
    void Awake(){
        ins = this;
    }

    public bool checkPooints_doStartAutomatically;
    public bool readFrom_SRDebugger;

    // Draw Lines Parameters
    public float max_Allowed_DrawLength ;
    public float lineThickness ;
    public float line_MaxPieceLength;
    public float Gravity;

    public float checkPoint_DelayTime;
    public float checkPoint_OpeningTime;
    public float checkPoint_NumOfBalls;

    // Camera
    public float cameraMove_DealyTime;
    public float cameraMove_MoveTime;

    // Balls
    
    public float ball_Bounciness ;
    public float ball_MaxSize;
    public float ball_MinSize;


    //
    public Material[] Materials_BallColors;
    public Material Material_WhiteColor;
    public Material Material_Button_On;
    public Material Material_Button_Off;


    public int numSpawners;


#region  Hide Varibales

    [HideInInspector]

    public bool[] isBallsGroup_colory ;



    [HideInInspector]
    public int used_Lines , max_Allowed_Lines , totNum_BallColors, totNum_Remained_ColoryBalls , current_TargetBowlNumber ;
    [HideInInspector]
    public int totNumCollect_ToWin , numCollectedBalls , curretnLevelNumber;
    [HideInInspector]
    public bool hasDoneLevel ;
    [HideInInspector]
    public List<BallController> All_Balls = new List<BallController>();

    [HideInInspector]
    public float Camera_FieldOfView_Vertical , FinalBox_Pos_Y;

#endregion

    void start(){
        if (readFrom_SRDebugger){
            //max_Allowed_Lines = SROptions.Current.MyProperty
        }
    }

}
