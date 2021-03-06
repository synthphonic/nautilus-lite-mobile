﻿//
// Class is based on
// https://github.com/ffMathy/asyncdelegatecommand-wpf/blob/master/AsyncDelegateCommand/AsyncDelegateCommand/AsyncDelegateCommand.cs
// Credits: https://github.com/ffMathy
//

using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NautilusLite.Forms.Input
{
	public class AsyncDelegateCommand : ICommand
	{
		public event EventHandler CanExecuteChanged = null;

		private readonly Predicate<object> _canExecute;
		private readonly Func<object, Task> _asyncExecute;
		private readonly bool _allowMultipleExecutionsAtOnce;
		private bool _isExecuting;

		public AsyncDelegateCommand(Func<object, Task> execute)
			: this(execute, null, false)
		{

		}

		public AsyncDelegateCommand(Func<object, Task> execute, bool allowMultipleExecutionsAtOnce)
			: this(execute, null, allowMultipleExecutionsAtOnce)
		{
		}

		protected virtual void OnCanExecuteChanged(EventArgs e)
		{
			CanExecuteChanged?.Invoke(this, e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="asyncExecute"></param>
		/// <param name="canExecute"></param>
		/// <param name="allowMultipleExecutionsAtOnce">Whether or not this command can be executed several times in a row, or if it must wait until the previous command has been executed. Defaults to false.</param>
		public AsyncDelegateCommand(Func<object, Task> asyncExecute,
					   Predicate<object> canExecute, bool allowMultipleExecutionsAtOnce)
		{
			_asyncExecute = asyncExecute;
			_canExecute = canExecute;
			_allowMultipleExecutionsAtOnce = allowMultipleExecutionsAtOnce;
		}

		public bool CanExecute(object parameter)
		{
			if (!_allowMultipleExecutionsAtOnce && _isExecuting)
			{
				return false;
			}

			if (_canExecute == null)
			{
				return true;
			}

			return _canExecute(parameter);
		}

		public async void Execute(object parameter)
		{
			_isExecuting = true;
			await ExecuteAsync(parameter);
			_isExecuting = false;
		}

		protected virtual async Task ExecuteAsync(object parameter)
		{
			await _asyncExecute(parameter);
		}
	}
}
