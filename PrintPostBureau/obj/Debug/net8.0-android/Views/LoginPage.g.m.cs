//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrintPostBureau.Views
{
#nullable disable

	[global::System.CodeDom.Compiler.GeneratedCode("CompiledBindings", null)]
	partial class LoginPage
	{
		private global::Microsoft.Maui.Controls.Button button1;
		private bool _generatedCodeInitialized;

		private void InitializeAfterConstructor()
		{
			if (_generatedCodeInitialized)
				return;

			_generatedCodeInitialized = true;

			button1 = global::Microsoft.Maui.Controls.NameScopeExtensions.FindByName<global::Microsoft.Maui.Controls.Button>(this, "button1");


			this.BindingContextChanged += this_BindingContextChanged;
			if (this.BindingContext is global::PrintPostBureau.ViewModels.LoginViewModel dataRoot0)
			{
				Bindings_this.Initialize(this, dataRoot0);
			}
		}

		private void this_BindingContextChanged(object sender, global::System.EventArgs e)
		{
			Bindings_this.Cleanup();
			if (((global::Microsoft.Maui.Controls.Element)sender).BindingContext is global::PrintPostBureau.ViewModels.LoginViewModel dataRoot)
			{
				Bindings_this.Initialize(this, dataRoot);
			}
		}

		LoginPage_Bindings_this Bindings_this = new LoginPage_Bindings_this();

		class LoginPage_Bindings_this
		{
			LoginPage _targetRoot;
			global::PrintPostBureau.ViewModels.LoginViewModel _dataRoot;
			LoginPage_BindingsTrackings_this _bindingsTrackings;

			public void Initialize(LoginPage targetRoot, global::PrintPostBureau.ViewModels.LoginViewModel dataRoot)
			{
				_targetRoot = targetRoot;
				_dataRoot = dataRoot;
				_bindingsTrackings = new LoginPage_BindingsTrackings_this(this);

				Update();

				_bindingsTrackings.SetPropertyChangedEventHandler0(dataRoot);
			}

			public void Cleanup()
			{
				if (_targetRoot != null)
				{
					_bindingsTrackings.Cleanup();
					_dataRoot = null;
					_targetRoot = null;
				}
			}

			public void Update()
			{
				var dataRoot = _dataRoot;
				Update0_LoginCommand(dataRoot);
			}

			private void Update0_LoginCommand(global::PrintPostBureau.ViewModels.LoginViewModel value)
			{
#line (18, 17) - (18, 47) 18 "..\..\..\..\Views\LoginPage.xaml"
				_targetRoot.button1.Command = value.LoginCommand;
#line default
			}

			class LoginPage_BindingsTrackings_this
			{
				global::System.WeakReference _bindingsWeakRef;
				global::System.ComponentModel.INotifyPropertyChanged _propertyChangeSource0;

				public LoginPage_BindingsTrackings_this(LoginPage_Bindings_this bindings)
				{
					_bindingsWeakRef = new global::System.WeakReference(bindings);
				}

				public void Cleanup()
				{
					SetPropertyChangedEventHandler0(null);
				}

				public void SetPropertyChangedEventHandler0(global::PrintPostBureau.ViewModels.LoginViewModel value)
				{
					global::CompiledBindings.MAUI.CompiledBindingsHelper.SetPropertyChangedEventHandler(ref _propertyChangeSource0, value, OnPropertyChanged0);
				}

				private void OnPropertyChanged0(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
				{
					var bindings = global::CompiledBindings.MAUI.CompiledBindingsHelper.TryGetBindings<LoginPage_Bindings_this>(ref _bindingsWeakRef, Cleanup);
					if (bindings == null)
					{
						return;
					}

					var typedSender = (global::PrintPostBureau.ViewModels.LoginViewModel)sender;
					if (string.IsNullOrEmpty(e.PropertyName) || e.PropertyName == "LoginCommand")
					{
						bindings.Update0_LoginCommand(typedSender);
					}
				}
			}
		}
	}
}
