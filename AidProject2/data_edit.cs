using Godot;
using System;
using System.Collections.Generic;

public partial class data_edit : Node2D
{
	private List<Disaster> disasterList = new List<Disaster>();

	public override void _Ready()
	{
		//set error message to not visible
		GetNode<Label>("FieldsNullLabel").Visible = false;
		//get disasterList
		disasterList = disasterListClass.GetDisasterList();
		
		//set all LineEdits to ""
		GetNode<LineEdit>("DateLineEdit").Text = "";
		GetNode<LineEdit>("TypeLineEdit").Text = "";
		GetNode<LineEdit>("ScaleLineEdit").Text = "";
		GetNode<LineEdit>("PeopleLineEdit").Text = "";
		GetNode<LineEdit>("FundingLineEdit").Text = "";
		GetNode<LineEdit>("CurFoodLineEdit").Text = "";
		GetNode<LineEdit>("CurWaterLineEdit").Text = "";
		GetNode<LineEdit>("CurMedicineLineEdit").Text = "";
		GetNode<LineEdit>("CurPersonelLineEdit").Text = "";
		GetNode<LineEdit>("EnRouteFoodLineEdit").Text = "";
		GetNode<LineEdit>("EnRouteWaterLineEdit").Text = "";
		GetNode<LineEdit>("EnRouteMedicineLineEdit").Text = "";
		GetNode<LineEdit>("EnRoutePersonelLineEdit").Text = "";

	}

	public override void _Process(double delta)
	{
	}

	private void _on_save_button_pressed()
	{
		if (GetNode<LineEdit>("DateLineEdit").Text == "" ||
			GetNode<LineEdit>("TypeLineEdit").Text == "" ||
			GetNode<LineEdit>("ScaleLineEdit").Text == "" ||
			GetNode<LineEdit>("PeopleLineEdit").Text == "" ||
			GetNode<LineEdit>("FundingLineEdit").Text == "" ||
			GetNode<LineEdit>("CurFoodLineEdit").Text == "" ||
			GetNode<LineEdit>("CurWaterLineEdit").Text == "" ||
			GetNode<LineEdit>("CurMedicineLineEdit").Text == "" ||
			GetNode<LineEdit>("CurPersonelLineEdit").Text == "" ||
			GetNode<LineEdit>("EnRouteFoodLineEdit").Text == "" ||
			GetNode<LineEdit>("EnRouteWaterLineEdit").Text == "" ||
			GetNode<LineEdit>("EnRouteMedicineLineEdit").Text == "" ||
			GetNode<LineEdit>("EnRoutePersonelLineEdit").Text == "")//check if fields null
		{
			GetNode<Label>("FieldsNullLabel").Visible = true;
		}
		else
		{
			//set variables
			string type = GetNode<LineEdit>("TypeLineEdit").Text;
			double scale = Convert.ToDouble(GetNode<LineEdit>("ScaleLineEdit").Text);
			int people = Convert.ToInt32(GetNode<LineEdit>("PeopleLineEdit").Text);
			double funding = Convert.ToDouble(GetNode<LineEdit>("FundingLineEdit").Text);
			double curFood = Convert.ToDouble(GetNode<LineEdit>("CurFoodLineEdit").Text);
			double curWater = Convert.ToDouble(GetNode<LineEdit>("CurWaterLineEdit").Text);
			double curMedicine = Convert.ToDouble(GetNode<LineEdit>("CurMedicineLineEdit").Text);
			double curPersonel = Convert.ToDouble(GetNode<LineEdit>("CurPersonelLineEdit").Text);
			double EnRouteFood = Convert.ToDouble(GetNode<LineEdit>("EnRouteFoodLineEdit").Text);
			double EnRouteWater = Convert.ToDouble(GetNode<LineEdit>("EnRouteWaterLineEdit").Text);
			double EnRouteMedicine = Convert.ToDouble(GetNode<LineEdit>("EnRouteMedicineLineEdit").Text);
			double EnRoutePersonel = Convert.ToDouble(GetNode<LineEdit>("EnRoutePersonelLineEdit").Text);

			//Below is for testing
			//GD.Print($"{type} {scale} {people} {funding} {curFood} {curWater} {curMedicine} {curPersonel} {EnRouteFood} {EnRouteWater} {EnRouteMedicine} {EnRoutePersonel}");

			//instanciate new disaster, add to list, return to main
			Disaster disaster = new Disaster(type, scale, people, funding, curFood, curWater, curMedicine, curPersonel, EnRouteFood, EnRouteWater, EnRouteMedicine, EnRoutePersonel);
			disasterList.Add(disaster);
			disasterListClass.SetDisasterList(disasterList);//resave list
			GetTree().ChangeSceneToFile("res://main.tscn");//return to main
		}
	}
}
