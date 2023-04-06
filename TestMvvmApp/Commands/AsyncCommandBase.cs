namespace TestMvvmApp.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        public override async void Execute(object? parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public abstract Task ExecuteAsync(object? parameter);
    }
}
