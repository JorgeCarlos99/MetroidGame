using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float life;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDmg(float dmg)
    {
        life -= dmg;

        if (life <= 0)
        {
            Died();
        }
    }

    private void Died()
    {
        Debug.Log("Se murio");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
