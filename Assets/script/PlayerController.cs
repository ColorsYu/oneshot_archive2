using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Sliderのためのもの 

public class PlayerController : MonoBehaviour
{
    [SerializeField] Slider xSlider; //X軸の進む距離
    [SerializeField] Slider MotionSpeedSlider; //モーションのスピード
    [SerializeField] Slider NormalTimeSlider; //通常アニメーションの実行の長さ
    [SerializeField] Slider OneshotTimeSlider; //瀕死アニメーションの実行の長さ
    //[SerializeField] Text xtext; //Textを宣言
    //[SerializeField] Text MotionSpeedtext; //Textを宣言

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

    private Vector3 _aim; // 追記
    private Quaternion _playerRotation; // 追記

    float timer = 0.0f;
    bool isExecuting = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();

        _playerRotation = _transform.rotation; // 追記
    }

    void Update()
    {
        float interval = Random.value * NormalTimeSlider.value; // 〇秒ごとに実行

        //xtext.text = xSlider.value.ToString("N2");//Sliderたちのtext
        //MotionSpeedtext.text = MotionSpeedSlider.value.ToString("N2");//Sliderたちのtext
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            if (!isExecuting)
            {
                StartCoroutine(ExecuteForDuration(Random.value * OneshotTimeSlider.value)); // 〇秒間だけ実行
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

        // ここで実行したい処理を記述
        _animator.SetFloat("Pose", MotionSpeedSlider.value);
        //_speed = 0.5f;
        _speed = xSlider.value;

        yield return new WaitForSeconds(duration);

        // 処理の後、Poseを元に戻すなどの追加の処理を行う場合はここで記述
        _animator.SetFloat("Pose", 1.0f); //ノーマルのモーションの動きのはやさが1
        _speed = xSlider.value; //進む距離の最大値

        isExecuting = false;
    }

    void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");


        var _horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up); // 追記

        _velocity = _horizontalRotation * new Vector3(_horizontal, _rigidbody.velocity.y, _vertical).normalized; // 修正

        _aim = _horizontalRotation * new Vector3(_horizontal, 0, _vertical).normalized; // 追記

        if (_aim.magnitude > 0.5f)
        { // 以下追記
            _playerRotation = Quaternion.LookRotation(_aim, Vector3.up);
        }

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, _playerRotation, 600 * Time.deltaTime); // 追記

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
