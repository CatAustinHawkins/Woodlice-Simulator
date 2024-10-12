using UnityEngine;

public class Food : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
