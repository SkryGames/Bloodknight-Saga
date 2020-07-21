using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour{

    public float playerSpeed;
    private Rigidbody2D playerRigidbody;
    private Vector3 change;
    private Animator playerAnimator;

    public bool facingLeft = false;
    public bool facingRight = true;

    private void Start(){
        Reset();
    }

    public void Reset(){
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update(){

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 4f;
        }else{
            playerSpeed = 2.5f;
        }

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero){
            MoveCharacter();
        }

        if (Input.GetKeyDown("a")){
            playerAnimator.SetTrigger("Left");
            playerAnimator.ResetTrigger("Right");
            facingLeft = true;
            facingRight = false;
        } else if (Input.GetKeyDown("d")) { 
            playerAnimator.SetTrigger("Right");
            playerAnimator.ResetTrigger("Left");
            facingLeft = false;
            facingRight = true;
        }

        if (Input.GetKeyDown("space")){
            playerAnimator.SetTrigger("isSwinging");
        }
    }

    void MoveCharacter(){
        playerRigidbody.MovePosition(transform.position + change * playerSpeed * Time.deltaTime);
    }
}