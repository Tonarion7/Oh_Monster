using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public GameObject target_Object;
    hero hero1;
    GameManager GameManager;
    Rigidbody rid;
    Animator animatorPlayer;
    public int hp;
    public float speed = 0.1f;
    public bool isDie = false;
    CapsuleCollider capsuleCollider;
    public GameObject HP_Bar;
    public bool monster_attack_check = false;


 

    // Start is called before the first frame update
    void Start()
    {
        hero1 = FindObjectOfType<hero>();
        rid = GetComponent<Rigidbody>();
        animatorPlayer = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        GameManager = GetComponent<GameManager>();
    }
    void Update()
    {
        
    }
    //공격 받음 & 죽음
    public void OnHit()
    {
        animatorPlayer.SetTrigger("gethit");
        if (hp <= 0)
        {
            isDie = true;
            HP_Bar.SetActive(false);
            speed = 0;
            capsuleCollider.enabled = false;
            rid.useGravity = false;
            animatorPlayer.SetTrigger("die");
            StartCoroutine("deadmotion");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        animatorPlayer.SetBool("idle", true);
    }

    IEnumerator deadmotion()
    {
        var childParticle = transform.GetComponentInChildren<ParticleSystem>(true);
        childParticle.transform.parent = null;
        yield return new WaitForSeconds(1.5f);
        childParticle.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    public void target_contect()
    {
        //회전
        Vector3 v = target_Object.transform.position - transform.position;
        v.x = v.z = 0;
        transform.LookAt(target_Object.transform.position - v);
        //움직이기
        var target_dirction = target_Object.transform.position - transform.position;
        if (Vector3.Distance(target_Object.transform.position, transform.position) > 1.5f)
        {
            rid.MovePosition(transform.position + target_dirction.normalized * speed);
            animatorPlayer.SetInteger("walk", 1);
            animatorPlayer.SetBool("idle", false);
        }
        else
        {
            animatorPlayer.SetInteger("walk", 0);
            animatorPlayer.SetTrigger("attack");
        }
    }
}
