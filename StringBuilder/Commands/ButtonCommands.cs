using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Input;

namespace StringBuilder.Commands
{
    public class ButtonCommands
    {
        private ICommand _buttonBuildClick;
        public ICommand ButtonBuildClick
        {
            get
            {
                if (_buttonBuildClick == null)
                {
                    _buttonBuildClick = new RelayCommand(
                        p => true,
                        p => this.Build());
                }
                return _buttonBuildClick;
            }
        }

        /// <summary>
        /// Handles click on the button
        /// </summary>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        public void Build()
        {
            
        }
    }
}
