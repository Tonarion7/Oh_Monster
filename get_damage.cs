using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_damage : MonoBehaviour
{
    public int player_hp = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        //if (other.CompareTag("monster_attack"))
        if (other.tag == "monster_attack")
        {
            player_hp -= 10;
            Debug.Log("player" + player_hp);
            //Debug.Log("ENTER");
            //if (player_hp <= 0)
            //{
            //    animatorPlayer.SetTrigger("player_die");
            //    speed = 0;
            //}
        }
    }
}
