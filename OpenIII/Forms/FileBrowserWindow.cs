﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenIII.GameFiles;

namespace OpenIII
{
    public partial class FileBrowserWindow : Form
    {
        private ArchiveFile archiveFile;
        private GameDirectory rootDir;

        public FileBrowserWindow(ArchiveFile file)
        {
            InitializeComponent();

            archiveFile = file;
            SetListView(archiveFile.readImgFileList());
            SetTotalFiles(archiveFile.TotalFiles);
        }

        public FileBrowserWindow(GameDirectory rootDir)
        {
            InitializeComponent();

            SetFileListView(rootDir.getContent());
            SetDirListView(rootDir.getDirectories());
        }

        public void SetListView(List<ArchiveEntry> list)
        {
            fileListView.Items.Clear();

            foreach (ArchiveEntry entry in list)
            {
                ListViewItem item = new ListViewItem(entry.filename);
                item.Tag = entry;
                fileListView.Items.Add(item);
            }
        }

        public void SetFileListView(List<GameResource> list)
        {
            fileListView.Items.Clear();

            foreach (GameResource resource in list)
            {
                ListViewItem item = new ListViewItem(resource.Name);
                item.Tag = resource;
                fileListView.Items.Add(item);
            }
        }

        public void SetDirListView(List<GameDirectory> list)
        {
            fileTreeView.Nodes.Clear();

            foreach (GameDirectory dir in list)
            {
                TreeNode item = new TreeNode(dir.Name);
                item.Tag = dir;

                if (dir.getDirectories().Count != 0)
                {
                    // To make node expandable we're adding an empty element.
                    // When user expands it, we're removing this and query the actual child dir list
                    item.Nodes.Add("");
                }

                fileTreeView.Nodes.Add(item);
            }
        }


        public void SetTotalFiles(long totalFiles)
        {
            totalFilesLabel.Text = totalFiles.ToString();
        }

        private void fileListViewDoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem item in fileListView.SelectedItems)
            {
                ArchiveEntry entry = (ArchiveEntry)item.Tag;
                entry.extract(@"D:\Documents\" + entry.filename);
            }
        }
    }
}
