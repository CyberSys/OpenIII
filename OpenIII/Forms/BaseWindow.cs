﻿/*
 *  This file is a part of OpenIII project, the GTA modding tool.
 *  
 *  Copyright (C) 2019-2020 Savelii Morozov (Prographer)
 *  Email: morozov.salevii@gmail.com
 *  
 *  Copyright (C) 2019-2020 Sergey Filatov (raxp)
 *  Email: raxp.worm202@gmail.com
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace OpenIII.Forms
{
    /// <summary>
    /// Basic form that implements standard features for all other forms
    /// </summary>
    /// <summary xml:lang="ru">
    /// Базовая форма, которая содержит базовые функции для всех других форм
    /// </summary>
    public partial class BaseWindow : Form
    {
        /// <summary>
        /// File edited flag
        /// </summary>
        /// <summary xml:lang="ru">
        /// Флаг, указывающий на то, что файл был изменён после сохранения
        /// </summary>
        protected bool isFileEdited = false;

        /// <summary>
        /// Form constructor
        /// </summary>
        /// <summary xml:lang="ru">
        /// Конструктор формы
        /// </summary>
        public BaseWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the window title
        /// </summary>
        /// <summary xml:lang="ru">
        /// Устанавливает новый текст заголовка окна
        /// </summary>
        /// <param name="title">New title text</param>
        /// <param name="title" xml:lang="ru">Новый текст заголовка окна</param>
        public void SetWindowTitle(string title)
        {
            Text = title;
        }

        /// <summary>
        /// Closes current window with save notification prompt if file is edited
        /// </summary>
        /// <summary xml:lang="ru">
        /// Закрывает текущее окно выводя перед закрытием предложение сохранить файл если он был изменён
        /// </summary>
        /// <param name="e">Cancel event arguments</param>
        /// <param name="e" xml:lang="ru">Аргументы отмены закрытия окна</param>
        public void CloseWindow(CancelEventArgs e)
        {
            if (isFileEdited == true)
            {
                DialogResult dialogResult = MessageBox.Show("Some changes wasn't saved. Do you really want to close window?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        Close();
                        break;

                    case DialogResult.No:
                        e.Cancel = true;
                        return;
                    break;
                }
            }
        }

        /// <summary>
        /// Closes current window with save notification prompt if file is edited
        /// </summary>
        /// <summary xml:lang="ru">
        /// Закрывает текущее окно выводя перед закрытием предложение сохранить файл если он был изменён
        /// </summary>
        public void CloseWindow()
        {
            if (isFileEdited == true)
            {
                DialogResult dialogResult = MessageBox.Show("Some changes wasn't saved. Do you really want to close window?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        Close();
                        break;

                    case DialogResult.No:
                        return;
                    break;
                }
            }
        }
    }
}
