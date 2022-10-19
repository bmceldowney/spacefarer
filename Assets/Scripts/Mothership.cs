using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : MonoBehaviour
{
    [SerializeField]
    MothershipHealth _health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Something has collided {other}");
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            DoDamage();
        }
    }

    public void DoDamage()
    {
        var currentHealth = _health.GetScore();
        currentHealth--;
        _health.SetScore(currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("The mothership is lost!");
        }
    }
}
