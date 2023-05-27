using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;
    private Rigidbody rb;
    [SerializeField] float gravityModifier;//重力値調整用　privateは省略可能
    [SerializeField] float jumpForce;//ジャンプ力
    [SerializeField] bool isOnGround;//地面についているか
    public bool gameOver;//何も書かなければprivate
    Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーが押されて、かつ、地面にいたら
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            //上へ力を加える
            rb.AddForce(Vector3.up * jumpForce ,ForceMode.Impulse);
            isOnGround = false;//ジャンプした=地面にいない
            playerAnim.SetTrigger("Jump_trig");//ジャンプアニメ発動準備
        }
    }
    //衝突が起きたら実行
    private void OnCollisionEnter(Collision collision){
        //ぶつかった相手（collision）のタグがGroundなら
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround  = true;//地面についている状態に変更
        }
        if (collision.gameObject.CompareTag("Obstacle")){
            gameOver = true;//ゲームオーバーにする
            playerAnim.SetBool("Death_b", true);//ここで死亡状態bにする。　(Death_bは本来自分で定義できる）
            playerAnim.SetInteger("DeathType_int", 1);//integerは整数の意味。死亡のタイプを1番目のやつにする的な
        }
    }
}
