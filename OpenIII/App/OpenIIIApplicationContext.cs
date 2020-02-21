﻿using System;
using System.Windows.Forms;
using OpenIII.GameFiles;

namespace OpenIII
{
    /// <summary>
    /// Custom application context
    /// With this context a starting form is determined. If application launches for the first time the settings form is called.
    /// Otherwise we'll show the main form.
    /// </summary>
    /// <summary xml:lang="ru">
    /// Собственный контекст приложения
    /// С помощью данного контекста определяется форма, которую необходимо открыть при запуске приложения.
    /// Если программа запущена впервые, то пользователю будет показана форма настройки для указания пути к игре.
    /// Иначе пользователю сразу увидит главное окно приложения.
    /// </summary>
    public class OpenIIIApplicationContext : ApplicationContext
    {
        /// <summary>
        /// Handle of the file browser window
        /// </summary>
        /// <summary xml:lang="ru">
        /// Указатель на окно файлового менеджера
        /// </summary>
        public FileBrowserWindow fileBrowserWindow;

        /// <summary>
        /// Handle of the file game path window
        /// </summary>
        /// <summary xml:lang="ru">
        /// Указатель на окно настройки путей к игре
        /// </summary>
        public SetGamePathWindow setGamePathWindow;

        /// <summary>
        /// Context constructor
        /// </summary>
        /// <summary xml:lang="ru">
        /// Конструктор контекста
        /// </summary>
        public OpenIIIApplicationContext()
        {
            if (Properties.Settings.Default.GTAPath != "")
            {
                ShowFileBrowserWindow();
            }
            else
            {
                ShowGamePathWindow();
            }
        }

        /// <summary>
        /// Show file browser window, which is the main form.
        /// </summary>
        /// <summary xml:lang="ru">
        /// Показать файловый менеджер, главную форму приложения.
        /// </summary>
        public void ShowFileBrowserWindow()
        {
            GameDirectory dir = new GameDirectory(Properties.Settings.Default.GTAPath);

            fileBrowserWindow = FileBrowserWindow.GetInstance();
            fileBrowserWindow.OpenDir(dir);
            fileBrowserWindow.FormClosed += OnClosed;
            fileBrowserWindow.Show();
        }

        /// <summary>
        /// Show game path window settings to setup game path
        /// </summary>
        /// <summary xml:lang="ru">
        /// Показать форму настройки пути к игре
        /// </summary>
        public void ShowGamePathWindow()
        {
            setGamePathWindow = new SetGamePathWindow();
            setGamePathWindow.FormClosed += OnClosed;
            setGamePathWindow.OnCancelled += OnClosed;
            setGamePathWindow.OnGtaPathSet += OnGtaPathSet;
            setGamePathWindow.Show();
        }

        /// <summary>
        /// Main window close event handler
        /// </summary>
        /// <summary xml:lang="ru">
        /// Обработчик события закрытия главной формы
        /// </summary>
        /// <param name="s">Form that emitted the event</param>
        /// <param name="e">Event arguments</param>
        /// <param name="s" xml:lang="ru">Указатель на форму, которая отправила событие</param>
        /// <param name="e" xml:lang="ru">Аргументы события</param>
        public void OnClosed(object s, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Game path set event handler
        /// </summary>
        /// <summary xml:lang="ru">
        /// Обработчик события получения пути к игре от пользователя
        /// </summary>
        /// <param name="s">Form that emitted the event</param>
        /// <param name="e">Event arguments</param>
        /// <param name="s" xml:lang="ru">Указатель на форму, которая отправила событие</param>
        /// <param name="e" xml:lang="ru">Аргументы события</param>
        public void OnGtaPathSet(object s, PathEventArgs e)
        {
            Properties.Settings.Default.GTAPath = e.Path;
            Properties.Settings.Default.Save();
            setGamePathWindow.FormClosed -= OnClosed;
            ShowFileBrowserWindow();
        }
    }
}
