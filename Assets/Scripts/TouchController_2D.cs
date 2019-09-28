using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController_2D : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera_2D;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
			Vector2 touchWorldPoint = camera_2D.ScreenToWorldPoint (Input.mousePosition);
			Collider2D hitCollider = Physics2D.OverlapPoint (touchWorldPoint);
			if (hitCollider) {
                Debug.Log("hitCollider.transform.name : " + hitCollider.transform.name);
				if (hitCollider.transform.name == "RestartButton" ) {
                    //Application.LoadLevel(Application.loadedLevelName);
                    UnityEngine.SceneManagement.SceneManager.LoadScene(MyEnums.sceneNames.PlayScene.ToString());

				}else if (hitCollider.transform.name == "NextButton" ) {
                    GameController.ins.goto_NextLevel();
				}else if (hitCollider.transform.name == "Butt-NextLevel" ) {
                    GameController.ins.goto_NextLevel();
				}else if (hitCollider.transform.name == "Butt-PreLevel" ) {
                    GameController.ins.goto_PreviousLevel();

				}
			}
		}
    }
}
