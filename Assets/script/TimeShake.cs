using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShake : MonoBehaviour
{
    [SerializeField] Transform a;

    public float interval;

    bool c;
    public float shake;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Vive", interval);
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void LateUpdate()
    {
        if (c == true)
        {
            a.transform.localEulerAngles
           += new Vector3(
               Random.Range(-shake, shake),
               Random.Range(-shake, shake),
               Random.Range(-shake, shake));
        }
        c = false;

    }

    private void Vive()
    {
        c = true;
        Invoke("Vive", interval);
    }
}
