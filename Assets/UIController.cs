using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    
        //ゲームオーバテキスト
        private GameObject gameOverText;
        //走行距離テキスト
        private GameObject runLengthText;
        //走った距離
        private float len = 0;
        //走る速度
        private float speed = 5f;
        //ゲームオーバの判定
        private bool isGameOver = false;        
    


    // Start is called before the first frame update
    void Start()
    {
        //シーンビューからオブジェクトの実体を検索
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isGameOver == false)
        {
            //走った距離を更新
            this.len += this.speed * Time.deltaTime;

            //走った距離を表示
            this.runLengthText.GetComponent<Text> ().text = "Distance: " + len.ToString("F2") + "m";
        }

        //ゲームオーバになった場合
        if(this.isGameOver == true)
        {
            //クリックされたらシーンをロード
            if(Input.GetMouseButtonDown(0))
            {
                //SampleSceneの読み込み
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void GameOver()
    {
        //ゲームオーバになったとき、画面上にゲームオーバを表示
        this.gameOverText.GetComponent<Text> ().text = "Game Over";
        this.isGameOver = true;
    }
}
