using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneController : MonoBehaviour
{
    public bool DoLoadInGameMode ;
    void Start()
    {
        if (DoLoadInGameMode){
            string thisSceneName = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString(MyEnums.playerPrefsSaves.LevelName.ToString(), thisSceneName);
            PlayerPrefs.SetInt(MyEnums.playerPrefsSaves.doLoad_SavedLevelName_int.ToString(), 1);
            SceneManager.LoadScene(MyEnums.sceneNames.PlayScene.ToString());  
        }else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
