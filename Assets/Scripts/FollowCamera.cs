using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private float zOffset;
    private float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        zOffset = this.transform.position.z - player.transform.position.z;
        yOffset = this.transform.position.y - player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x,
                                               player.transform.position.y + 2.8f,
                                               player.transform.position.z + zOffset);
    }
}
