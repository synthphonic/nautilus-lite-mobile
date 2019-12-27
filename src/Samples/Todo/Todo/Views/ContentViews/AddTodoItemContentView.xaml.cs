﻿using Todo.ViewModels;
using Xamarin.Forms;

namespace Todo.Views.ContentViews
{
	public partial class AddTodoItemContentView : ContentView
	{
		private readonly AddTodoItemViewModel _vm;

		public AddTodoItemContentView()
		{
			InitializeComponent();
			BindingContext = _vm = new AddTodoItemViewModel();
		}

		public void LoadData()
		{
			_vm.LoadData(null);
		}

		internal void UnLoadData()
		{
			_vm.UnLoadData();
		}

		#region SlideUpHeightProperty
		public static readonly BindableProperty SlideUpHeightProperty =
		BindableProperty.Create("double", typeof(double), typeof(AddTodoItemContentView), -1.0D);

		public double SlideUpHeight
		{
			get => (double)GetValue(SlideUpHeightProperty);
			set => SetValue(SlideUpHeightProperty, value);
		}
		#endregion

	}
}