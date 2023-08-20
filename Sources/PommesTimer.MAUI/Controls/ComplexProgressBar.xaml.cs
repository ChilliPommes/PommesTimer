using PommesTimer.MAUI.ViewModels;
// ReSharper disable RedundantExtendsListEntry

namespace PommesTimer.MAUI.Controls
{
    public partial class ComplexProgressBar : ContentView
    {
        public ComplexProgressBar()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is ComplexProgressBarViewModel complexProgressBarViewModel)
            {
                complexProgressBarViewModel.PropertyChanged += (_, args) =>
                {
                    // Smooth progress transition on the bar
                    if (args.PropertyName?.Equals(nameof(complexProgressBarViewModel.Progress)) == true)
                    {
                        Bar.ProgressTo(complexProgressBarViewModel.Progress, 980, Easing.Linear);
                    }
                    
                    // Smooth fade in after timer is finished and progress bar still animating
                    if (args.PropertyName?.Equals(nameof(complexProgressBarViewModel.IsDone)) == true)
                    {
                        Image.FadeTo(1, 980, Easing.Default);
                    }
                };
            }
        }
        
        /// <summary>
        /// Method to do some animation stuff on the ui
        /// </summary>
        /// <param name="sender">UI element who is sender</param>
        /// <param name="e">Tapped args</param>
        private void TapGestureRecognizer_OnTapped(object sender, TappedEventArgs e)
        {
            // Do some animation stuff
            Cell.TranslateTo(-500, 0, 250, Easing.SinIn);
            Cell.FadeTo(0, 250, Easing.Default);
        }
    }
}