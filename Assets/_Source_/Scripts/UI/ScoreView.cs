using System;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    [Inject] private Stats _stats;

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
    }

    private void UpdateData(int score)
    {
        _text.text = score.ToString();
    }
}
