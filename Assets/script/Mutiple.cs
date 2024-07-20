using System.Collections;
using UnityEngine;

public class Mutiple : MonoBehaviour
{
    [SerializeField] Transform a;
    public float shake;
    public float duration = 5f; // n�b�Ԏ��s����
    public float repeatRate = 3f; // m�b���ƂɌJ��Ԃ�

    void Start()
    {
        StartCoroutine(ShakeForDuration());
    }

    IEnumerator ShakeForDuration()
    {
        float timer = 0f;

        // n�b�ԌJ��Ԃ�
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

        // n�b�Ԍo�ߌ�Am�b���ƂɌJ��Ԃ����s����
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

