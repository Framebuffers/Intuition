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
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Diagnostics;

// ****************************************************************************
// Intuition
// Game submission for Godot Wild Jam 76
// 
// Theme: freeze.
// 
// Wildcards:
// - Silent night (silence as gameplay element),
// - UI as part of the game,
// - Advent calendar (a new event per day of review).
// 
// (C) 2024 Framebuffer. Released under MIT license.
// See LICENSE file for full license disclosure.
// 
// This game was written to run under [radiant-fork](https://github.com/RadiantUwU/godot/tree/radiant-fork)
// made by [Radiant-UwU on GitHub](https://github.com/RadiantUwU), a fork of Godot 4.3. 
//
// Gameplay concept: run for the hills avoiding falling objects.
// Follow comments for insight into the code structure.
// Made with a lot of love and passion <3


namespace Intuition
{
	public partial class Main : Node3D
	{
		[Signal] public delegate void StartGameEventHandler();
		public GameMode GameplayMode { get; set; } = GameMode.NotStarted;
		public Node3D OriginPoints => GetNode<Node3D>("/root/Main/ScreenManager/SceneManager/OriginPoints");
		public Player Player => GetNode<Player>("/root/Main/Player");
		private float Intensity { get; set; } = 5.0f;
		private float _seed;
		private Stopwatch _time;

		// public async Task Randomize()
		// {
		// 	await ToSignal(GetTree().CreateTimer(GD.RandRange(30f, 60f)), SceneTreeTimer.SignalName.Timeout);
		// 	EmitSignal(SignalName.StartGame);
		// }

		public override void _Ready()
		{
			Player.EnableTimestop = false;
			// randomise time until game mode changes. default = 30s
			LoadRandomEnvironment();
			Start();
			// EnvironmentManager.TimeToChangeLightingMode = GD.Randi() % 30;
			// $"Environment number: {GameEnvironment}, EnvironmentResource: {WorldEnvironment.Environment.ResourcePath}".ToConsole();

			// randomise a number for intensity. this will modulate the force on which elements will fall/move towards the player.
			// Intensity = GD.Randi() % 10.0f;
			// LoadRandomEnvironment();
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

		private void Start()
		{
			$"Time stop".ToConsole();
			EmitSignal(SignalName.StartGame);
			EnvironmentManager.OnSwitchingState();
			Player.EnableTimestop = true;
			EnvironmentManager.LoadEnvironmentDayAlert();
		}




		public override void _Process(double delta)
		{

			// // $"Elapsed time {_time.Elapsed.Seconds}".ToConsole();
			// if (_time.Elapsed.Seconds == _seed)
			// {
			// 	_time.Stop();

			// }

		}

		// public override void _UnhandledKeyInput(InputEvent @event)
		// {
		// 	if (@event is InputEventKey eventKey && eventKey.Pressed && eventKey.Keycode == Key.K)
		// 	{

		// 	}

		// 	if (@event is InputEventKey eventKey2 && eventKey2.Pressed && eventKey2.Keycode == Key.L)
		// 	{

		// 	}

		// }
	}
}

