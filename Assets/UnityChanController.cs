using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator animator;
    //Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    //地面の配置
    private float groundLevel = -3.0f;

    //ジャンプ速度の減衰
    private float dump = 0.8f;
    //ジャンプ速度
    float jumpVelocity = 20;

    //ゲームオーバになる位置
    private float deadLine = -9;


    // Start is called before the first frame update
    void Start()
    {
        //アニメータのコンポーネントを取得する
        this.animator = GetComponent<Animator> ();   
        //Rigidbodyの2Dのコンポーネントを取得
        this.rigid2D = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        //走るアニメーションを再生するために、Animatorのパラメータを調節
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ状態のときはボリューム0
        GetComponent<AudioSource> ().volume = (isGround) ? 1 : 0;

        //着地状態でクリック
        if(Input.GetMouseButtonDown (0) && isGround)
        {
            //上方向への力
            this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity);
        }

        //クリックをやめたら上方向への速度を減速する
        if(Input.GetMouseButton (0) == false)
        {
            if(this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //デッドラインを超えた場合ゲームオーバ
        if(transform.position.x < this.deadLine)
        {
            //UIControllerのGameOver関数を呼び出して画面上に「GameOver」を表示
            GameObject.Find("Canvas").GetComponent<UIController> ().GameOver ();

            //ユニティちゃんを破棄
            Destroy(gameObject);
        }
    }
}
