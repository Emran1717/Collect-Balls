using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedBallController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Rigidbody[] all_Particles_RigidBody;
    void Start()
    {
        show_ExplosionEffect();
    }

    void show_ExplosionEffect(){
        int num_particles = all_Particles_RigidBody.Length;
        //float force_sc = Random.Range(0.7f,1.0f);
        for (int  i = 0;  i < num_particles;  i++) {
            float v_x = Random.Range(0.2f,1.0f);
            float v_y = Random.Range(3.0f,10.0f);
            float v_z = Random.Range(-0.2f,0.0f);
            all_Particles_RigidBody[i].AddForce(new Vector3(v_x, v_y , v_z));
        }
    }

}
