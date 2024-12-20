using System;
using Godot;

namespace Intuition.Extensions
{
  public static class ConsoleExtensions
  {
    public static void ToConsole(this string text) => GD.Print(text);
    public static bool IsBetween(this DateTime now, TimeSpan start, TimeSpan end)
    {
      var time = now.TimeOfDay;
      return start <= end ? time >= start && time <= end : time >= start || time <= end;
    }
  }


}
