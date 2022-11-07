using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;
    //消滅位置
    private float deadLine = -10;
   
    //Audioのコンポーネント
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        //キューブの移動
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //他のオブジェクトと接触した場合
    void OnCollisionEnter2D(Collision2D other)
    {
         if(other.gameObject.tag == "CubePrefabTag" || other.gameObject.tag == "GroundTag")
         {
            GetComponent<AudioSource>().Play();
         }
    }
}
