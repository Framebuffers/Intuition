using Godot;
namespace Intuition
{
    public partial class Main : Node3D
    {
        /// <summary>
        /// Defines lighting modes. Game will change lighting based on the current EnvironmentMode.
        /// Each day the player can be loaded onto one of the first 3 modes. Lighting parameters are randomised.
        /// Player's initial location is also placed at random.
        /// </summary>
        public enum EnvironmentMode
        {
            Morning = 0,
            Evening = 1,
            Night = 2,
            Alert = 3
        }

        /// <summary>
        /// Game has 3 main modes:
        /// - one where the player can roam around and do nothing in particular
        /// - gameplay mode 1: avoid things
        /// - gameplay mode 2: run to the hills
        /// 
        /// 
        /// </summary>
        public enum GameMode
        {
            NotStarted = 0, // dead or menu
            Normal = 1, // default
            Alert = 2,
            Avoid = 3, // avoid falling things touch you
            Escape = 4 // run to the hills
        }
    }
}