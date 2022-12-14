using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllet : MonoBehaviour
{
    Rigidbody2D rb;
    //�ړ����x
    [SerializeField]public float Speed = 0f;
    //���E���͕ϐ���
    float h;
    //�W�����v��
    [SerializeField]public float Jumpforce = 0f;
    //�W�����v�A�ڒn����
    public bool OnGround;
    public bool jump;

    //�U�������A�U����
    public bool AttackSwitch = false;
    [SerializeField] public float Power = 0f;

    //�̗�
    [SerializeField] public float Life = 3f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���͂��󂯎��
        h = Input.GetAxis("Horizontal");

        // �e����͂��󂯎��
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
