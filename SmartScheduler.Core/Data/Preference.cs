namespace SmartScheduler.Core.Data
{
    public class Preference<T>
    {
        public int Priority { get; set; }
        public T Value { get; set; }
    }
}
