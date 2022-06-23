using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_Dialog : ScriptableObject
{
    public DialogData[] _dialogs;
}

[Serializable]
public class DialogData
{
    [SerializeField]
    private SpriteRenderer _image;

    [SerializeField]
    [TextArea(5, 100)]
    private string _text;
}
