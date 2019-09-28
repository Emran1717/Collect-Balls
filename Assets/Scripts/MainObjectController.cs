using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObjectController : MonoBehaviour
{
    
    public Camera camera_2D;
    public Camera mainCamera;

    float horizontalFOV = 60;
    float space_Width ;
    float space_Height ;

    void Start()
    {
        
        // 
        //DontDestroyOnLoad(transform.parent);
        // this level variables
            SV.ins.numSpawners = 2;
            SV.ins.isBallsGroup_colory = new bool[10];
        //
        SV.ins.totNum_BallColors = SV.ins.Materials_BallColors.Length;
        SV.ins.current_TargetBowlNumber = 0;
        SV.ins.totNum_Remained_ColoryBalls = 0;

        //
		space_Width = 10.0f;
		space_Height = space_Width * Screen.height / Screen.width;
		camera_2D.orthographicSize = space_Height /2.0f;
        SV.ins.Camera_FieldOfView_Vertical = calcVertivalFOV(horizontalFOV, mainCamera.aspect);
 		mainCamera.fieldOfView = SV.ins.Camera_FieldOfView_Vertical;

         // 
        GameObject restartButton = GameObject.Find("RestartButton").gameObject;
        Vector3 restartButton_pos = restartButton.transform.position ;
        restartButton_pos.y = space_Height / 2.0f - 0.6f;
        restartButton.transform.position = restartButton_pos;
        GameObject energyBar = GameObject.Find("EnergyBar").gameObject;
        Vector3 energyBar_pos = energyBar.transform.position ;
        energyBar_pos.y = space_Height / 2.0f - 0.3f;
        energyBar.transform.position = energyBar_pos;



        if (SV.ins.readFrom_SRDebugger){
            SV.ins.max_Allowed_DrawLength = SROptions.Current.max_Allowed_DrawLength;
            SV.ins.Gravity = SROptions.Current.Gravity;
            SV.ins.checkPoint_DelayTime = SROptions.Current.CHP_DelayTime;
            SV.ins.checkPoint_NumOfBalls = SROptions.Current.CHP_NumBall;
            SV.ins.checkPoint_OpeningTime = SROptions.Current.CHP_OpeningTime;
            SV.ins.cameraMove_DealyTime = SROptions.Current.Camera_DelayTime;
            SV.ins.cameraMove_MoveTime = SROptions.Current.Camera_MoveTime;
            SV.ins.ball_Bounciness = SROptions.Current.Ball_Bounciness;
            SV.ins.ball_MinSize = SROptions.Current.Ball_MinSize;
            SV.ins.ball_MaxSize = SROptions.Current.Ball_MaxSize;
        }

        ballBouncingMaterial.bounciness = Mathf.Clamp( SV.ins.ball_Bounciness , 0.0f, 1.0f); 

        Physics.gravity = new Vector3(0.0f, - SV.ins.Gravity ,0.0f);

    }

 	private float calcVertivalFOV(float hFOVInDeg, float aspectRatio)
     {
         float hFOVInRads = hFOVInDeg * Mathf.Deg2Rad;  
         float vFOVInRads = 2 * Mathf.Atan(Mathf.Tan(hFOVInRads / 2) / aspectRatio);
         float vFOV = vFOVInRads * Mathf.Rad2Deg;
         return vFOV;
     }

     public PhysicMaterial ballBouncingMaterial ;

}
