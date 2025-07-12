using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : Shooter
{
    private bool _isActive = true;

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.F)) && _isActive == true)
        {
            Shoot();
        }
    }

    public void SetIsActiveState(bool state)
    {
        _isActive = state;
    }
}
