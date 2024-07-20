using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAnimation : MonoBehaviour
{
    private float x;
    private float y;
    private float vx;
    private float vy;
    [SerializeField] Transform a; //“®‚©‚·ƒp[ƒc‚ÌTransform
    // Start is called before the first frame update
    void Start()
    {
        x = 15;
        vx = 0.08f;
        Vector3 _Rotation = gameObject.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if(x>=16)
        {
            vx = vx * -1f;
        }
        if(x<5)
        {
            vx = vx * -1;
        }
        x = x + vx;
        y = y + vx;
    }
    private void LateUpdate()
    {
        a.transform.Rotate(new Vector3(x, x, y*-1f));
    }
}
