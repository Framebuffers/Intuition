using Godot;

namespace Intuition.Extensions;
public static class ConsoleExtensions
{
  public static void ToConsole(this string text) => GD.Print(text);
}
