using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy_RandomTime : MonoBehaviour
{

    public float time;
    public float ranomTime_Range;

    void Start()
    {
        StartCoroutine(selfDestroy_byDelay());
    }

    IEnumerator selfDestroy_byDelay(){
        yield return new WaitForSeconds(time + Random.Range(0.0f,ranomTime_Range));
        Destroy (gameObject);
    }
}
