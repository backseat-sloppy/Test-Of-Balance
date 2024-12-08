using System.Collections;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameObject.tag = "Enemy";
        transform.localScale = new Vector3(0, 0, 0);

        StartCoroutine(SpawnSequence());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator SpawnSequence()
    {
        // Afspil spawn animation

        animator.SetTrigger("Idle");
        while (transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    //move Ie

    // attack Ie

    // die Ie


}
