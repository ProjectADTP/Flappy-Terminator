using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action Jump;
    public event Action Shoot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) == true)
        {
            Shoot?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Jump?.Invoke();
        }
    }
}
