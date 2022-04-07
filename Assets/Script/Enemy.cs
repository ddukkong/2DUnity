using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public GameObject prfHpBar;
    public GameObject canvas;
    public string enemyName;
    public int maxHP;
    public int nowHP;
    public int atkDmg;
    public int atkSpeed;

    RectTransform hpBar;

    public float height = 1.7f;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();
        if(name.Equals("Enemy"))
        {
            SetEnemyStatus("Enemy", 100, 10, 1);
        }
        nowHPbar = hpBar.transform.GetChild(0).GetComponent<Image>();
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _hpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.position = _hpBarPos;
        nowHPbar.fillAmount = (float)nowHP / (float)maxHP;
        

    }

    private void SetEnemyStatus(string _enemyName, int _maxHP, int _atkDmg, int _atkSpeed)
    {
        enemyName = _enemyName;
        maxHP = _maxHP;
        nowHP = _maxHP;
        atkDmg = _atkDmg;
        atkSpeed = _atkSpeed;
    }

    public SwordMan sword_man;
    Image nowHPbar;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (sword_man.attacked)
            {
                nowHP -= sword_man.atkDmg;
                Debug.Log(nowHP);
                sword_man.attacked = false;
                if (nowHP <= 0) // 적사망
                {
                    Destroy(gameObject);
                    Destroy(hpBar.gameObject);
                }
            }
        }
    }
}
