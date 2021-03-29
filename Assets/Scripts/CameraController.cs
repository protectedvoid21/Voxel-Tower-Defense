using UnityEngine;

public class CameraController : MonoBehaviour {
    public float MoveSpeed;
    private float moveSpeed;
    public float scrollSpeed;

    public KeyCode fasterMove;

    private void Update() {
        moveSpeed = MoveSpeed;
        if(Input.GetKey(fasterMove)) {
            moveSpeed *= 1.5f;
        }

        float xMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float zMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        float yMove = -Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * 100 * Time.deltaTime;

        transform.Translate(xMove, yMove, zMove);
    }
}