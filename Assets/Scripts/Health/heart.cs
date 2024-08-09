using UnityEngine;

public class heart : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") {
            collision.GetComponent<Health>().addHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
