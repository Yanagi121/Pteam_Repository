using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class translationControl : MonoBehaviour
{
    Lean.Localization.LeanLocalization leanLocalization;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        leanLocalization = FindObjectOfType<Lean.Localization.LeanLocalization>();

    }

    public void OnJapaneseButton()
    {
        leanLocalization.CurrentLanguage = "Japanese";
    }
    public void OnEnglishButton()
    {
        leanLocalization.CurrentLanguage = "English";
    }
    public void OnSpanishButton()
    {
        leanLocalization.CurrentLanguage = "Spanish";
    }
    public void OnChineseButton()
    {
        leanLocalization.CurrentLanguage = "Chinese";
    }
}
