using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefenseGame.Menu {
    public class LevelPicker : MonoBehaviour {
        [SerializeField] private string sceneName;
        private Animator animator;
        private bool isLocked;

        private void Awake() {
            if(sceneName == "") {
                Debug.LogError("Variable sceneName hasn't been set. Scene won't be loaded!");
            }
            animator = GetComponent<Animator>();
        }
    
        private void OnMouseEnter() {
            if(!isLocked) {
                animator.SetBool("hovering", true);
            }
        }

        public void LockMouseHover() {
            isLocked = true;
        }

        private void OnMouseExit() {
            if(!isLocked) {
                animator.SetBool("hovering", false);
            }
        }

        private void OnMouseDown() {
            SceneManager.LoadScene(sceneName);
        }
    }
}