using System.Collections;
using UnityEngine;

public class Mutiple : MonoBehaviour
{
    [SerializeField] Transform a;
    public float shake;
    public float duration = 5f; // n•bŠÔÀs‚·‚é
    public float repeatRate = 3f; // m•b‚²‚Æ‚ÉŒJ‚è•Ô‚·

    void Start()
    {
        StartCoroutine(ShakeForDuration());
    }

    IEnumerator ShakeForDuration()
    {
        float timer = 0f;

        // n•bŠÔŒJ‚è•Ô‚·
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

        // n•bŠÔŒo‰ßŒãAm•b‚²‚Æ‚ÉŒJ‚è•Ô‚µÀs‚·‚é
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

