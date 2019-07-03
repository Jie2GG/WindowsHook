namespace System.Hooks
{
    /// <summary>
    /// 将提供数据供 <see cref="GlobalHookKeyboard.KeyDown"/> 或 <see cref="GlobalHookKeyboard.KeyUp"/>
    /// </summary>
    public class KeyEventArgs : EventArgs
    {
        #region --字段--
        private readonly Keys _keyData;
        private bool _handled;
        private bool _suppressKeyPress;
        #endregion

        #region --属性--
        /// <summary>
        ///  获取一个值，该值指示是否曾按下 Alt 键。
        /// </summary>
        public virtual bool Alt
        {
            get
            {
                return ((this._keyData & Keys.Alt) == Keys.Alt);
            }
        }

        /// <summary>
        /// 获取一个值，该值指示是否曾按下 Ctrl 键。
        /// </summary>
        public bool Control
        {
            get
            {
                return ((this._keyData & Keys.Control) == Keys.Control);
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否处理过此事件。
        /// </summary>
        public bool Handled
        {
            get
            {
                return this._handled;
            }
            set
            {
                this._handled = value;
            }
        }

        /// <summary>
        /// 获取的键盘代码 <see cref="GlobalHookKeyboard.KeyDown"/> 或 <see cref="GlobalHookKeyboard.KeyUp"/> 事件。
        /// </summary>
        public Keys KeyCode
        {
            get
            {
                Keys keys = this._keyData & Keys.KeyCode;
                if (!Enum.IsDefined (typeof (Keys), (int)keys))
                {
                    return Keys.None;
                }
                return keys;
            }
        }

        /// <summary>
        /// 获取的键盘值 <see cref="GlobalHookKeyboard.KeyDown"/> 或 <see cref="GlobalHookKeyboard.KeyUp"/> 事件。
        /// </summary>
        public int KeyValue
        {
            get
            {
                return (((int)this._keyData) & 0xffff);
            }
        }

        /// <summary>
        /// 获取的关键数据 <see cref="GlobalHookKeyboard.KeyDown"/> 或 <see cref="GlobalHookKeyboard.KeyUp"/> 事件。
        /// </summary> 
        public Keys KeyData
        {
            get
            {
                return this._keyData;
            }
        }

        /// <summary>
        /// 获取的修饰符标志 <see cref="GlobalHookKeyboard.KeyDown"/> 或 <see cref="GlobalHookKeyboard.KeyUp"/> 事件。 这些标志指示按下的 Ctrl、Shift 和 Alt 键的组合。
        /// </summary>
        public Keys Modifiers
        {
            get
            {
                return (this._keyData & ~Keys.KeyCode);
            }
        }

        /// <summary>
        /// 获取一个值，该值指示是否曾按下 Shift 键。
        /// </summary>
        public virtual bool Shift
        {
            get
            {
                return ((this._keyData & Keys.Shift) == Keys.Shift);
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示键事件是否应传递到基础控件。
        /// </summary>
        public bool SuppressKeyPress
        {
            get
            {
                return this._suppressKeyPress;
            }
            set
            {
                this._suppressKeyPress = value;
                this._handled = value;
            }
        }
        #endregion

        #region --构造函数--
        /// <summary>
        /// 初始化 <see cref="KeyEventArgs"/> 类的新实例
        /// </summary>
        /// <param name="keyData">一个 <see cref="Keys"/> 与任何修饰符标志，指示同时按下的 CTRL、 SHIFT 和 ALT 键表示的按下的键组合。 获得可能的值在应用的按位OR (|) 运算符添加到从常量 <see cref="Keys"/> 枚举</param>
        public KeyEventArgs (Keys keyData)
        {
            this._keyData = keyData;
        }
        #endregion
    }
}
