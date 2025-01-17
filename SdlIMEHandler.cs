﻿#if !WINDOWSDX && !XNA
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame.IMEHelper
{
    /// <summary>
    /// Integrate IME to DesktopGL(SDL2) platform.
    /// </summary>
    public class SdlIMEHandler : IMEHandler
    {
        public SdlIMEHandler(Game game, bool showDefaultIMEWindow = false) : base(game, showDefaultIMEWindow)
        {
        }

        public override bool Enabled { get; protected set; }

        public override void PlatformInitialize()
        {
#if !FNA
            GameInstance.Window.TextInput += Window_TextInput;
#else
            TextInputEXT.TextInput += ch => OnTextInput(ch);
#endif
        }

#if !FNA
        private void Window_TextInput(object sender, Microsoft.Xna.Framework.TextInputEventArgs e)
        {
            OnTextInput(new TextInputEventArgs(e.Character, e.Key));
        }
#endif

        public override void StartTextComposition()
        {
            if (Enabled)
                return;

            Sdl.StartTextInput();
            Enabled = true;
        }

        public override void StopTextComposition()
        {
            if (!Enabled)
                return;

            Sdl.StopTextInput();
            Enabled = false;
        }

        public override void SetTextInputRect(ref Rectangle rect)
        {
            var sdlRect = new Sdl.Rectangle() { X = rect.X, Y = rect.Y, Width = rect.Width, Height = rect.Height };
            Sdl.SetTextInputRect(ref sdlRect);
        }
    }
}
#endif