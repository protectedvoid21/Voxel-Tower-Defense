using UnityEngine;

public class CameraController : MonoBehaviour {
    public float MoveSpeed;
    private float moveSpeed;
    public float scrollSpeed;

    private float zoom = 10f;

    public KeyCode fasterMove;

    private void Update() {
        moveSpeed = MoveSpeed;
        if(Input.GetKey(fasterMove)) {
            moveSpeed *= 1.5f;
        }

        float xMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float zMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        float yMove = -Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * 100 * Time.deltaTime;

        zoom += yMove;
        zoom = Mathf.Clamp(zoom, 1, 30);

        Vector3 desiredPosition = new Vector3(transform.position.x + -zMove, zoom, transform.position.z + xMove);
        Vector3 speedVector = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref speedVector, 4 * Time.deltaTime);
    }
}