using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    public GameObject sword;
    public bool CanAttack = true;
    public bool CanBlock = true;
    public float BlockCooldown = 2.0f;
    public float AttackCooldown = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                SwordAttack();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (CanBlock)
            {
                Block();
            }
        }
    }
    public void Clash()
    {
            CanAttack = false;
            Animator anim = sword.GetComponent<Animator>();
            anim.SetTrigger("Clash");
            StartCoroutine(ResetAttackCooldown());   
    }

    public void SwordAttack()
    {
        CanAttack = false;
       // if () { Clash(); }
            Animator anim = sword.GetComponent<Animator>();
            anim.SetTrigger("Attack");
            StartCoroutine(ResetAttackCooldown());
        
    }

    public void Block()
    {
        CanAttack = false;
        Animator anim = sword.GetComponent<Animator>();
        anim.SetTrigger("Block");
        StartCoroutine(ResetBlockCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetBlockCooldown()
    {
        yield return new WaitForSeconds(BlockCooldown);
        CanBlock = true;
    }
}
