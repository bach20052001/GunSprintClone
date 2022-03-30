using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 2.5f;
        StartCoroutine(Inactive());
    }

    IEnumerator Inactive()
    {
        yield return new WaitForSeconds(lifeTime);

        if (this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            this.PostEvent(GameEvent.OnBulletCollideEnemy);
            collision.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

        if (collision.collider.CompareTag("Award"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
