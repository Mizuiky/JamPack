using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class SO_Dialog : ScriptableObject
{
    public List<DialogData> _dialog;

    public EndDialogBase _endPrefab;
}

[Serializable]
public class DialogData
{
    public string _characterName;

    public Sprite _image;

    public Animator _animator;

    [TextArea(5, 100)]
    public string _text; 
}
