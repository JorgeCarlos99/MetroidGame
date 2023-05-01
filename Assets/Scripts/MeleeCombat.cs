using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{

    [SerializeField] private Transform attackRange;
    [SerializeField] private float radiusAttack;
    [SerializeField] private float attackDmg;
    [SerializeField] private float timebetweenAttacks;
    [SerializeField] private float timeNextAttack;

    // Update is called once per frame
    void Update()
    {
        if (timeNextAttack > 0)
        {
            timeNextAttack -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && timeNextAttack <= 0)
        {
            Golpe();
            timeNextAttack = timebetweenAttacks;
        }
    }

    private void Golpe()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(attackRange.position, radiusAttack);
        foreach (Collider2D collider in objects)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.transform.GetComponent<Enemy>().TakeDmg(attackDmg);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (attackRange == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackRange.position, radiusAttack);
    }
}
