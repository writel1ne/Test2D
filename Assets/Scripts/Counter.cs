using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _TextMeshPro;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);
    private Coroutine _coroutine;
    private bool _isRunning = true;
    private int _time = 0;

    void Start()
    {
        _coroutine = StartCoroutine(UpdateCounter());
        Debug.Log("������");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (_isRunning)
            {
                case true:
                    StopCoroutine(_coroutine);
                    Debug.Log("���������");
                    break;
                case false:
                    _coroutine = StartCoroutine(UpdateCounter());
                    Debug.Log("������");
                    break;

            }

            _isRunning = !_isRunning;
        }  
    }

    IEnumerator UpdateCounter()
    {
        while (true)
        {
            _time += 1;
            _TextMeshPro.text = _time.ToString();
		    yield return _waitForSeconds;
        }
	}
}
