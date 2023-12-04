using UnityEngine;

public class SecondPattern : MonoBehaviour
{
    public int bulletAmount = 20;
    public float bulletForce = 4f;

    public float startAngle = 0f;
    public float endAngle = 360;

    public float fireRate = 0.1f;
    public float deltaAngle = 2f;
    public float startTime;

    public void Start()
    {
        startTime = Time.time;
        InvokeRepeating("Fire", 0f, fireRate);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle + (Time.time-startTime)%(360/fireRate)*deltaAngle;

        for (int i = 0; i < bulletAmount; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bullet = BulletManager.instance.CreateBullet("bullet");
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            bullet.GetComponent<Rigidbody2D>().velocity = bulDir * bulletForce;

            angle += angleStep;
        }
    }
}