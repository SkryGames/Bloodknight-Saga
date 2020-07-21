using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour{

    public float droneSpeed;
    private Vector3 cameraFollowPosition;
    private Rigidbody2D droneRigidbody;

    public bool isDrone;
    public bool isFrozen;

    public Transform player;

    public float zoomSpeed = 1;
    public float targetOrtho;
    public float smoothSpeed = 10.0f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 20.0f;

    private void Start(){
        targetOrtho = Camera.main.orthographicSize;
        droneRigidbody = GetComponent<Rigidbody2D>();
        isDrone = false;
    }

    private void Update()
    {
        if (!isDrone){
            isFrozen = false;
            targetOrtho = 3;
            transform.position = player.position;
        }else{
            if (!isFrozen){
                Time.timeScale = 1;
            }else{
                Time.timeScale = 0.5f;
            }
        }

        if (isDrone){
            if (Input.GetMouseButtonDown(0)){
                droneSpeed += 1;
            }else if (Input.GetMouseButtonDown(1)){
                droneSpeed -= 1;
            }

            if (droneSpeed < 1){
                droneSpeed = 1;
            } else if (droneSpeed > 30){
                droneSpeed = 30;
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f && (isDrone)){
            targetOrtho -= scroll * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }

        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);

        cameraFollowPosition = Vector3.zero;
        cameraFollowPosition.x = Input.GetAxisRaw("Horizontal2");
        cameraFollowPosition.y = Input.GetAxisRaw("Vertical2");
        if (cameraFollowPosition != Vector3.zero){
            MoveDrone();
        }

        if (Input.GetKeyDown("e")) {
            if (isDrone){
                isDrone = false;
            }else{
                droneSpeed = 8;
                isDrone = true;
            }
        }

        if (Input.GetKeyDown("f")){
            if (isFrozen){
                isFrozen = false;
            }
            else{
                isFrozen = true;
            }
        }
    }

    void MoveDrone()
    {
        droneRigidbody.MovePosition(transform.position + cameraFollowPosition * droneSpeed * Time.deltaTime);
    }
}
