using UnityEngine;

public class Goblin : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Vector3 direction = transform.position - target.position;

            if(direction.sqrMagnitude > 0.5f) {
                transform.Translate(new Vector3(direction.normalized.x, direction.normalized.y, 0 ) * Time.deltaTime, Space.World);
            }
        }
    }
}
