using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple_Ver2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Object_C")
            {
                //Object_Cの色をPlayerタグのマテリアルの色に変更
                other.gameObject.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
                //時間をかけて半径rも同じ色に変更
                StartCoroutine("ChangeColor");
                //触れた対象を収縮
                StartCoroutine("ScaleDown", other.gameObject);
                //触れた対象のコライダーを削除
                Destroy(other.gameObject.GetComponent<BoxCollider>());
            }
        }

        //サイズを0.1秒ごとに小さく
        IEnumerator ScaleDown(GameObject obj)
        {
            for (int i = 0; i < 10; i++)
            {
                obj.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                if (obj.transform.localScale.x <= 0.1f)
                {
                    Destroy(obj);
                }
                yield return new WaitForSeconds(0.05f);
            }
        }

        //色を変更するコルーチン
        IEnumerator ChangeColor()
        {
            float r = 4f;
            //放射状に色を変更
            for (int i = 0; i < r; i++)
            {
                //色を段階的に変更
                Collider[] colliders = Physics.OverlapSphere(transform.position, i);
                foreach (Collider collider in colliders)
                {
                    if (collider.tag == "Object_C")
                    {
                        //色をPlayerタグのマテリアルの色に変更
                        collider.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;

                        //サイズを0.1秒ごとに小さく
                        StartCoroutine("ScaleDown2" , collider.gameObject);
                        //コライダーを削除
                        Destroy(collider.GetComponent<BoxCollider>());

                    }
                }
                //0.01秒待つ
                yield return new WaitForSeconds(0.1f);
            }
        }

        //サイズを0.1秒ごとに小さく
        IEnumerator ScaleDown2(GameObject obj)
        {
            for (int i = 0; i < 10; i++)
            {
                obj.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                if (obj.transform.localScale.x <= 0.1f)
                {
                    Destroy(obj);
                }
                yield return new WaitForSeconds(0.05f);
            }
        }

}
