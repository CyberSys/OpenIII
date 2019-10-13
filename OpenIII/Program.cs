﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OpenIII.GameFiles;

namespace OpenIII
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ArchiveFile img = new ArchiveFile();

            Application.Run(new MainWindow(img));
        }
    }
}
