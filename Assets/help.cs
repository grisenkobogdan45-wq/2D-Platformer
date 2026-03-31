using UnityEngine;

public class help : MonoBehaviour
{
    public float Max_Health = 100;
    private float Health;
    private bool Can_DMG = true;
    public float InvincibilityTimer = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = Max_Health;
    }

    // Update is called once per frame
    public void AddDamage(float damage)
    {
        Health -= damage;
        Debug.Log(damage);
    }
}
