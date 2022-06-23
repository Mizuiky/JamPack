using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_Dialog : ScriptableObject
{
    public string _characterName;

    public List<DialogData> _dialog;
}

[Serializable]
public class DialogData
{
    public SpriteRenderer _image;

    public Animator _animator;

    [TextArea(5, 100)]
    public string _text;
}
