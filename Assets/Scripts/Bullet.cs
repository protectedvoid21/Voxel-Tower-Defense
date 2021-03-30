using UnityEngine;

public class Bullet : MonoBehaviour {
    private int damage;
    private float speed;

    private Transform target;
    private Vector3 direction;

    public void SetProperties(int damage, float speed) {
        this.damage = damage;
        this.speed = speed;
    }

    public void SeekTarget(Transform target, Quaternion rotation) {
        this.target = target;
        direction = target.position - transform.position;
        transform.rotation = rotation;
    }

    private void Update() {
        if(target == null) {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) < 0.5f) {
            target.GetComponent<Enemy>().GetDamage(damage);
            Destroy(gameObject);
        }
    }
}
