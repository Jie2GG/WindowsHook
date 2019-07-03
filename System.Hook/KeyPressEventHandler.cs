namespace System.Hooks
{
    /// <summary>
    /// 表示将用来处理 <see cref="GlobalHookKeyboard.KeyPress"/> 的 <see cref="GlobalHookKeyboard"/> 事件的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="e">包含事件数据的 <see cref="KeyPressEventArgs"/>。</param>
    public delegate void KeyPressEventHandler (object sender, KeyPressEventArgs e);
}
