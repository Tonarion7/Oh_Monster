using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_eyesight : MonoBehaviour
{
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
        if (other.CompareTag("player") && slime.isDie == false)
        {
            //slime.HP_Bar.SetActive(true);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player") && slime.isDie == false && GameManager.instance.isGameOver == false)
        {
           
            slime.target_contect();
        }

        
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player")) {
            slime.HP_Bar.SetActive(false); 
        }
    }
}
