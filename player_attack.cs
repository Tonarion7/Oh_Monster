using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    slime slime;
    hero hero;

    // Start is called before the first frame update
    void Start()
    {
        hero = GetComponentInParent<hero>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        //플레이어 공격
        if (other.CompareTag("monster"))
        {
            slime = other.gameObject.GetComponent<slime>();
            slime.hp -= 10;
            slime.OnHit();
            Debug.Log("monster" + slime.hp);
        }
    }
}
