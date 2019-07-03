namespace System.Hooks
{
    /// <summary>
    /// 为 <see cref="GlobalHookKeyboard.KeyPress"/> 事件提供数据。
    /// </summary>
    public class KeyPressEventArgs : EventArgs
    {
        #region --字段--
        private char _keyChar;
        private bool _handled;
        #endregion

        #region --属性--
        /// <summary>
        /// 获取或设置与按下的键对应的字符。
        /// </summary>
        public char KeyChar
        {
            get
            {
                return _keyChar;
            }
            set
            {
                _keyChar = value;
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否 <see cref="GlobalHookKeyboard.KeyPress"/> 事件进行处理。
        /// </summary>
        public bool Handled
        {
            get
            {
                return _handled;
            }
            set
            {
                _handled = value;
            }
        }
        #endregion

        #region --构造函数--
        /// <summary>
        /// 初始化 <see cref="KeyPressEventArgs"/> 类的新实例。
        /// </summary>
        /// <param name="keyChar">用户按下对应的键的 ASCII 字符。</param>
        public KeyPressEventArgs (char keyChar)
        {
            this._keyChar = keyChar;
        }
        #endregion
    }
}
