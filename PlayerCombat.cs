using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour{

    public LayerMask enemyLayers;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int maxDamage;
    public int minDamage;
    public int attackDamage;

    public int maxHealth;
    public int currentHealth;

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }

        GetComponent<ProgresBar>().UpdateHealth(currentHealth);
    }

    public void Attack() {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies){
            attackDamage = Random.Range(maxDamage, minDamage);
            enemy.GetComponent<Enemie>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected(){

        if (attackPoint == null){
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
