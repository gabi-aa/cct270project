using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 10f;
    public Exit exit;

    public void TakeDamage(float damage)
    {
        health -= damage;
        //
        if(health <= 0)
        {
            Destroy(gameObject);
            exit.locked = false;
            Debug.Log("door open");
            
 //            gameObject.SetActive(false);
        }
    }
}
