using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateScript : MonoBehaviour
{
    [SerializeField] Transform a;
    [SerializeField] Transform b;//ìÆÇ©Ç∑ÉpÅ[ÉcÇÃTransform

    public float shake;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void LateUpdate()
    {
            a.transform.localEulerAngles
           += new Vector3(
               Random.Range(-shake, shake),
               Random.Range(-shake, shake),
               Random.Range(-shake, shake));
            /*
            b.transform.localEulerAngles
                += new Vector3(
                    Random.Range(-3f, 3f),
                    Random.Range(-3f, 3f),
                    Random.Range(-3f, 3f));
            */

    }

}
