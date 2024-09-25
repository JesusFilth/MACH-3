using System;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _step;
    [SerializeField] private TMP_Text _score;

    [Inject] private Stats _stats;

    private void OnEnable()
    {
        _stats.StepsChanged += UpdateStep;
        _stats.ScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        _stats.StepsChanged -= UpdateStep;
        _stats.ScoreChanged -= UpdateScore;
    }

    private void OnValidate()
    {
        if (_step == null)
            throw new ArgumentNullException(nameof(_step));

        if (_score == null)
            throw new ArgumentNullException(nameof(_score));
    }

    private void UpdateStep(int step)
    {
        _step.text = step.ToString();
    }

    private void UpdateScore(int score)
    {
        _score.text = score.ToString();
    }
}
