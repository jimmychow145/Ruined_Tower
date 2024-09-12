using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public int target = 50;
    // Start is called before the first frame update
    Vector3 position;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
        position = transform.position;
        
        Destroy(GameObject.FindGameObjectWithTag("Music"));
    }

    // Update is called once per frame
    void Update()
    {

        position.y = player.position.y;

        transform.position = position;
    }

}
