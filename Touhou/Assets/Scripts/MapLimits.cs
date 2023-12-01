using UnityEngine;

public class MapLimits : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.transform.tag == "bullet")
        {
            BulletManager.instance.DestroyBullet(collision.gameObject);
        }
    }
}