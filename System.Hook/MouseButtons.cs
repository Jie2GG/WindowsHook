namespace System.Hooks
{
    /// <summary>
    /// 指定定义哪个鼠标按钮曾按下的常数。
    /// </summary>
    [Flags]
    public enum MouseButtons
    {
        /// <summary>
        /// 不按下任何鼠标按钮。
        /// </summary>
        None = 0,
        /// <summary>
        /// 按下鼠标左键。
        /// </summary>
        Left = 1048576,
        /// <summary>
        /// 按下鼠标右键。
        /// </summary>
        Right = 2097152,
        /// <summary>
        /// 按下鼠标中键。
        /// </summary>
        Middle = 4194304,
        /// <summary>
        /// 第一个 XButton 曾按下。
        /// </summary>
        XButton1 = 8388608,
        /// <summary>
        /// 第二个 XButton 曾按下。
        /// </summary>
        XButton2 = 16777216
    }
}
