using System.Collections;
using UnityEngine;

public class Mutiple : MonoBehaviour
{
    [SerializeField] Transform a;
    public float shake;
    public float duration = 5f; // n秒間実行する
    public float repeatRate = 3f; // m秒ごとに繰り返す

    void Start()
    {
        StartCoroutine(ShakeForDuration());
    }

    IEnumerator ShakeForDuration()
    {
        float timer = 0f;

        // n秒間繰り返す
        while (timer < duration)
        {
            a.transform.localEulerAngles += new Vector3(
                0f,
                0f,
                Random.Range(-shake, shake));

            yield return null;
            timer += Time.deltaTime;
        }

        Debug.Log("Duration ended. Repeating at rate: " + repeatRate);

        // n秒間経過後、m秒ごとに繰り返し実行する
        while (true)
        {
            a.transform.localEulerAngles += new Vector3(
                0f,
                0f,
                Random.Range(-shake, shake));

            Debug.Log("Repeated shake!");

            yield return new WaitForSeconds(repeatRate);
        }
    }

}

