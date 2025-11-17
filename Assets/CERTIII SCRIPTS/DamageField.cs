using System.Collections.Generic;
using UnityEngine;

public class DamageField : MonoBehaviour
{
    [SerializeField] private float damageTime = 1.0f;
    private List<GameObject> enemiesInField = new List<GameObject>();
    private List<float> enemyTimers = new List<float>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    // Increments each timer for each enemy and if the timer exceed the damage time threshold, damages the enemy and resets their timer
    void Update()
    {
        for (int i = 0; i < enemiesInField.Count; i++)
        {
            enemyTimers[i] += Time.deltaTime;
            if (enemyTimers[i] >= damageTime)
            {
                Debug.Log("Enemy damaged by damage field: " + enemiesInField[i].name);
                enemiesInField[i].GetComponent<Enemy>().GetShot();
                enemyTimers[i] = 0;
            }
        }
    }

    // This checks if the object entering the trigger is an enemy not already in the list of enemies in the damage field, and if so adds them and a new timer to the respective lists
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !enemiesInField.Contains(other.gameObject) && other.GetComponent<Enemy>() != null)
        {
            enemiesInField.Add(other.gameObject);
            enemyTimers.Add(0.0f);
        }
    }

    // This checks if the object leaving the trigger is in the list of enemies in the damage field, and if so removes them and their timer from the respective lists
    private void OnTriggerExit(Collider other)
    {
        if (enemiesInField.Contains(other.gameObject))
        {
            int index = enemiesInField.IndexOf(other.gameObject);
            enemiesInField.RemoveAt(index);
            enemyTimers.RemoveAt(index);
        }
    }
}
