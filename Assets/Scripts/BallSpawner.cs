using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public int createadBalls_GroupNumber;
    public bool is_WhiteBalls_Creator;
    public bool do_directlySpawn;
    public int totalNumberOfBalls ;
    float spawn_x_telorance ;
    float spawn_x;
    float spawn_y;
    
    public float ballSize_min = 0.5f;
    public float ballSize_max = 1.0f;

    public GameObject ballPrefab; 




    Quaternion defaultQuaternion = Quaternion.identity;

 
    Transform balls_parent ;
    void Start()
    {

        ballSize_min = SV.ins.ball_MinSize;
        ballSize_max = SV.ins.ball_MaxSize;
        
        // appearance
            transform.Find("Telorance").GetComponent<MeshRenderer>().enabled = false;
        //
        balls_parent = GameObject.Find("All_Balls").transform;
        spawn_x_telorance = transform.Find("Telorance").gameObject.transform.localScale.x;
        spawn_x = transform.position.x;
        spawn_y = transform.position.y;

        if (totalNumberOfBalls == 0 ){
            StartCoroutine(make_random_Ball_ByDelay(0.001f , true));
        }else {
            // make inital Balls
            if (do_directlySpawn){
                makeAllBalls_Imediatly();
            }else{
                for (int  i = 0;  i < totalNumberOfBalls;  i++)
                {
                    StartCoroutine(make_random_Ball_ByDelay((i*0.2f),false));
                }
            }
        }
    }

    IEnumerator make_random_Ball_ByDelay(float t1 , bool doContinue){
        yield return new WaitForSeconds(t1);
        make_RandomBall();
        if (doContinue){
            float randomT = Random.Range(0.1f,0.2f);
            StartCoroutine(make_random_Ball_ByDelay(randomT , doContinue));
        }
    }

    void makeAllBalls_Imediatly(){
        int numCol = (int)(spawn_x_telorance / ballSize_max);
        int iRow = 0;
        int iCol = 0;
        for (int  i = 0;  i < totalNumberOfBalls;  i++){
            iCol = i % numCol;
            iRow = (int)(i / numCol);
            spawn_x = transform.position.x - spawn_x_telorance / 2.0f + iCol * ballSize_max + ballSize_max/2.0f;
            spawn_y = transform.position.y + iRow * ballSize_max + ballSize_max/2.0f;
            Vector3 spawnPoint = new Vector3(spawn_x,spawn_y,0.0f);
            makeBall_atPoint(spawnPoint);
        }
    }
    void make_RandomBall() {
        spawn_x = transform.position.x;
        spawn_y = transform.position.y;
        float x = spawn_x - spawn_x_telorance / 2.0f + Random.Range(0.0f,spawn_x_telorance);
        Vector3 spawnPoint = new Vector3(x,spawn_y,0.0f);
        makeBall_atPoint(spawnPoint);
    }

    void makeBall_atPoint(Vector3 spawnPoint){
        GameObject ball_obj = Instantiate(ballPrefab,spawnPoint,defaultQuaternion) as GameObject;
        ball_obj.transform.parent = balls_parent;
        float bSize = Random.Range(ballSize_min, ballSize_max);
        ball_obj.transform.localScale = new Vector3(bSize,bSize,bSize);
        if (is_WhiteBalls_Creator){
            BallController ball_Controller = ball_obj.GetComponent<BallController>();
            ball_Controller.group_Number = createadBalls_GroupNumber;
            ball_Controller.isColory = false;
            ball_Controller.Color_It_White();
            ball_obj.tag = SV.tag_WhiteBall;
            SV.ins.All_Balls.Add(ball_Controller);

        }else{
            BallController ball_Controller = ball_obj.GetComponent<BallController>();
            ball_Controller.group_Number = createadBalls_GroupNumber;
            ball_Controller.isColory = true;
            ball_obj.tag = SV.tag_Ball;
            ball_Controller.Color_it_RandomLy();
            SV.ins.All_Balls.Add(ball_Controller);
        }
    }



}
