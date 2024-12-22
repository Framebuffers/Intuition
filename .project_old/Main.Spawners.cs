using System.Collections.Generic;
using System.Linq;
using Godot;
using Intuition.Extensions;
using Intuition.Gameplay;
namespace Intuition
{
    public partial class Main : Node3D
    {
        // get player spawners
        private void LoadPlayerSpawner()
        {
            IEnumerable<PlayerSpawner> spawners = OriginPoints.GetChildren().Where(x => x is PlayerSpawner).Cast<PlayerSpawner>();
            int randLocation = GD.RandRange(0, spawners.Count() - 1); //off by 1: indexing differences

            // debug
            foreach (var spawner in spawners)
            {
                $"{spawner.GlobalPosition}".ToConsole();
            }
            $"Spawners: {spawners.Count()}. Selected: {randLocation} at {spawners.ElementAt(randLocation).GlobalPosition}".ToConsole();
            Player.GlobalPosition = spawners.ElementAt(randLocation).GlobalPosition;
        }
    }
}