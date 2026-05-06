using System;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace Alte.UI
{
    public static class AlteUIToolkitLib
    {
        public static void WriteTexts(UIDocument document, string target, Span<string> texts)
        {
            List<Label> labels = document.rootVisualElement.Query<Label>("target").ToList();
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].text = texts[i];
            }
        }

        public static void RegisterClickEvents(UIDocument document, string target, Action<int> eve)
        {
            List<Button> buttons = document.rootVisualElement.Query<Button>("target").ToList();
            for (int i = 0; i < buttons.Count; i++)
            {
                int index = i;
                buttons[i].clicked += () => eve(index);
            }
        }

        public static void SwitchClass(VisualElement target, Span<string> trueDisplay, Span<string> falseDisplay, bool mode)
        {
            if (mode)
            {
                for (int i = 0; i < falseDisplay.Length; i++)
                {
                    target.RemoveFromClassList(falseDisplay[i]);
                }
                for (int i = 0; i < trueDisplay.Length; i++)
                {
                    target.AddToClassList(trueDisplay[i]);
                }
            }
            else
            {
                for (int i = 0; i < trueDisplay.Length; i++)
                {
                    target.RemoveFromClassList(trueDisplay[i]);
                }
                for (int i = 0; i < falseDisplay.Length; i++)
                {
                    target.AddToClassList(falseDisplay[i]);
                }
            }
        }

        public static void SwitchDisplay(Span<VisualElement> targets, Span<string> classes, int index)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                for (int j = 0; j < classes.Length; j++)
                {
                    targets[i].RemoveFromClassList(classes[j]);
                }
            }
            if (index < 0) return;
            for (int i = 0; i < classes.Length; i++)
            {
                targets[index].AddToClassList(classes[i]);
            }
        }
    }
}