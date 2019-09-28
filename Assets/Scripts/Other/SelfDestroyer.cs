using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    void Start()
    {
        StartCoroutine(selfDestroy_byDelay());
    }

    IEnumerator selfDestroy_byDelay(){
        yield return new WaitForSeconds(time);
        Destroy (gameObject);
    }
}
