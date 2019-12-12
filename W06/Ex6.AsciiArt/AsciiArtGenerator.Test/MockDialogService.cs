using AsciiArtGenerator.Services;
using System.Collections.Generic;
using System.IO;

namespace AsciiArtGenerator.Test
{
    public class MockDialogService : IDialogService
    {
        public List<MockErrorMessage> Errors { get; } = new List<MockErrorMessage>();


        public string ChooseFile()
        {
            return Path.Combine(AsciiArtGeneratorTest.GetMediaPath("things"), "x-wing.jpg");
        }

        public void ShowError(string title, string msg)
        {
            Errors.Add(new MockErrorMessage()
            {
                Title = title,
                Message = msg
            });
        }
    }

    public class MockErrorMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}