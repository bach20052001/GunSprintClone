using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Rigidbody rigid;
    [SerializeField] private GameObject bulletReleasePos;
    [SerializeField] private ObjectPooling ob;

    private bool isGround = false;

    // Start is called before the first frame update
    
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        Fall();
    }


    private void Shoot()
    {
        Debug.Log("Shoot");

        if (!isGround)
        {
            rigid.AddForce(this.transform.forward * 125f, ForceMode.Impulse);
            rigid.AddTorque(this.transform.right * 50f, ForceMode.Impulse);
        }
        else
        {
            if (this.transform.up.y > 0)
            {
                rigid.AddForce(this.transform.forward * 125f, ForceMode.Impulse);
                rigid.AddTorque(this.transform.right * 50f, ForceMode.Impulse);
            }
            else
            {
                rigid.AddForce(this.transform.forward * 125f, ForceMode.Impulse);
                rigid.AddTorque(-this.transform.right * 50f, ForceMode.Impulse);
            }
        }
        


        Debug.Log("Bullet Release");

        GameObject bullet = ob.GetUnactiveObject();
        bullet.SetActive(true);
        bullet.transform.position = bulletReleasePos.transform.position;
        bullet.GetComponent<Rigidbody>().velocity = bulletReleasePos.transform.forward * 20f;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = true;
            Debug.Log("On Ground");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = false;
            Debug.Log("On Air");
        }
    }

    private void Fall()
    {
        rigid.AddForce(-this.transform.up * 125f, ForceMode.Impulse);
        rigid.AddTorque(this.transform.right * -125f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
#endif

//#if UNITY_ANDROID
        if (Input.touchCount == 1)
        {

        }
//#endif
    }
}
