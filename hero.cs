using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    public float speed;
    float saved_speed;
    public float jump;
    Rigidbody rid;
    Animator animatorPlayer;//자료형 변수이름.
    slime slime;
    GameManager GameManager;
    bool is_jump = false;
    float mouseX = 0;
    int attack_count = 0;
    public bool isAttack = true;
    public int player_hp = 100;

    // Start is called before the first frame update
    void Start()
    {
        saved_speed = speed;
        slime = FindObjectOfType<slime>();
        rid = GetComponent<Rigidbody>(); //Rigidbody 정의
        animatorPlayer = GetComponent<Animator>();
        GameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        
        if (GameManager.instance.isGameOver == false)
        {
            playerMove();
            mouseX += Input.GetAxis("Mouse X") * speed;
            transform.eulerAngles = new Vector3(0, mouseX, 0); //플레이어 회전값 조정
            playerJump();
            playerAttack();
        }
    }

    void playerMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        if (moveZ != 0 || moveX != 0)
        {
            animatorPlayer.SetInteger("walk", 1);
        }
        else
            animatorPlayer.SetInteger("walk", 0);
        transform.Translate(new Vector3(moveX * Time.deltaTime * speed, 0, moveZ * Time.deltaTime * speed));
    }

    public void playerJump()
    {
        if (is_jump != true && Input.GetKeyDown(KeyCode.Space))
        {
            is_jump = true;
            rid.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.collider.CompareTag("ground"))
        {
            is_jump = false;
        }
    }
    //공격
    public void playerAttack()
    {
        if (Input.GetMouseButtonDown(0) && attack_count % 3 < 2 && isAttack && is_jump == false)
        {
            isAttack = false;
            animatorPlayer.SetTrigger("attack_1");
            attack_count++;
            StartCoroutine(attackDelay1());
        }
        else if (Input.GetMouseButtonDown(0) && attack_count % 3 == 2 && isAttack && is_jump == false)
        {
            isAttack = false;
            animatorPlayer.SetTrigger("attack_2");
            attack_count++;
            StartCoroutine(attackDelay2());
        }
    }
    IEnumerator attackDelay1()
    {
        speed = speed/10f;
        yield return new WaitForSeconds(0.6f);
        speed = saved_speed;
        isAttack = true;
    }
    IEnumerator attackDelay2()
    {
        speed = speed / 10f;
        yield return new WaitForSeconds(1.2f);
        speed = saved_speed;
        isAttack = true;
    }
    //공격 받음 & 죽음
    public void OnTriggerEnter(Collider other)
    {
        //플레이어 죽음
        if (player_hp <= 0)
        {
            GameManager.instance.isGameOver = true;
            
            animatorPlayer.SetTrigger("player_die");
            speed = 0;
        }
    }
}
