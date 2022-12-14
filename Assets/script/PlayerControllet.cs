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

    //���͂ɉ����č��E�𔽓]�����邩�ǂ����̃t���O
    bool flipX = true;
    float m_scaleX;
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

        if (flipX)
        {
            FlipX(h);
        }
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
    void FlipX(float horizontal)
    {
        /*
         * ������͂��ꂽ��L�����N�^�[�����Ɍ�����B
         * ���E�𔽓]������ɂ́ATransform:Scale:X �� -1 ���|����B
         * Sprite Renderer �� Flip:X �𑀍삵�Ă����]����B
         * */
        m_scaleX = this.transform.localScale.x;

        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
}
