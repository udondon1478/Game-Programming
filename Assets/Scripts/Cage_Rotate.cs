using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage_Rotate : MonoBehaviour
{
    //Game_Statusというグローバルフラグを宣言
    public static bool Game_Status = false;
    //Cageというグループのオブジェクトを回転させる
    void Update()
    {
        //Cageというグループのオブジェクトを取得
        GameObject cage = GameObject.Find("Cage");
        //Cageの中のVirtual_Pivotというオブジェクトを取得
        Transform virtualPivot = cage.transform.Find("Virtual_Pivot");
        //Virtual_Pivotを中心にCageを回転
        cage.transform.RotateAround(virtualPivot.position, Vector3.forward, 0.5f);
        //スペースキーが押されたらCageを削除し、Game_Statusをtrueにする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(cage);
            //Game_Statusというグローバルフラグをtrueにする
            Game_Status = true;
        }
    }

}
