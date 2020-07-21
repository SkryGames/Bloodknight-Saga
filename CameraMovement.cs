using UnityEngine;

public class CameraMovement : MonoBehaviour{

    public Transform target;
    public Transform target2;
    public float smoothing;

    public bool onCharacter;

    private void Start(){
        onCharacter = true;
    }

    private void Update(){
        if (Input.GetKeyDown("e")){
            if (onCharacter){
                onCharacter = false;
            }else{
                onCharacter = true;
            }
        }
    }

    private void FixedUpdate(){
        if (onCharacter){
            smoothing = 0.1f;
            if (transform.position != target.position){
                Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            }
        }else{
            smoothing = 0.5f;
            if (transform.position != target2.position){
                Vector3 target2Position = new Vector3(target2.position.x, target2.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, target2Position, smoothing);
            }
        }
    }
}
