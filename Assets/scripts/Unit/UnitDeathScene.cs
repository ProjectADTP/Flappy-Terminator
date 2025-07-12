using UnityEngine;
using System.Collections;

public class UnitDeathScene : MonoBehaviour
{
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(1f);

        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        while (enabled)
        { 
            yield return _wait;
            Destroy(this.gameObject);
        }
    }
}
