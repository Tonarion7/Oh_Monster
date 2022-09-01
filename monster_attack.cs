using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_attack : MonoBehaviour
{
    hero hero;
    slime slime;
    // Start is called before the first frame update
    void Start()
    {
        slime = GetComponentInParent<slime>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player" && slime.isDie == false)
        {
            hero = other.GetComponent<hero>();
            hero.player_hp -= 10;
            Debug.Log("player" + hero.player_hp);
        }
    }
}
