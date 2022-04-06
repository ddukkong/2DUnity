using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMan : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-1,1,1);
            animator.SetBool("move", true);
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(1,1,1);
            animator.SetBool("move", true);
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        else animator.SetBool("move",false);
        



    }
}
