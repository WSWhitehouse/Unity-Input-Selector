// ------------------------------------------- //
// Author  : William Whitehouse / WSWhitehouse //
// GitHub  : github.com/WSWhitehouse           //
// Created : 19/02/2020                        //
// Edited  : 19/02/2020                        // 
// ------------------------------------------- //

using UnityEngine;

namespace WSWhitehouse.InputSelector.Demo
{
    public class InputSelectorDemoScript : MonoBehaviour
    {
        [InputSelector] public string inputOne;
        [InputSelector] public string inputTwo;
    }
}