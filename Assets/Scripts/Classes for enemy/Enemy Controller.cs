using UnityEngine;
using System.Collections;


public class EnemyController : MonoBehaviour
{
    // this class will be responsible for instantiating the enemy and managing their amount


    [SerializeField] private GameObject bearMadMan;
    public Transform[] spawnPoints;

    private void Start()
    {
        if (bearMadMan == null)
        {
            Debug.Log("You are missing a prefab in EnemyController");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(BearSpawner());
        }
    }


     private IEnumerator BearSpawner()
    {
        Debug.Log("Spawning bears");
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(bearMadMan, spawnPoints[i].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            if (i == spawnPoints.Length - 1)
            {
                Debug.Log("All bears spawned");
                i = 0;
                yield break;
            }
        }
    }
 
    
}
