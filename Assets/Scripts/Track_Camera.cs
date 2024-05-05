using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_Camera : MonoBehaviour
{
    //Playerタグを持つオブジェクトのうち最もY座標が小さいものを追跡する
    void Update()
    {
        //Cage_Rotate.csのGame_Statusを読み込み
        if (Cage_Rotate.Game_Status)
        {

            //Playerタグを持つオブジェクトを全て取得
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            //最もY座標が小さいオブジェクトを取得
            GameObject target = players[0];
            foreach (GameObject player in players)
            {
                if (player.transform.position.y < target.transform.position.y)
                {
                    target = player;
                }
            }
            //targetが変わったらカメラの位置をスムーズに移動

            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, target.transform.position.y, transform.position.z), Time.deltaTime * 2);
        }

    }
}
