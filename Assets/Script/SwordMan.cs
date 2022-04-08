using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class SwordMan : MonoBehaviour
{
    Animator animator;

    public int maxHP;
    public int nowHP;
    public int atkDmg;
    public float atkSpeed = 1;
    public bool attacked = false;
    public Image nowHpbar;
    public int Speed = 5;
    BoxCollider2D col2D;
    Rigidbody2D rigid2D;
    public float jumpPower = 0.1f;
 


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        maxHP = 50;
        nowHP = 50;
        atkDmg = 10;

        transform.position = new Vector3(0, 0, 0);
        SetAttackSpeed(1.5f);
        col2D = GetComponent<BoxCollider2D>();
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        nowHpbar.fillAmount = (float)nowHP / (float)maxHP;
        move();
        attack();
        jump();
    }

    void move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("move", true);
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("move", true);
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        else animator.SetBool("move", false);
    }

    void attack()
    {
        if (Input.GetKeyDown(KeyCode.A) &&
                 !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("attack");

        }
    }
    void AttackTrue() // 공격 BOOL ONOFF 처리문
    {
        attacked = true;
    }

    void AttackFalse()
    {
        attacked = false;
    }
    void SetAttackSpeed(float speed)
    {
        animator.SetFloat("attackSpeed", speed);
        atkSpeed = speed;
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !animator.GetBool("jumping"))
        {
            rigid2D.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            animator.SetBool("jumping", true);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            animator.SetBool("jumping", false);
        }
    }
}

/*void Raycast() //레이캐스트로 땅과 충돌 체크
{
    RaycastHit2D raycastHit = Physics2D.BoxCast(col2D.bounds.center,
        col2D.bounds.size,
        0f,
        Vector2.down,
        0.02f,
        LayerMask.GetMask("Ground"));

    if (raycastHit.collider != null)
        animator.SetBool("jumping", false);

    else
        animator.SetBool("jumping", true);
}
*/


