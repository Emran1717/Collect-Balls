using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController ins;

    public GameObject LevelInfoMenu;
    public GameObject Win_Menu;
    public GameObject Lose_Menu;
    const float totalTime_MoreEating_eachIntervalDelay = 0.1f;
    public float totalTime_MoreEating;
    int numberOf_MoreEating_Interval;

    void Awake(){
        ins = this;
    }

    void Start()
    {
        SV.ins.hasDoneLevel = false;
        //TargetBar.ins.fill_Percent(0.0f);
        numberOf_MoreEating_Interval = (int) (totalTime_MoreEating / totalTime_MoreEating_eachIntervalDelay);
        LevelInfoMenu.SetActive(false);
        Win_Menu.SetActive(false);
        Lose_Menu.SetActive(false);
        StartCoroutine(showMenu_LevelInfo());
    }

    WaitForSeconds winCompletion_delay = new WaitForSeconds(totalTime_MoreEating_eachIntervalDelay);
    public IEnumerator Win_happend(){
        SV.ins.hasDoneLevel = true;
        yield return null;
        // extra time to win complete
        for (int  i = 0;  i < numberOf_MoreEating_Interval;  i++)
        {
            yield return winCompletion_delay;
            if (SV.ins.totNum_BallColors == 0) 
            {
                break;
            }
        }
        StartCoroutine(showMenu_Win());
    }

    IEnumerator showMenu_LevelInfo(){
        yield return new WaitForSeconds(0.2f);
        LevelInfoMenu.SetActive(true);
        LevelInfoMenu.transform.Find("LevelNumber").GetComponent<TextMesh>().text = $"Level {SV.ins.curretnLevelNumber}";
        LevelInfoMenu.transform.Find("TXT_Info").GetComponent<TextMesh>().text = $"Collect {SV.ins.totNumCollect_ToWin} Balls to Win.";
        yield return new WaitForSeconds(1.5f);
        LevelInfoMenu.SetActive(false);
    }

    IEnumerator showMenu_Win(){
        yield return new WaitForSeconds(0.2f);
        Win_Menu.SetActive(true);
        Win_Menu.transform.Find("TXT_Info").GetComponent<TextMesh>().text = $"{SV.ins.numCollectedBalls} / {SV.ins.totNumCollect_ToWin}";
    }

    
    IEnumerator showMenu_Lose(){
        yield return new WaitForSeconds(0.2f);
        Lose_Menu.SetActive(true);
        Lose_Menu.transform.Find("TXT_Info").GetComponent<TextMesh>().text = $"{SV.ins.numCollectedBalls} / {SV.ins.totNumCollect_ToWin}";
    }


     public void goto_NextLevel(){
         LevelController.ins.LevelUp_AndSave();
         UnityEngine.SceneManagement.SceneManager.LoadScene(MyEnums.sceneNames.PlayScene.ToString());
    }   
    public void goto_PreviousLevel(){
         LevelController.ins.LevelDown_AndSave();
         UnityEngine.SceneManagement.SceneManager.LoadScene(MyEnums.sceneNames.PlayScene.ToString());
    }  

    public void check_DoContinueOrFailed(){
        Debug.Log ("Remained Balls : " + SV.ins.totNum_Remained_ColoryBalls );
        if (SV.ins.totNum_Remained_ColoryBalls == 0){
            // Debug.Log("Has Done LEvel : " + SV.ins.hasDoneLevel);
            if (SV.ins.hasDoneLevel){
                
            }else{
                StartCoroutine(showMenu_Lose());
            }
        }
    }

}
