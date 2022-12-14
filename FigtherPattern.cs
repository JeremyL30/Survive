using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigtherPattern : MonoBehaviour
{
    [SerializeField]
    GameObject Enemy;
    public bool CanAttack = true;
    public bool CanBlock = true;
    public bool CanApproach = true;
    public float BlockCooldown = 2.0f;
    public float AttackCooldown = 1.0f;
    public float ApproachCooldown = 7.0f;
    private void OnTriggerEnter(Collider other)
    {
            if (CanAttack)
            {
                Swing();
            }

            if (!CanAttack && CanBlock)
        {
            Block();
        }
        
            else if (CanBlock)
        {
            Block();
        }
    }

    private void OnTriggerExit(Collider other)
    {
       if (CanApproach)
        {
            Approach();
        }
    }

    void Approach()
    {
        Animator anim = Enemy.GetComponent<Animator>();
        anim.SetTrigger("Approach");
        StartCoroutine(ResetApproachCooldown());
    }
    public void Swing()
    {
        Animator anim = Enemy.GetComponent<Animator>();
        anim.SetTrigger("SwingForPlayer");
        StartCoroutine(ResetAttackCooldown());
    }

    public void Block()
    {
        int choice = Random.Range(1, 4);
        Animator anim = Enemy.GetComponent<Animator>();
        if (choice == 1) anim.SetTrigger("Evade");
        else if (choice == 2) anim.SetTrigger("Evade1");
        else if (choice == 3) anim.SetTrigger("Evade2");
        
        StartCoroutine(ResetBlockCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanApproach = true;
    }   
    IEnumerator ResetApproachCooldown()
    {
        yield return new WaitForSeconds(ApproachCooldown);
        CanAttack = true;
    }

    IEnumerator ResetBlockCooldown()
    {
        yield return new WaitForSeconds(BlockCooldown);
        CanBlock = true;
    }
}
    