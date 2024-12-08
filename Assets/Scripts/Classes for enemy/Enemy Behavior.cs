using System.Collections;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform targetToBash;
    private bool moving = false;
    private float speed = 3f;
    private float strikeDistance = 2f;
    private float damage = 10f;
    private PlayerStats playerStats;
    private float currentHealth = 40f; // Example health value

    void Awake()
    {
        gameObject.tag = "Enemy";
        transform.localScale = new Vector3(0, 0, 0);

        StartCoroutine(SpawnSequence());
        animator.SetTrigger("Moving");

        playerStats = targetToBash.GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (moving)
        {
            // Rotate to face the player
            transform.LookAt(targetToBash);

            // Ensure the Z rotation axis is always 0
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

            transform.position = Vector3.MoveTowards(transform.position, targetToBash.position, speed * Time.deltaTime);

            // Check the distance between the enemy and the player
            if (Vector3.Distance(transform.position, targetToBash.position) < strikeDistance)
            {
                StartCoroutine(Strike());
            }
        }
    }

    private IEnumerator Strike()
    {
        moving = false;
        animator.SetTrigger("Strike");

        // Check if the player is still within strike distance and apply damage
        if (Vector3.Distance(transform.position, targetToBash.position) < strikeDistance)
        {
            playerStats.currentHealth -= damage;
        }

        yield return new WaitForSeconds(1.5f);
        moving = true;
        animator.SetTrigger("Moving");
    }

    public IEnumerator SpawnSequence()
    {
        animator.SetTrigger("Idle");
        while (transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            yield return new WaitForSeconds(0.05f);
        }
        animator.SetTrigger("Moving");
        moving = true;

        yield break;
    }

    public IEnumerator TakeDamage(float damage)
    {
        moving = false;
        animator.SetTrigger("Hurt");
        currentHealth -= damage;
        Debug.Log("Enemy took " + damage + " damage. Current health: " + currentHealth);
                
        if (currentHealth <= 0)
        {
            yield return StartCoroutine(Die());
        }
        speed -= 0.5f;
        moving = true;
        animator.SetTrigger("Moving");
        
    }

    private IEnumerator Die()
    {
        Debug.Log("Enemy died");
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
