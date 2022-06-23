using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    #region Serializable Fields

    [Header("DialogBox components")]
    [SerializeField]
    private SO_String _dialogText;

    [SerializeField]
    private TextMeshProUGUI _textBox;

    [SerializeField]
    private TextMeshProUGUI _characterName;

    [SerializeField]
    private Image _image;

    #endregion

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _dialogText.value = "";
        _textBox.text = "";
        _characterName.text = "";
        _image = null;
    }

    private void Update()
    {
        SetText();
    }

    private void SetText()
    {
        _textBox.text = _dialogText.value;
    }
}
