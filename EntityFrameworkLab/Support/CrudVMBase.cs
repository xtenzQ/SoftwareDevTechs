using System.Data;
using System.Windows;
using EntityFrameworkLab.Model;

namespace EntityFrameworkLab.Support
{
    public class CrudVmBase : NotifyUiBase
    {
        protected ResDbContext Db = new ResDbContext();

        protected void HandleCommand(CommandMessage action)
        {
            if (IsCurrentView)
            {
                switch (action.Command)
                {
                    case CommandType.Insert:
                        break;
                    case CommandType.Edit:
                        break;
                    case CommandType.Delete:
                        DeleteCurrent();
                        break;
                    case CommandType.Commit:
                        CommitUpdates();
                        break;
                    case CommandType.Refresh:
                        RefreshData();
                        break;
                    default:
                        break;
                }
            }
        }

        private Visibility _throbberVisible = Visibility.Visible;
        public Visibility ThrobberVisible
        {
            get => _throbberVisible;
            set
            {
                _throbberVisible = value;
                OnPropertyChanged();
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        protected virtual void CommitUpdates()
        {

        }

        protected virtual void DeleteCurrent()
        {

        }

        protected virtual void RefreshData()
        {
            GetData();
            Messenger.Default.Send<UserMessage>(new UserMessage { Message = "Data Refreshed" });
        }
        protected virtual void GetData()
        {
        }

        protected CrudVmBase()
        {
            GetData();
            Messenger.Default.Register<CommandMessage>(this, (action) => HandleCommand(action));
            Messenger.Default.Register<NavigateMessage>(this, (action) => CurrentUserControl(action));
        }
        protected bool IsCurrentView = false;
        private void CurrentUserControl(NavigateMessage nm)
        {
            IsCurrentView = this.GetType() == nm.ViewModelType;
        }
    }
}