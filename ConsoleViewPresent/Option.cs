namespace ConsoleViewPresent
{
    public class Option
    {
        public Option(string name, string value, string key, EventHandler callback)
        {
            Name = name;
            Value = value;
            Key = key;
            Callback += callback;
        }

        public string Name { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }

        public event EventHandler Callback;

        public void InvokeCallback(object sender, EventArgs e)
        {
            Callback?.Invoke(sender, e);
        }
    }
}
