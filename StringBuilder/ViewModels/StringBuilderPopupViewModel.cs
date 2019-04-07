using StringBuilder.Commands;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace StringBuilder.ViewModels
{
    public class StringBuilderPopupViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties
        private string _input;
        public string Input
        {
            get
            {
                return _input;
            }
            set
            {
                if (value != this._input)
                {
                    this._input = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _output;
        public string Output
        {
            get
            {
                return _output;
            }
            set
            {
                if (value != this._output)
                {
                    this._output = value;
                    NotifyPropertyChanged();
                }

            }
        }
        #endregion

        #region Build Command
        private ICommand _buttonBuildClick;
        public ICommand CmdBuild
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
        private void Build()
        {
            var sb = new System.Text.StringBuilder();

            if (!string.IsNullOrWhiteSpace(_input))
            {
                string[] stringSeparators = new string[] { "\r\n" };
                string[] lines = _input.Split(stringSeparators, StringSplitOptions.None);

                sb.AppendLine("var sb = new StringBuilder();\r\n");

                foreach (var line in lines)
                {
                    sb.AppendLine($"sb.AppendLine(\"{line}\");");
                }
            }

            Output = sb.ToString();
        }
        #endregion

        #region Copy Command
        private ICommand _buttonCopyClick;
        public ICommand CmdCopy
        {
            get
            {
                if (_buttonCopyClick == null)
                {
                    _buttonCopyClick = new RelayCommand(
                        p => true,
                        p => this.Copy());
                }
                return _buttonCopyClick;
            }
        }

        /// <summary>
        /// Handles click on the button
        /// </summary>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void Copy()
        {
            Clipboard.SetText(_output);
        }

        #endregion

        public StringBuilderPopupViewModel()
        {

        }

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
