using Unity.VisualScripting;
using UnityEngine;

public class traps : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") {
            collision.GetComponent<Health>().takeDamage(damage);
        }
    }
}
