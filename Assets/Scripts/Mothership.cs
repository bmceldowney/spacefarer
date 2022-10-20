using System;
using UnityEngine;

public class Mothership : StatefulBehaviour
{
    [SerializeField]
    MothershipHealth _health;

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
            StatefulBehaviour.ChangeState(GameState.GameOver);
        }
    }

    protected override void HandleStateChange(GameState previous, GameState current)
    {
        // noop
    }
}
