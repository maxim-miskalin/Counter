using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;

    private float _delay = 0.5f;
    private int _count = 0;
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    void Start()
    {
        ShowCountUp(_count);
    }

    private void OnEnable()
    {
        _button.Switching += WhenSwitching;
    }

    private void OnDisable()
    {
        _button.Switching -= WhenSwitching;
    }

    private void WhenSwitching()
    {
        if(_button.IsMouseClick)
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

        while (_button.IsMouseClick)
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
