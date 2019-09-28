using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnums : MonoBehaviour
{

    public enum sceneNames{
        PlayScene,
    }

    public enum playerPrefsSaves {

        LevelNumber ,
        LevelName ,
        
        doLoad_SavedLevelName_int,

        max_Allowed_DrawLength,
        Start_Balls,
        Gravity,

        checkPoint_delayTime,
        checkPoint_openTime,
        checkPoint_numberOfBalls,
        checkPoint_autoStart,

        // camera

        Camera_MoveTime,
        Camera_DelayTime,

        // Balls
        Ball_Bounciness,
        Ball_MinSize,
        Ball_MaxSize,

    }
}
