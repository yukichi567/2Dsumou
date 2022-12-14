using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    //�ړ����x
    [SerializeField] public float Speed = 0f;
    GameObject PlayerObject;
    Vector2 PlayeyPosition;
    Vector2 EnemyPosotion;
    /// <summary>���������̓��͒l</summary>
    float h;
    float scaleX;
    /// <summary>���͂ɉ����č��E�𔽓]�����邩�ǂ����̃t���O</summary>
    [SerializeField] bool m_flipX = false;
    [SerializeField] int _hp = 5;

    bool isVisible = false;

    void Start()
    {
        PlayerObject = GameObject.FindWithTag("Player");
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;

        if (PlayeyPosition.x > EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x + Speed;
        }
        else if (PlayeyPosition.x < EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x + Speed;
        }

        transform.position = EnemyPosotion;
    }
}
