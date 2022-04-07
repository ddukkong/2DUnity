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
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        maxHP = 50;
        nowHP = 50;
        atkDmg = 10;

        transform.position = new Vector3(0,0,0);
        SetAttackSpeed(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        nowHpbar.fillAmount = (float) nowHP / (float)maxHP;
        move();
        attack();

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
    void AttackTrue()
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
 }