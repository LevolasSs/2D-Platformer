using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;

    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    
    //references
    private Animator anim;
    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();    
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(playerInSight()) 
        {
            if(cooldownTimer >= attackCooldown) 
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
        }
    }

    private bool playerInSight() 
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center - transform.right * range * transform.localScale.x * colliderDistance
        ,new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z) , 0, Vector2.left, 0, playerLayer);

        if(hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center - transform.right * range * transform.localScale.x * colliderDistance
        , new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void damagePlayer() 
    {
        if(playerInSight()) 
        {
            playerHealth.takeDamage(damage);
        }    
    }
}
