using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
        //Playerタグのオブジェクトに接触したら
        //色をかえる
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
                //Object_Aの色をPlayerタグのマテリアルの色に変更
                GetComponent<Renderer>().material.color = other.gameObject.GetComponent<Renderer>().material.color;
                //時間をかけて段階的に色を白に戻す
                StartCoroutine("ChangeColor");

            }
        }

        //色を変更するコルーチン
        IEnumerator ChangeColor()
        {
            //色を段階的に変更
            for (int i = 0; i < 500; i++)
            {
                //色を段階的に変更
                GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, Color.white, 0.01f);
                //0.01秒待つ
                yield return new WaitForSeconds(0.01f);
            }
        }


    // Update is called once per frame
    void Update()
    {

    }
}
