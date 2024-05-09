using System;
using UnityEngine;

public class Tumbler : MonoBehaviour
{
    public event Action Switching;

    public bool IsOn { get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Toggle();
            Switching?.Invoke();
        }
    }

    private void Toggle()
    {
        IsOn = !IsOn;
    }
}
