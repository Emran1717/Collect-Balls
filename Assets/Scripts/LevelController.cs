using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelController ins;

    public bool Do_loadLevel;
    public int LevelNumner;

    int minLevelNumber = 1;
    int maxLevelNumber = 3;
    void Awake(){
        ins = this;
    }

    void Start()
    {
        
        if (Do_loadLevel){
            if ( LevelNumner != 0) {
                PlayerPrefs.SetInt(MyEnums.playerPrefsSaves.LevelNumber.ToString() , LevelNumner);
            }
            LevelNumner  = PlayerPrefs.GetInt(MyEnums.playerPrefsSaves.LevelNumber.ToString());
            if ( LevelNumner < minLevelNumber)
            {
                LevelNumner = minLevelNumber;
                PlayerPrefs.SetInt(MyEnums.playerPrefsSaves.LevelNumber.ToString() , LevelNumner);
            }else  if ( LevelNumner > maxLevelNumber){
                LevelNumner = maxLevelNumber;
                PlayerPrefs.SetInt(MyEnums.playerPrefsSaves.LevelNumber.ToString() , LevelNumner);
            }
//            Destroy(GameObject.Find("MAP").gameObject); 
            Load_Level_ByNumber(LevelNumner);
        }
    }

    public void LevelUp_AndSave(){
        LevelNumner ++;
        Debug.Log(" Changed Level Number : " + LevelNumner) ;
        PlayerPrefs.SetInt(MyEnums.playerPrefsSaves.LevelNumber.ToString() , LevelNumner);
    }
    public void LevelDown_AndSave(){
        LevelNumner --;
        Debug.Log(" Changed Level Number : " + LevelNumner) ;
        PlayerPrefs.SetInt(MyEnums.playerPrefsSaves.LevelNumber.ToString() , LevelNumner);
    }

    public void Load_Level_ByNumber(int lNumber){
        SV.ins.curretnLevelNumber = lNumber;
        Debug.Log(" Level Number : " + lNumber) ;
        string levelName = "";
        switch (lNumber){
            case 1 :
                levelName = "0-Basic-1";
            break;
            case 2 :
                levelName = "0-Basic-2";
            break;
            case 3 :
                levelName = "0-Basic-3";
            break;            
        }

        if (levelName != ""){
            Load_Level_ByName(levelName);
        }

    }


    public void Load_Level_ByName(string levelSceneName){
        // 
        string level_path = $"Levels/{levelSceneName}";
        GameObject level_prefab = Resources.Load(level_path , typeof(GameObject)) as GameObject;
        Vector3 placingPointOfMap = new Vector3 (0.0f , 0.0f,0.0f);
        GameObject loadedMap = Instantiate(level_prefab , placingPointOfMap , Quaternion.identity ) as GameObject;


        // GameObject.Find("StartBallSpawner").GetComponent<BallSpawner>().totalNumberOfBalls = SROptions.Current.Start_Balls;

    }
}
