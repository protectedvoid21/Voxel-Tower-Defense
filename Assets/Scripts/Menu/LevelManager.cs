using UnityEngine;

namespace DefenseGame.Menu {
    public class LevelManager : MonoBehaviour {
        [SerializeField] private Material blockedLevelMaterial;
        [SerializeField] private LevelPicker[] levelList;

        private void Awake() {
            int unlockedLevel = PlayerPrefs.GetInt("unlockedLevel", 1);
            
            for(int i = unlockedLevel; i < levelList.Length; i++) {
                levelList[i].gameObject.GetComponent<MeshRenderer>().material = blockedLevelMaterial;
                levelList[i].LockMouseHover();
            }
        }
    }
}
