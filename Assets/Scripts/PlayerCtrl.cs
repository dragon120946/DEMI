using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public int moveX;
    public int moveZ;
    public Animator animator;
    public S1Mgr s1;

    private Rigidbody rb;
    private int runX;
    private int runZ;
    private bool isRun = false;
    private bool isJump = false;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        #region 移動 
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-moveX, rb.velocity.y, rb.velocity.z);
            animator.SetBool("LWalking",true);
        }
        else
        {
            animator.SetBool("LWalking",false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(moveX, rb.velocity.y, rb.velocity.z);
            animator.SetBool("RWalking", true);
        }
        else
        {
            animator.SetBool("RWalking", false); 
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveZ);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -moveZ);
        }
        
        #endregion

        #region 跑步

        runX = moveX * 2;
        runZ = moveZ * 2;
        
        if (isRun && s1.slidStamina.value <= 0.05f) //如果在跑步且用完耐力條，跑步速度變為走路速度的一半
        {
            runX = moveX / 2;
            runZ = moveZ / 2;
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector3(-runX, rb.velocity.y, rb.velocity.z);
                isRun = true;
            } 
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector3(runX, rb.velocity.y, rb.velocity.z);
                isRun = true;
            } 
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, runZ);
                isRun = true;
            } 
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -runZ);
                isRun = true;
            }
            if (isRun) //如果在跑步，每秒就減0.3耐力
            {
                s1.slidStamina.value -= 0.3f * Time.deltaTime;
            }
        }
        else
        {
            isRun = false;
        }
        
        #endregion

        #region 跳躍

        if (Input.GetKeyDown(KeyCode.Space) && s1.slidStamina.value >= 0.33f)
        {
            if (isJump)
            {
                return;
            }
            s1.slidStamina.value -= 0.33f;
            rb.velocity = new Vector3(rb.velocity.x, 10, rb.velocity.z);
            isJump = true;
        }

        #endregion

        #region 閃避

        //如果耐力值大於0.33並按Alt才可閃避
        if(Input.GetKeyDown(KeyCode.LeftAlt) && s1.slidStamina.value >= 0.33f)
        {
            s1.slidStamina.value -= 0.33f;
        }

        #endregion
       
    }

    void OnCollisionEnter(Collision col)    
    {
        if (col.gameObject.CompareTag("Enemy")) //碰到敵人就扣10點血
        {
            s1.slidHP.value-= 10;
        }

        if (col.gameObject.CompareTag("Ground"))    //在地上才可跳躍
        {
            isJump = false;
        }
    }
}
