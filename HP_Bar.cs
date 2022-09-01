using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public GameObject HP_Object;
    Slider heart;
    public void Start()
    {
        heart = GetComponent<Slider>();
    }
    public void Update()
    {
        FillSlider();
    }
    public void FillSlider()
    {
        int HP = HP_Object.GetComponent<slime>().hp;
        heart.value = HP;
        
    }
}
