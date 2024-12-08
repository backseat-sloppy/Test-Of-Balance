using UnityEngine;

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
            BearSpawner();
        }
    }

    private void BearSpawner()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(bearMadMan, spawnPoints[i].transform.position, Quaternion.identity);
        }
        BearSpawner();
        
    }
}
