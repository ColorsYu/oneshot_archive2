using UnityEngine;

public class rightWalk : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Animator _animator;

    int delay = 300;
    Vector3[] array = new Vector3[300];


    private float rndx;
    private float rndz;

    void Start()
    {
        _animator = GetComponent<Animator>();

        for (int i = 0; i < delay; ++i)
        {
            array[i] = Vector3.zero;
        }
    }

    private void Update()
    {

        rndx = Random.Range(-0.03f, 0.03f);
        rndz = Random.Range(-0.03f, 0.03f);
        var velocity = Vector3.zero;
        _speed = 1f;
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W))
            {
                velocity.z = _speed;
                if(Random.Range(0,4)==1)
                {
                    //transform.Rotate(new Vector3(3,0,9) * Time.deltaTime);
                    // velocity.x=-speed;
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                velocity.x = -_speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                velocity.z = -_speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                velocity.x = _speed;
            }

            if (velocity.x != 0 || velocity.z != 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    velocity = velocity * 0.01f;
                }
                else
                {
                    velocity = velocity * 0.0022f;
                }

            }

        }

            if (velocity.magnitude >= 0.01f)
            {
                _animator.SetBool("walking", false);
                _animator.SetBool("running", true);
            }
            else if (velocity.magnitude >= 0.0001f)
            {
                _animator.SetBool("running", false);
                _animator.SetBool("walking", true);
            }
            else
            {
                _animator.SetBool("running", false);
                _animator.SetBool("walking", false);
            }


            transform.position += transform.rotation * velocity;
        
    }
}

