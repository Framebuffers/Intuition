using System;
using Godot;

namespace Intuition.Extensions
{
    public static class NodeExtensions
    {
        public static void OnClickEvent(this InputEvent @event, Action thingToHappen)
        {
            InputEventMouseMotion b = @event as InputEventMouseMotion;
            if (b != null) thingToHappen.Invoke();
        }
    }
}