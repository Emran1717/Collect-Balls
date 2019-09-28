using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsShower : MonoBehaviour
{

    public static EffectsShower ins ;

    Quaternion defaultQuaternino = Quaternion.identity;
    void Awake(){
        ins = this;
    }

    public GameObject DestroyedBall_Prefab;
    public GameObject CollectedBall_Prefab;
    public GameObject DestroyedLine_Prefab;

    void Start()
    {
        
    }

    public void show_DestroyedBall(GameObject mainBall){
        //GameObject obj = Instantiate(DestroyedBall_Prefab , mainBall.transform.position , defaultQuaternino) as GameObject;
        //obj.transform.localScale = mainBall.transform.localScale;
        Destroy(mainBall);
    }


}
