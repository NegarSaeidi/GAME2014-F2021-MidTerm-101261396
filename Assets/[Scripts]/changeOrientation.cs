using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeOrientation : MonoBehaviour
{
    public string Orientation;
    public Vector3 horizontal_pos1, horizontal_pos2,vertical_pos1,vertical_pos2,scHorizontal_Pos,liveHorizontal_Pos,scVertical_pos,liveVertical_pos;
    public GameObject score, lives;
    public GameObject[] backgrounds;
    // Start is called before the first frame update
    public void onVertical()
    {
        Orientation = "portrait";
       
            backgrounds[0].transform.position = vertical_pos1;
            backgrounds[1].transform.position = vertical_pos2;
            backgrounds[0].transform.rotation = new Quaternion(backgrounds[0].transform.rotation.x, backgrounds[0].transform.rotation.y, 0.0f, 0.0f);
            backgrounds[1].transform.rotation = new Quaternion(backgrounds[0].transform.rotation.x, backgrounds[0].transform.rotation.y, 0.0f, 0.0f);
            score.transform.position = scVertical_pos;
            lives.transform.position = liveVertical_pos;
       
    }
    public void OnLandescape()
    {
        Orientation = "landescape";
        
            backgrounds[0].transform.position = horizontal_pos1;
            backgrounds[1].transform.position = horizontal_pos2;
            backgrounds[0].transform.rotation = new Quaternion( backgrounds[0].transform.rotation.x, backgrounds[0].transform.rotation.y, -90.0f,0.0f);
            backgrounds[1].transform.rotation = new Quaternion(backgrounds[0].transform.rotation.x, backgrounds[0].transform.rotation.y, -90.0f, 0.0f);
            score.transform.position = scHorizontal_Pos;
            lives.transform.position = liveHorizontal_Pos;
        
       
    }
    

}
