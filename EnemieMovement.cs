using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMovement : MonoBehaviour {

    private Animator myAnim;
    private Transform target;

    public Transform homePos;

    public float waitTime;
    private float startWaitTime;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Transform moveSpot;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxRange;

    [SerializeField]
    private float minRange;

    public bool isPatrolling;
    public bool isAttacking;

    private void Start(){
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        isPatrolling = true;
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update(){
        if(Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange){
            FollowPlayer();
            isPatrolling = false;
        }else if (Vector3.Distance(target.position, transform.position) >= maxRange){
            isPatrolling = true;
        }

        if (Vector3.Distance(target.position, transform.position) <= minRange){
            isAttacking = true;
        }else{
            isAttacking = false;
        }

        if (isPatrolling){
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f){
                if (waitTime <= 0){
                    moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    waitTime = startWaitTime;
                }else{
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    public void FollowPlayer(){
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoHome() {
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
        myAnim.SetFloat("moveX", (homePos.position.x - transform.position.x));

        if (Vector3.Distance(transform.position, homePos.position) == 0){
            myAnim.SetBool("isMoving", false);
        }
    }
}
