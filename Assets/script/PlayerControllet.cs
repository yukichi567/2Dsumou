using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllet : MonoBehaviour
{
    Rigidbody2D rb;
    //移動速度
    [SerializeField]public float Speed = 0f;
    //左右入力変数ｈ
    float h;
    //ジャンプ力
    [SerializeField]public float Jumpforce = 0f;
    //ジャンプ、接地条件
    public bool OnGround;
    public bool jump;

    //攻撃条件、攻撃力
    public bool AttackSwitch = false;
    [SerializeField] public float Power = 0f;

    //体力
    [SerializeField] public float Life = 3f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 入力を受け取る
        h = Input.GetAxis("Horizontal");

        // 各種入力を受け取る
        if (Input.GetKey(KeyCode.Space) && OnGround == true)jump = true;        
        if (Input.GetKeyDown(KeyCode.RightShift))AttackSwitch = true;      
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * h * Speed, ForceMode2D.Force);

        if(jump)
        {
            this.rb.AddForce(transform.up * Jumpforce);
            jump = false;
            OnGround = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;            
        }
        
    }
}
