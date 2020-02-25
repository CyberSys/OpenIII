﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace OpenIII.GameFiles
{
    public class FXTFile : GameFile
    {
        public BindingList<FXTFileItem> Items = new BindingList<FXTFileItem>();

        public FXTFile(string filePath) : base(filePath) { }

        public BindingList<FXTFileItem> ParseData()
        {
            string lineIterator = null;
            StreamReader Reader = new StreamReader(this.FullPath);
            BindingList<FXTFileItem> data = new BindingList<FXTFileItem>();

            while ((lineIterator = Reader.ReadLine()) != null)
            {

                if (lineIterator != "" && Char.IsLetterOrDigit(lineIterator[0]))
                {
                    data.Add(new FXTFileItem(
                        lineIterator.Substring(0, lineIterator.IndexOf(" ")), lineIterator.Substring(lineIterator.IndexOf(" ") + 1))
                    );
                }
            }

            Items = data;

            Reader.Close();

            return data;
        }

        public string DataToString()
        {
            string buf = null;

            foreach (FXTFileItem item in this.Items)
            {
                buf += item.Key + " " + item.Value + '\n';
            }

            return buf;
        }

        public void AddItem(string key, string value)
        {
            Items.Add(new FXTFileItem(key, value));
        }
    }

    public class FXTFileItem
    {
        private const int maxKeyLength = 8;

        public string Key { get; set; }
        public string Value { get; set; }

        public FXTFileItem(string key, string value) {
            this.Key = key;
            this.Value = value;
        }
    }
}