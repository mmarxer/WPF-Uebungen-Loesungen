using System;
using System.Collections.Generic;
using System.Text;

namespace AsciiArtGenerator.Services
{
    public interface IDialogService
    {
        string ChooseFile();
        void ShowError(string title, string msg);
    }
}
