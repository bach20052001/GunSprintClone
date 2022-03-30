using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{

    private List<GameObject> listBullet = new List<GameObject>();
    [SerializeField] private GameObject bullet;
    private int initialSize = 5;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initialSize; i++)
        {
            GameObject bulletIni = Instantiate(bullet, Vector3.zero, Quaternion.identity, this.transform);
            listBullet.Add(bulletIni);
            bulletIni.SetActive(false);
        }
    }
    

    // Update is called once per frame
    public GameObject GetUnactiveObject()
    {
        for (int i = 0; i < initialSize; i++)
        {
            if (!listBullet[i].activeSelf)
            {
                return listBullet[i];
            }
        }

        GameObject bulletIni = Instantiate(bullet, Vector3.zero, Quaternion.identity, this.transform);
        listBullet.Add(bulletIni);
        bulletIni.SetActive(false);

        return bulletIni;
    }
}
