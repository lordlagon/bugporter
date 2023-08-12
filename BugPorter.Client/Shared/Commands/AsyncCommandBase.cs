namespace BugPorter.Client.Shared
{
    public abstract class AsyncCommandBase : IRelayCommand, ICommand
    {
        readonly Action<Exception> _onException;

        private bool _isExecuting;

        public bool IsExecuting
        {
            get { return _isExecuting; }
            private set { _isExecuting = value; NotifyCanExecuteChanged(); }
        }

        public event EventHandler CanExecuteChanged;
        public AsyncCommandBase(Action<Exception> onException = null)
        {
            _onException = onException;
        }        

        public bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        public async void Execute(object parameter)
        {
            IsExecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception ex)
            {
                _onException?.Invoke(ex);
                throw;
            }
            IsExecuting = false;
        }

        protected abstract Task ExecuteAsync(object parameter);
        
        public void NotifyCanExecuteChanged()
        {            
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
