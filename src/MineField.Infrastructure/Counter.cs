namespace MineField.Infrastructure
{
    public class Counter
    {
        public void Add(string message)
        {
            ThresholdReachedEventArgs args = new()
            {
                Message = message
            };
            RaiseMessage(args);
        }

        protected virtual void RaiseMessage(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}