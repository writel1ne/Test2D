using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
	private TMP_Text _textMeshPro;
	private WaitForSeconds _delay = new WaitForSeconds(0.5f);
	private Coroutine _coroutine;
	private bool _isRunning = true;
	private int _time = 0;

	private void Start()
	{
		_textMeshPro = GetComponent<TMP_Text>();
		_coroutine = StartCoroutine(UpdateCounter());
		Debug.Log("Запуск");
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (_isRunning)
			{
				StopCoroutine(_coroutine);
				Debug.Log("Остановка");
			}
			else
			{
				_coroutine = StartCoroutine(UpdateCounter());
				Debug.Log("Запуск");
			}

			_isRunning = !_isRunning;
		}
	}

	private IEnumerator UpdateCounter()
	{
		while (enabled)
		{
			_time++;
			_textMeshPro.text = _time.ToString();
			yield return _delay;
		}
	}
}
