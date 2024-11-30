using UnityEngine;

public class GiftBox : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 direction = transform.position - target.position;

        if(direction.sqrMagnitude > 0.5f) {
            transform.Translate(new Vector3(direction.normalized.x, direction.normalized.y, 0 ) * Time.deltaTime, Space.World);
        }
    }
}
