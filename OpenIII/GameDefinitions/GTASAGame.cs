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

using OpenIII.GameFiles;
using System.Collections.Generic;
using System.IO;

namespace OpenIII.GameDefinitions
{
    class GTASAGame : Game
    {
        /// <summary>
        /// Specifies if current game instance is a valid game definition
        /// </summary>
        /// <summary xml:lang="ru">
        /// Флаг, указывающий что инстанс игры является корректным
        /// </summary>
        public override bool IsDefined { get => true; }

        /// <summary>
        /// Name of the game
        /// </summary>
        /// <summary xml:lang="ru">
        /// Название игры
        /// </summary>
        public override string Name { get => "GTA: San Andreas"; }

        /// <summary>
        /// File names to lookup when matching a game definition to game directory path
        /// </summary>
        /// <summary xml:lang="ru">
        /// Имена файлов для сопоставления определения игры и директории к ней
        /// </summary>
        public static List<string> WinExecuteableFilenames { get => new List<string>() { "gta_sa.exe", "gta-sa.exe" }; }

        /// <summary>
        /// Supported IMG archive version
        /// </summary>
        /// <summary xml:lang="ru">
        /// Поддерживаемая версия IMG архива
        /// </summary>
        public override ArchiveFileVersion ImgVersion { get => ArchiveFileVersion.V2; }

        /// <summary>
        /// Supported GXT version
        /// </summary>
        /// <summary xml:lang="ru">
        /// Поддерживаемая версия GXT
        /// </summary>
        public override GXTFileVersion GxtVersion { get => GXTFileVersion.SA; }

        /// <summary>
        /// Constructor for game definition
        /// </summary>
        /// <summary xml:lang="ru">
        /// Конструктор для определеня игры
        /// </summary>
        /// <param name="path">Game path</param>
        /// <param name="path" xml:lang="ru">Путь к игре</param>
        public GTASAGame(string path) : base(path) { }

        /// <summary>
        /// Is this game instance valid for specified directory path
        /// </summary>
        /// <summary xml:lang="ru">
        /// Указывает, что данный инстанс определения игры является корректным для игры, которая находится по указанному пути
        /// </summary>
        /// <param name="path">Game path</param>
        /// <param name="path" xml:lang="ru">Путь к игре</param>
        /// <returns>true if game is found in path</returns>
        /// <returns xml:lang="ru">true если игра найдена по указанному пути</returns>
        public new static bool IsGameExistInPath(string path)
        {
            foreach (string executeable in WinExecuteableFilenames)
            {
                if (File.Exists(System.IO.Path.Combine(path, executeable)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
