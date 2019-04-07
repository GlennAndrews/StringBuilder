namespace StringBuilder
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("4c906d84-f6ad-4f56-bf86-629e5a0f3a0a")]
    public class StringBuilderPopup : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringBuilderPopup"/> class.
        /// </summary>
        public StringBuilderPopup() : base(null)
        {
            this.Caption = "StringBuilder";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new StringBuilderPopupControl();
        }
    }
}
