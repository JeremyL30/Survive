using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageController : MonoBehaviour
{
    [SerializeField]
    private Image HealthBar;
    public float Health = 100f;
    [SerializeField]
    float damage;
    [SerializeField]
    GameObject Enemy;

    void OnTriggerEnter(Collider other)
    {    
    HealthBar.fillAmount -= damage / Health;
        takeDamage();
    if (HealthBar.fillAmount <= 5.0f) Death();

    }
    public void Death()
    {
        Animator anim = Enemy.GetComponent<Animator>();
        anim.SetTrigger("Death");
    }
    public void takeDamage()
    {
        Animator anim = Enemy.GetComponent<Animator>();
        anim.SetTrigger("takeDamage");
    }
    }
