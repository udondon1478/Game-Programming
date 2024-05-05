using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple : MonoBehaviour
{
    //update関数は毎フレーム呼ばれる
    void OnCollisionEnter(Collision collision)
    {
        //Playerタグを持つオブジェクトが接触した地点から半径rにかけてObject_Cタグを持つオブジェクトを収縮させる
        //接触した地点から離れるほど収縮の開始時間が遅延する
        if (collision.gameObject.tag == "Player")
        {
            //接触した地点
            Vector3 hitPoint = collision.contacts[0].point;
            //半径
            float r = 2.0f;
            //収縮の開始時間
            float delay = 0.0f;
            //収縮の時間
            float duration = 2.0f;
            //収縮の開始時間を遅延させる
            StartCoroutine("Shrink", new object[] { hitPoint, r, delay, duration });
        }
    }

    //収縮するコルーチン
    IEnumerator Shrink(object[] args)
    {
        //収縮の開始時間
        float delay = (float)args[2];
        //収縮の時間
        float duration = (float)args[3];
        //収縮の開始時間まで待つ
        yield return new WaitForSeconds(delay);
        //収縮の開始時間から収縮の時間まで収縮
        for (float t = 0.0f; t < duration; t += Time.deltaTime)
        {
            //収縮の開始地点
            Vector3 hitPoint = (Vector3)args[0];
            //半径
            float r = (float)args[1];
            //収縮の開始地点から半径rにかけて収縮
            Collider[] colliders = Physics.OverlapSphere(hitPoint, r);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Object_C")
                {
                    //色をPlayerタグのマテリアルの色に変更
                    collider.GetComponent<Renderer>().material.color = Color.Lerp(collider.GetComponent<Renderer>().material.color, Color.white, 0.01f);
                    //収縮
                    collider.transform.localScale = Vector3.Lerp(collider.transform.localScale, Vector3.zero, 0.1f);
                }
            }
            //0.01秒待つ
            yield return new WaitForSeconds(0.01f);
        }
    }
}