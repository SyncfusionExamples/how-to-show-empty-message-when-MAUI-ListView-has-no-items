using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ListViewDemo
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<ListViewContactsInfo> contactsInfo;
        private bool isVisible;
        private Command<object> changeItemsSource;
        #endregion

        #region Constructor

        public ViewModel()
        {
            ContactsInfo = new ObservableCollection<ListViewContactsInfo>();
            isVisible = true;
            ChangeItemsSource = new Command<object>(OnChangeItemsSource);
        }

        #endregion

        #region Properties

        public ObservableCollection<ListViewContactsInfo> ContactsInfo
        {
            get { return contactsInfo; }
            set
            {
                this.contactsInfo = value;
            }
        }

        public Command<object> ChangeItemsSource
        {
            get { return changeItemsSource; }
            set { this.changeItemsSource = value; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                this.isVisible = value;
                this.RaisePropertyChanged("IsVisible");
            }
        }

        #endregion

        #region ItemSource

        public void GenerateSource()
        {
            int counter = 0;
            Random random = new Random();
            Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;

            for (int i = 0; i < CustomerNames.Count(); i++)
            {
                if (counter == 5)
                {
                    counter = 0;
                }
                var details = new ListViewContactsInfo()
                {

                    ContactType = contactType[counter],
                    ContactNumber = random.Next(100, 400).ToString() + "-" + random.Next(500, 800).ToString() + "-" + random.Next(1000, 2000).ToString(),
                    ContactName = CustomerNames[i],
                    ContactImage = "image" + i + ".png",
                };
                ContactsInfo.Add(details);
                counter++;
            }
        }

        private void OnChangeItemsSource(object obj)
        {
            if (IsVisible)
            {
                IsVisible = false;
                GenerateSource();
            }
            else
            {
                ContactsInfo.Clear();
                IsVisible = true;
            }
        }

        #endregion

        #region Contacts Information

        string[] contactType = new string[]
        {
            "HOME",
            "WORK",
            "MOBILE",
            "OTHER",
            "BUSINESS"
        };

        string[] CustomerNames = new string[]
        {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Jennifer",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Zeke",
            "Aiden",
            "Jackson",
            "Mason  ",

        };
        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
