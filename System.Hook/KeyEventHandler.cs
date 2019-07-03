namespace System.Hooks
{
    /// <summary>
    /// 表示将处理的方法 <see cref="GlobalHookKeyboard.KeyUp"/> 或 <see cref="GlobalHookKeyboard.KeyDown"/> 事件 <see cref="GlobalHookKeyboard"/>
    /// </summary>
    /// <param name="sender">事件源</param>
    /// <param name="e">包含事件数据的 <see cref="KeyEventArgs"/></param>
    public delegate void KeyEventHandler (object sender, KeyEventArgs e);
}
