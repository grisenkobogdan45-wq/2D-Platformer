using System;
using System.Collections;
using UnityEngine;

public class help : MonoBehaviour
{
    public float Max_Health = 3;
    private float Health;
    private bool Can_DMG = true;
    public float InvincibilityTimer = 2;
    public delegate void HealthChangedHandler(float newhave, float pushorigin);
    public event HealthChangedHandler OnHealthChanged;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = Max_Health;
    }

    // Update is called once per frame
    public void AddDamage(float damage)
    {
        if (Can_DMG)
        {
            Health -= damage;
            OnHealthChanged?.Invoke(Health, -damage);
            Can_DMG = false;
            StartCoroutine(InvincibilityTime(InvincibilityTimer, ResetInvincibility));
        }
        Debug.Log(damage);
    }

    IEnumerator InvincibilityTime(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }
    private void ResetInvincibility()
    {
        Can_DMG = true;
    }
    public void AddHealth(float heal)
    {
        Health += heal;
        OnHealthChanged.Invoke(Health, heal);
        Debug.Log(Health);
    }
}
