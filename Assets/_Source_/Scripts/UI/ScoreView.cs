using System;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Stats _stats;

    private void OnEnable()
    {
        _stats.StepsChanged += UpdateData;
    }

    private void OnDisable()
    {
        _stats.StepsChanged -= UpdateData;
    }

    private void OnValidate()
    {
        if (_text == null)
            throw new ArgumentNullException(nameof(_text));

        if (_stats == null)
            throw new ArgumentNullException(nameof(_stats));
    }

    private void UpdateData(int score)
    {
        _text.text = score.ToString();
    }
}
