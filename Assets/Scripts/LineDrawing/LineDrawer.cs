using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LineDrawer : MonoBehaviour
{

    float minAllowed_lineSize = 0.3f;
    float totalLength_Draw;
    LinePrefabController[] all_Lines;
    Vector3 outVector = new Vector3(1000.0f,0.0f,0.0f);
    Quaternion defaultQuaternin = Quaternion.identity;
    public static LineDrawer ins ;

    GameObject currentLine_obj;

    public GameObject line_Prefab;

    GameObject preLine_Shower ;
    LinePrefabController preLine_Shower_PrefabController ;

    void Awake(){
        ins = this;
    }


    bool isDrawing ;

    bool isFirstLine ;

    int numLineArray ; 

    int current_LineNumber_Add;
    int current_LineNumber_Add_Normalized;
    int current_LineNumber_Remove;
    int current_LineNumber_Remove_Normalized;

    public Transform lines_Parent;
    void Start()
    {
        current_LineNumber_Add = 0;
        current_LineNumber_Remove = 0;

        isFirstLine = true;
        totalLength_Draw = 0.0f;

        premade_LinesPool ();

        preLine_Shower = Instantiate(line_Prefab ,outVector,defaultQuaternin) as GameObject;
        preLine_Shower_PrefabController = preLine_Shower.GetComponent<LinePrefabController>();

        SV.ins.used_Lines = 0;
        isDrawing = false;
    }

    public void premade_LinesPool(){
        SV.ins.max_Allowed_Lines = (int) (SV.ins.max_Allowed_DrawLength / SV.ins.line_MaxPieceLength);
        numLineArray = SV.ins.max_Allowed_Lines + 10;
        all_Lines = new LinePrefabController[numLineArray];
        for (int  i = 0;  i < numLineArray;  i++)
        {
            GameObject new_line = Instantiate(line_Prefab ,outVector,defaultQuaternin) as GameObject;
            all_Lines [i]  = new_line.GetComponent<LinePrefabController>();
            new_line.transform.parent = lines_Parent;
        }

    }

    Vector2 preLine_startPoint;
    Vector2 preLine_endPoint;

    public void draw_PreLine_started(Vector2 touchPos){

        if (!isFirstLine){
            makeLinesBetweenTwoPoints(preLine_startPoint , preLine_endPoint);
        }else {           
            isFirstLine = false;
        }
        preLine_startPoint = touchPos;
        isDrawing = true;
        //preLine_Shower_PrefabController.StartDrawing(start_point);
        //preLine_Shower_PrefabController.Modify_Length_And_Rotation(start_point);
    }

    public void draw_PreLine_ended(){
        isDrawing = false;
        //makeLinesBetweenTwoPoints(start_point , touchPos , 0.0f);
    }

    float currentline_Length ;
   public void Modify_PreLine (Vector2 toPoint){
       if (isDrawing){
            preLine_endPoint = toPoint;
            if (preLine_startPoint.x == preLine_endPoint.x && preLine_startPoint.y == preLine_endPoint.y){
                return ;
            }
            Vector2 lineVector = preLine_endPoint - preLine_startPoint;
            currentline_Length = lineVector.magnitude;
            preLine_Shower_PrefabController.Draw_Line_ByTwoPoints(preLine_startPoint, preLine_endPoint);
            if (currentline_Length > 10.0f){
                Debug.Log(" currentline_Length : " + currentline_Length );
                Debug.Log(" preLine_startPoint : " + preLine_startPoint );
                Debug.Log(" preLine_endPoint : " + preLine_endPoint );
            }

            if (currentline_Length > SV.ins.line_MaxPieceLength){
                int numPart = (int)(currentline_Length / SV.ins.line_MaxPieceLength);
                float sc1  = SV.ins.line_MaxPieceLength / currentline_Length;
                Vector2 scaledVector = lineVector * sc1;
                Vector2 p1 = preLine_startPoint;
                for (int  i = 0;  i < numPart;  i++){
                    Vector2 p2 = p1 + scaledVector ;
                    makeLinesBetweenTwoPoints(p1, p2);
                    p1 = p2;
                }
                preLine_startPoint = p1;
                preLine_Shower_PrefabController.Draw_Line_ByTwoPoints(preLine_startPoint,preLine_endPoint);
            }
       }else {
           // draw_PreLine_started(toPoint);
       }


       //SendMessageUpwards 
    }

    void makeLinesBetweenTwoPoints(Vector2 p1 , Vector2 p2){

        if (p1 == p2){
            return ;
        }
        current_LineNumber_Add ++ ;
        current_LineNumber_Add_Normalized = current_LineNumber_Add % numLineArray;
        // start drawing a line piece
        all_Lines[current_LineNumber_Add_Normalized].Draw_Line_ByTwoPoints(p1 , p2);
        if (current_LineNumber_Add > current_LineNumber_Remove + SV.ins.max_Allowed_Lines){
            int numLinesToRemove = current_LineNumber_Add - current_LineNumber_Remove - SV.ins.max_Allowed_Lines;
            for (int i = 0; i < numLinesToRemove; i++)
            {
                current_LineNumber_Remove ++;
                current_LineNumber_Remove_Normalized = current_LineNumber_Remove % numLineArray;
                all_Lines[current_LineNumber_Remove_Normalized].destroy();
            }
            EnergyBarController.ins.fill_Percent(0);
        }else {
            int remaindLines =  SV.ins.max_Allowed_Lines - current_LineNumber_Add + current_LineNumber_Remove;
            EnergyBarController.ins.fill_Percent((float)remaindLines / (float)SV.ins.max_Allowed_Lines);
        }
    }

}
