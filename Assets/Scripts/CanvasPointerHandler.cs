using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefenseGame {
    public class CanvasPointerHandler : MonoBehaviour {
        public static CanvasPointerHandler instance;

        [SerializeField] private GameObject[] raycastBlockers;

        private void Awake() {
            instance = this;
        }
        
        public bool IsMouseOverUI() {
            return raycastBlockers.Any(blocker => EventSystem.current.IsPointerOverGameObject() == true);
        }
    }
}
