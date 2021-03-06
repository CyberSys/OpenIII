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

using OpenIII.Forms;
using OpenIII.GameFiles;
using System.Linq;

namespace OpenIII
{
    /// <summary>
    /// Data editor form to modify game configuration files
    /// </summary>
    /// <summary xml:lang="ru">
    /// Форма редактирования конфигурационных файлов
    /// </summary>
    public partial class DataEditorWindow : BaseWindow
    {
        /// <summary>
        /// Data editor window singleton
        /// </summary>
        /// <summary xml:lang="ru">
        /// Синглтон для формы редактирования конфигурационных файлов
        /// </summary>
        private static DataEditorWindow instance;

        /// <summary>
        /// Create the instance of this form if no other instances created and return it
        /// </summary>
        /// <summary xml:lang="ru">
        /// Создать инстанс формы если он ещё не создан и вернуть его
        /// </summary>
        /// <returns>
        /// Current form instance
        /// </returns>
        /// <returns xml:lang="ru">
        /// Текущий инстанс формы
        /// </returns>
        public static DataEditorWindow GetInstance()
        {
            if (instance == null)
            {
                instance = new DataEditorWindow();
            }

            return instance;
        }

        /// <summary>
        /// Open the specified <see cref="TextFile"/>, parse data from it and pass the
        /// parsed data to the <see cref="DataGridView"/>
        /// </summary>
        /// <summary xml:lang="ru">
        /// Открыть указанный файл <see cref="TextFile"/>, получить данные из него и
        /// показать полученные данные в <see cref="DataGridView"/>
        /// </summary>
        /// <param name="file">File to be opened</param>
        /// <param name="file" xml:lang="ru">Файл который необходимо открыть</param> 
        public void OpenFile(TextFile file)
        {
            var result = file.ParseData(file.FullPath);

            DataGridView.Rows.Clear();

            for (int i = 0; i < result.Count; i++)
            {
                var arr = result[i].ToArray();
                DataGridView.Rows.Add(arr);
            }
        }

        /// <summary>
        /// Form constructor
        /// </summary>
        /// <summary xml:lang="ru">
        /// Конструктор формы
        /// </summary>
        public DataEditorWindow()
        {
            InitializeComponent();

            SetColumnCount(35);
        }

        /// <summary>
        /// Sets the column count in the <see cref="DataGridView"/>
        /// </summary>
        /// <summary xml:lang="ru">
        /// Установить количество полей в <see cref="DataGridView"/>
        /// </summary>
        /// <param name="columnCount">New column count</param>
        /// <param name="columnCount" xml:lang="ru">Новое количество полей</param>
        public void SetColumnCount(int columnCount) {
            DataGridView.ColumnCount = columnCount;
        }
    }
}
