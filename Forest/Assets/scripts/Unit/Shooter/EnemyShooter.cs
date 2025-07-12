using UnityEngine;
using System.Collections;
public class EnemyShooter : Shooter
{
    [SerializeField] private float _reload;

    private WaitForSeconds _wait;

    private Coroutine _shooting;

    private void Awake()
    {
        _wait = new WaitForSeconds(_reload);
    }

    private void OnEnable()
    {
        StartShooting();
    }

    private void OnDisable()
    {
        StopShooting();
    }

    private IEnumerator Shooting()
    {
        while (enabled)
        {
            yield return _wait;

            Shoot();
        }
    }

    public void StartShooting()
    {
        if (_shooting == null)
        {
            _shooting = StartCoroutine(Shooting());
        }
    }

    public void StopShooting()
    {
        if (_shooting != null)
        {
            StopCoroutine(_shooting);

            _shooting = null;
        }
    }
}
