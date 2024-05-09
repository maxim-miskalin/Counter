using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Tumbler _tumbler;
    [SerializeField] private TextMeshProUGUI _text;

    private float _delay = 0.5f;
    private int _count = 0;
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Start()
    {
        ShowCountUp(_count);
    }

    private void OnEnable()
    {
        _tumbler.Switching += WhenSwitching;
    }

    private void OnDisable()
    {
        _tumbler.Switching -= WhenSwitching;
    }

    private void WhenSwitching()
    {
        if(_tumbler.IsOn)
        {
            _coroutine = StartCoroutine(CountUp());
        }
        else
        {
            if(_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
    }

    private IEnumerator CountUp()
    {
        _wait = new WaitForSeconds(_delay);

        while (_tumbler.IsOn)
        {
            _count++;
            ShowCountUp(_count);
            yield return _wait;
        }

    }

    private void ShowCountUp(int count)
    {
        _text.text = count.ToString();
    }
}
