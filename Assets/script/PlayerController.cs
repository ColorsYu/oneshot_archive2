using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Slider�̂��߂̂��� 

public class PlayerController : MonoBehaviour
{
    [SerializeField] Slider xSlider; //X���̐i�ދ���
    [SerializeField] Slider MotionSpeedSlider; //���[�V�����̃X�s�[�h
    [SerializeField] Slider NormalTimeSlider; //�ʏ�A�j���[�V�����̎��s�̒���
    [SerializeField] Slider OneshotTimeSlider; //�m���A�j���[�V�����̎��s�̒���
    //[SerializeField] Text xtext; //Text��錾
    //[SerializeField] Text MotionSpeedtext; //Text��錾

    private Rigidbody _rigidbody;
    private Transform _transform;
    private Animator _animator;
    private float _horizontal;
    private float _vertical;
    private Vector3 _velocity;
    private float _speed;
    public float push;
    public int max;
       int OneShot;

    private Vector3 _aim; // �ǋL
    private Quaternion _playerRotation; // �ǋL

    float timer = 0.0f;
    bool isExecuting = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();

        _playerRotation = _transform.rotation; // �ǋL
    }

    void Update()
    {
        float interval = Random.value * NormalTimeSlider.value; // �Z�b���ƂɎ��s

        //xtext.text = xSlider.value.ToString("N2");//Slider������text
        //MotionSpeedtext.text = MotionSpeedSlider.value.ToString("N2");//Slider������text
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            if (!isExecuting)
            {
                StartCoroutine(ExecuteForDuration(Random.value * OneshotTimeSlider.value)); // �Z�b�Ԃ������s
            }

            timer = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _speed += push;
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            _speed += push;
        }


        Vector3 randomDirection = new Vector3(5f, 0f, 5f).normalized;
        OneShot = Random.Range(0, 40);

        if (OneShot == 0)
        {
            Debug.Log(OneShot);
            _rigidbody.velocity = randomDirection * _speed;
        }
    }

    IEnumerator ExecuteForDuration(float duration)
    {
        isExecuting = true;

        // �����Ŏ��s�������������L�q
        _animator.SetFloat("Pose", MotionSpeedSlider.value);
        //_speed = 0.5f;
        _speed = xSlider.value;

        yield return new WaitForSeconds(duration);

        // �����̌�APose�����ɖ߂��Ȃǂ̒ǉ��̏������s���ꍇ�͂����ŋL�q
        _animator.SetFloat("Pose", 1.0f); //�m�[�}���̃��[�V�����̓����̂͂₳��1
        _speed = xSlider.value; //�i�ދ����̍ő�l

        isExecuting = false;
    }

    void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");


        var _horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up); // �ǋL

        _velocity = _horizontalRotation * new Vector3(_horizontal, _rigidbody.velocity.y, _vertical).normalized; // �C��

        _aim = _horizontalRotation * new Vector3(_horizontal, 0, _vertical).normalized; // �ǋL

        if (_aim.magnitude > 0.5f)
        { // �ȉ��ǋL
            _playerRotation = Quaternion.LookRotation(_aim, Vector3.up);
        }

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, _playerRotation, 600 * Time.deltaTime); // �ǋL

        _animator.SetBool("walking", true);

        /*
        if (_velocity.magnitude > 0.1f)
        {
            _animator.SetBool("walking", true);
        }
        else
        {
            _animator.SetBool("walking", false);
        }
        */

       if (OneShot != 0)
        {
            _rigidbody.velocity = _velocity * _speed;
        }
    }
}
