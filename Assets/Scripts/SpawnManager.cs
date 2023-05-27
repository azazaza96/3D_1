using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //privateは省略している
    [SerializeField] GameObject obstaclePrefab;//障害物プレハブ
    Vector3 spawnPos = new Vector3(25,0,0);//スポーンする場所
    float elapsedTime;//経過時間
    PlayerController playerControllerScript;
    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //プレイヤーからスクリプトを奪ってくる(イメージ）
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;//毎Fの時間を足していく
        //経過時間が2秒を超えて、かつ、ゲームオーバーではない
        if(elapsedTime > 2.0f && !playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            elapsedTime = 0.0f;//経過時間リセット
        }
    }
}
