using UnityEngine;

public class DamageFieldPowerup : MonoBehaviour
{
    [SerializeField] private float duration = 10.0f;
    [SerializeField] private GameObject damageField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This checks to see if the object entering the trigger is the player, and if so attaches a damage field to them and sets it to be destroyed after a certain amount of time
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject newField = Instantiate(damageField, other.transform);
            Destroy(newField, duration);
            Destroy(gameObject);
        }
    }
}
