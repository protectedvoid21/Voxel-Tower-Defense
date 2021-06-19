using UnityEngine;

namespace DefenseGame.Menu {
    public class CameraSelect : MonoBehaviour {
        [SerializeField] private float MoveSpeed;
        [SerializeField] private float scrollSpeed;
        [SerializeField] private float xMinClampRange;
        [SerializeField] private float xMaxClampRange;
        private float moveSpeed;

        private float zoom;
        private Vector3 lastPosition;
        Vector3 speedVector = Vector3.zero;
        
        public KeyCode fasterMove;

        private void Update() {
            moveSpeed = MoveSpeed;
            if(Input.GetKey(fasterMove)) {
                moveSpeed *= 1.5f;
            }

            float xMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float zMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

            float yMove = -Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * 100 * Time.deltaTime;

            Vector3 desiredPosition = new Vector3(transform.position.x + -zMove - xMove + yMove * scrollSpeed, transform.position.y, transform.position.z);
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, xMinClampRange, xMaxClampRange);
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref speedVector, 4 * Time.deltaTime);
        }
    }
}
