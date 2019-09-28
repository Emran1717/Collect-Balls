using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.ComponentModel;

public partial class SROptions
{


    private float _max_Allowed_DrawLength = 4;
    private int _Start_Balls = 10;

    [Category("Basic")]

    public float max_Allowed_DrawLength {
		get { 
            if (PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.max_Allowed_DrawLength.ToString()) == 0){
                return 8.0f;
            }else {
                return PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.max_Allowed_DrawLength.ToString()); 
            }
        }
		set { PlayerPrefs.SetFloat(MyEnums.playerPrefsSaves.max_Allowed_DrawLength.ToString(),value);
            SV.ins.max_Allowed_DrawLength = value; 
        }
	}

    [Category("Basic")]
    public int Start_Balls {
        get { 
            if (PlayerPrefs.GetInt(MyEnums.playerPrefsSaves.Start_Balls.ToString()) == 0){
                return 10;
            }else {
                return PlayerPrefs.GetInt(MyEnums.playerPrefsSaves.Start_Balls.ToString()); 
            }
        }
        set { 
            PlayerPrefs.SetInt(MyEnums.playerPrefsSaves.Start_Balls.ToString(),value);
        }
	}



    [Category("Basic")]
    public float Gravity {
		get {
            if (PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.Gravity.ToString()) == 0){
                return 9.8f;
            }else {
                return PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.Gravity.ToString()); 
            }
        }
		set { 
            PlayerPrefs.SetFloat(MyEnums.playerPrefsSaves.Gravity.ToString(),value);
            SV.ins.Gravity = value;
        }
	}
    
        [Category("Check Point")]
        public bool CHP_AutoStart {
		get {
            if (PlayerPrefs.GetInt(MyEnums.playerPrefsSaves.checkPoint_autoStart.ToString()) == 0){
                return false;
            }else {
                return true; 
            }
        }
		set {
            if (value)
            {
                PlayerPrefs.SetInt(MyEnums.playerPrefsSaves.checkPoint_autoStart.ToString(),1);
            }else {
                 PlayerPrefs.SetInt(MyEnums.playerPrefsSaves.checkPoint_autoStart.ToString(),0);               
            }
        }
	}


    [Category("Check Point")]

    public float CHP_DelayTime {
		get {
            if (PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.checkPoint_delayTime.ToString()) == 0){
                return 5.0f;
            }else {
                return PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.checkPoint_delayTime.ToString()); 
            }
        }
		set { 
            PlayerPrefs.SetFloat(MyEnums.playerPrefsSaves.checkPoint_delayTime.ToString(),value);
            SV.ins.checkPoint_DelayTime = value;
        }
	}

    [Category("Check Point")]
    public float CHP_OpeningTime {
		get {
            if (PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.checkPoint_openTime.ToString()) == 0){
                return 1.0f;
            }else {
                return PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.checkPoint_openTime.ToString()); 
            }
        }
		set { 
            PlayerPrefs.SetFloat(MyEnums.playerPrefsSaves.checkPoint_openTime.ToString(),value);
            SV.ins.checkPoint_OpeningTime = value;
        }
	}

    [Category("Check Point")]
    public int CHP_NumBall {
		get {
            if (PlayerPrefs.GetInt(MyEnums.playerPrefsSaves.checkPoint_numberOfBalls.ToString()) == 0){
                return 1;
            }else {
                return PlayerPrefs.GetInt(MyEnums.playerPrefsSaves.checkPoint_numberOfBalls.ToString()); 
            }
        }
		set { 
            PlayerPrefs.SetInt(MyEnums.playerPrefsSaves.checkPoint_numberOfBalls.ToString(),value);
            SV.ins.checkPoint_NumOfBalls = value;
        }
	}




    [Category("Camera")]
    public float Camera_MoveTime {
		get {
            if (PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.Camera_MoveTime.ToString()) == 0){
                return 1.0f;
            }else {
                return PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.Camera_MoveTime.ToString()); 
            }
        }
		set { 
            PlayerPrefs.SetFloat(MyEnums.playerPrefsSaves.Camera_MoveTime.ToString(),value);
            SV.ins.cameraMove_MoveTime = value;
        }
	}

    [Category("Camera")]
    public float Camera_DelayTime {
		get {
            if (PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.Camera_DelayTime.ToString()) == 0){
                return 2.0f;
            }else {
                return PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.Camera_DelayTime.ToString()); 
            }
        }
		set { 
            PlayerPrefs.SetFloat(MyEnums.playerPrefsSaves.Camera_DelayTime.ToString(),value);
            SV.ins.cameraMove_DealyTime = value;
        }
	}


    [Category("Balls")]

    [NumberRange(0.0f, 1.0f)]
    public float Ball_Bounciness {
		get { 
            return PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.Ball_Bounciness.ToString()); 
        }
		set { 
            PlayerPrefs.SetFloat(MyEnums.playerPrefsSaves.Ball_Bounciness.ToString(),value);
            SV.ins.ball_Bounciness = value;
        }
	}

    [Category("Balls")]
    public float Ball_MinSize {
		get {
            if (PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.Ball_MinSize.ToString()) == 0){
                return 0.3f;
            }else {
                return PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.Ball_MinSize.ToString()); 
            }
        }
		set { 
            PlayerPrefs.SetFloat(MyEnums.playerPrefsSaves.Ball_MinSize.ToString(),value);
            SV.ins.ball_MinSize = value;
        }
	}

    [Category("Balls")]
    public float Ball_MaxSize {
		get {
            if (PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.Ball_MaxSize.ToString()) == 0){
                return 0.5f;
            }else {
                return PlayerPrefs.GetFloat(MyEnums.playerPrefsSaves.Ball_MaxSize.ToString()); 
            }
        }
		set { 
            PlayerPrefs.SetFloat(MyEnums.playerPrefsSaves.Ball_MaxSize.ToString(),value);
            SV.ins.ball_MaxSize = value;
        }
	}


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
