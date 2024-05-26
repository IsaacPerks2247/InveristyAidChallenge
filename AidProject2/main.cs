using Godot;
using System;
using System.Collections.Generic;

public class buttonIndex//for saving button index when button clicked
{
	private static int indexOfButton;

	public static void SetIndex(int index)//set
	{
		indexOfButton = index;
	}

	public static int GetButtonIndex()//get
	{
		return indexOfButton;
	}
}

public class disasterListClass//this is needed so doesnt reset every time you return to main.tscn
{
	private static List<Disaster> disasterList = new List<Disaster>();//to store all disasters

	public static List<Disaster> GetDisasterList()
	{
		return disasterList;
	}

	public static void SetDisasterList(List<Disaster> inDisasterList)
	{
		disasterList = inDisasterList;
	}
}

public class baseListClass//this is needed so doesnt reset every time you return to main.tscn
{
	private static List<base_button_scene> baseList = new List<base_button_scene>();// List to store references to all spawned bases

	public static List<base_button_scene> GetBaseList()
	{
		return baseList;
	}

	public static void SetBaseList(List<base_button_scene> inBaseList)
	{
		baseList = inBaseList;
	}

	//public static int FindIndex(base_button_scene base)
	//{
		
	//}
}

public partial class main : Node2D
{
	public PackedScene Bases {  get; set; }//packed scenes

	base_button_scene Base;

	private static List<base_button_scene> baseList;
	private static List<Disaster> disasterList;

	public override void _Ready()
	{
		Bases = GD.Load<PackedScene>("res://base_button_scene.tscn"); // Load and scene into memory

		baseList = baseListClass.GetBaseList(); // Get list from baseListClass
		disasterList = disasterListClass.GetDisasterList(); // Get list from disasterListClass

		if (baseList.Count == 0)
		{
			baseList = new List<base_button_scene>(); // Initialize if not set
			baseListClass.SetBaseList(baseList); // Set in baseListClass
		}
		else
		{
			foreach (var baseButton in baseList)
			{
				baseButton.Visible = true;
			}
		}
	}

	public override void _Process(double delta)
	{
	}

	public void SpawnBase(Vector2 position)
	{
		Base = (base_button_scene)Bases.Instantiate();
		Base.Position = position;
		GetParent().AddChild(Base); // Render base
		baseList.Add(Base); // Add base to the list

		foreach (var baseButton in baseList)
		{
			baseButton.Visible = false;
		}

		baseListClass.SetBaseList(baseList);
		disasterListClass.SetDisasterList(disasterList);
		GetTree().ChangeSceneToFile("res://data_edit.tscn");
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton eventMouseButton &&
			eventMouseButton.Pressed == true)//checks for mouse click
		{
			Vector2 mousePosition = GetViewport().GetMousePosition();//mouse position
			
			if (mousePosition.X > 110 || mousePosition.Y > 60)//checks to see if its near logisticsViewButton
			{
				bool isFarFromAllBases = true;

				foreach (var baseButton in baseList)//checking not near baseButtons instances
				{
					if (mousePosition.DistanceTo(baseButton.Position) <= 15)
					{
						isFarFromAllBases = false;
						break;
					}
				}

				if (isFarFromAllBases)
				{
					SpawnBase(mousePosition); // Calls method and passes position
				}
			}
		}
	}
	
	private void _on_logistics_button_pressed()
	{
		//makes all buttons not visible
		foreach (var baseButton in baseList)
		{
			baseButton.Visible = false;
		}

		baseListClass.SetBaseList(baseList);
		disasterListClass.SetDisasterList(disasterList);
		GetTree().ChangeSceneToFile("res://logistics_view.tscn");
	}
}



