using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour{

    public Animator animator;

    public int maxHelth = 100;
    int currentHealth;

    public GameObject floatingPoints;

    private void Start(){
        currentHealth = maxHelth;
        this.gameObject.SetActive(true);
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;

        GameObject points = Instantiate(floatingPoints, transform.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();

        animator.SetTrigger("IsHit");

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        animator.SetTrigger("Died");
        this.gameObject.SetActive(false);
    }
}
