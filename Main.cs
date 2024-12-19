using Godot;
using ViewportConfiguration = Intuition.Configuration.ViewportConfiguration;
using TextPanel = Intuition.UserInterface.TextPanel;
using System;
using Intuition.Extensions;
using Environment = Godot.Environment;
using System.Collections.Generic;
using System.Linq;
using Godot.Collections;
using Intuition.Gameplay;
using Intuition.Camera;
using Intuition.Environment;

namespace Intuition;

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

	private void SetEnvironment()
	{
		var newEnv = ResourceLoader.Load<Godot.Environment>("res://Environment/GenericEnvironment.tres");
	}
	public WorldEnvironment WorldEnvironment => GetNode<WorldEnvironment>("/root/Main/ScreenManager/EnvironmentManager/WorldEnvironment");
	public GameMode GameplayMode { get; set; } = GameMode.NotStarted;
	public EnvironmentMode GameEnvironment { get; set; }
	public Node3D OriginPoints => GetNode<Node3D>("ScreenManager/SceneManager/OriginPoints");
	public Player Player => GetNode<Player>("Player");
	public EnvironmentManager EnvironmentManager => GetNode<EnvironmentManager>("ScreenManager/EnvironmentManager");

	public override void _Ready()
	{
		// get player spawners
		IEnumerable<PlayerSpawner> spawners = OriginPoints.GetChildren().Where(x => x is PlayerSpawner).Cast<PlayerSpawner>();
		int randLocation = GD.RandRange(0, spawners.Count() - 1); //off by 1: indexing differences

		// debug
		foreach (var spawner in spawners)
		{
			$"{spawner.GlobalPosition}".ToConsole();
		}
		$"Spawners: {spawners.Count()}. Selected: {randLocation} at {spawners.ElementAt(randLocation).GlobalPosition}".ToConsole();
		// debug

		// Player.GlobalPosition = spawners.ElementAt(randLocation).GlobalPosition;

		// choose starting point, environment and randomise lighting.
		// choose environment based on time of day
		// if (DateTime.Now.IsBetween(TimeSpan.Parse("06:00"), TimeSpan.Parse("12:00")))
		// {
		// 	GameEnvironment = EnvironmentMode.Morning;
		// }

		// if (DateTime.Now.IsBetween(TimeSpan.Parse("12:00"), TimeSpan.Parse("21:00")))
		// {
		// 	GameEnvironment = EnvironmentMode.Evening;
		// }

		// if (DateTime.Now.IsBetween(TimeSpan.Parse("21:00"), TimeSpan.Parse("06:00")))
		// {
		// 	GameEnvironment = EnvironmentMode.Night;
		// }


		// int randEnv = GD.RandRange(0, Enum.GetNames(typeof(EnvironmentMode)).Length - 1);
		// GameEnvironment = (EnvironmentMode)randEnv;
		EnvironmentManager.LoadEnvironment(GD.RandRange(0, 6), GD.RandRange(0, 1));
		$"Environment number: {GameEnvironment}, EnvironmentResource: {WorldEnvironment.Environment.ResourcePath}".ToConsole();




		// randomise time until game mode changes
		// randomise a number for intensity. this will modulate the force on which elements will fall/move towards the player.
		// shake playing field
		// enable timestop: player gets out of bed, moves a bit, then pause the game. music and player controller keep on going.
		// change game mode to alert
		// enable alarms
		// when near a safe space, silence noise and chaos, change lighting to focus where to go
		// intuition: you know where to go, or where is safe, based on environmental clues and behaviour of NPC's/objects
		// randomise time to change from alert to avoid
		// things are going to start falling, moving. alarms and people screaming sound.
		// player has to avoid objects falling.
		// safe spaces are random. they can be: under a desk, under a doorframe, at a designated space, at a space clear of falling objects.
		// these spaces will be highlighted using audio cues (they're quieter) and lighting (they're lit).
		// call for spawners to activate
		// randomise time to change from avoid to escape
		// spawners stop
		// need to move to higher ground
		// you start being a beam of light
		// need to help NPC's by luring them towards you and move with you.
		// walking animation pause when you look at them.
		// if on high ground, sound the alarm
		// water will slowly rise and move objects to -X
		// water will rise based on playing field shaking intensity
		// player gets rated based on saved npc's
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) { }

	public override void _UnhandledKeyInput(InputEvent @event)
	{
		if (@event is InputEventKey eventKey && eventKey.Pressed && eventKey.Keycode == Key.K)
		{
			// EnvironmentManager.TimeToChangeLightingMode = 5.o;
			// EnvironmentManager.LoadEnvironment(GD.RandRange(0, 6), GD.RandRange(0, 1));
			// $"Environment number: {GameEnvironment}, EnvironmentResource: {WorldEnvironment.Environment.ResourcePath}".ToConsole();
			Player.EnableTimestop = true;

		}

		if (@event is InputEventKey eventKey2 && eventKey2.Pressed && eventKey2.Keycode == Key.L)
		{
			EnvironmentManager.OnSwitchingState();
		}

	}
}
