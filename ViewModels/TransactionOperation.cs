using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ATMDemoWithWPF.Commands;
using ATMDemoWithWPF.Models;
using ATMDemoWithWPF.Views;

namespace ATMDemoWithWPF.ViewModels
{
    
    public class TransactionOperation:INotifyPropertyChanged
    {
        //public static string SetValueForCardNo = "";
       // public static string SetValueForText2 = "";
        EFCFContext db = null;
        ObservableCollection<User> userList = null;
        ObservableCollection<Card> cardList = null;

        #region Propertiesof User and Card class
        private User userObj = new User();
        private Card cardObj = new Card();
        

        public string UI_CardNo
        {
            get
            {
                return userObj.CardNo.ToString();
            }
            set
            {
                userObj.CardNo = long.Parse(value);
                OnPropertyChanged("UI_CardNo");

            }

        }
        public string UI_FirstName
        {
            get { return userObj.FirstName; }

            set
            {
                userObj.FirstName = value;
                OnPropertyChanged("UI_FirstName");
            }
        }

        public string UI_LastName
        {
            get { return userObj.LastName; }
            set
            {
                userObj.LastName = value;
                OnPropertyChanged("UI_LastName");
            }
        }
        public string UI_Pin
        {
            get { return userObj.Pin.ToString(); }

            set
            {
                if (value != string.Empty)
                {
                    userObj.Pin = Convert.ToInt32(value);
                }
                else
                {
                    
                    userObj.Pin = null;
                }
                OnPropertyChanged("UI_Pin");
            }
        }
        public string UI_Balance
        {
            get { return userObj.Balance.ToString(); }

            set
            {
                userObj.Balance = Convert.ToDecimal(value);
                OnPropertyChanged("UI_Balance");
            }
        }

        public ObservableCollection<User> UserList
        {
            get
            {
                return userList;
            }
            set
            {
                userList = value;
                OnPropertyChanged("UserList");
            }
        }


        public string UI_TransactionId
        {
            get { return cardObj.Transaction_Id.ToString(); }
            set
            {
                cardObj.Transaction_Id = Convert.ToInt32(value);
                OnPropertyChanged("UI_TransactionId");
            }
        }
        public string UI_TransactionDate
        {
            get { return cardObj.Transaction_Date.ToString(); }
            set
            {
                cardObj.Transaction_Date = Convert.ToDateTime(value);
                OnPropertyChanged("UI_TransactionDate");
            }
        }


        public string UI_Card_CardNo
        {
            get
            {
                return userObj.CardNo.ToString();
            }
            set
            {
                cardObj.CardNo = long.Parse(value);
                OnPropertyChanged("UI_Card_CardNo");

            }

        }
        public string UI_TransactionMode
        {
            get { return cardObj.Transaction_Mode; }
            set
            {
                cardObj.Transaction_Mode = value;
                OnPropertyChanged("UI_TransactionMode");
            }
        }
        public string UI_AccountType
        {
            get { return cardObj.Account_Type; }
            set
            {
                cardObj.Account_Type = value;
                OnPropertyChanged("UI_AccountType");
            }
        }

        public string UI_Ammount
        {
            get { return cardObj.Ammount.ToString(); }

            set
            {
                cardObj.Ammount = Convert.ToDecimal(value);
                OnPropertyChanged("UI_Ammount");
            }
        }

        public string UI_Card_Pin
        {
            get { return cardObj.Pin.ToString(); }
            set
            {
                if (value != string.Empty)
                {
                    cardObj.Pin = Convert.ToInt32(value);
                }
                else
                {

                    cardObj.Pin = null;
                }
                OnPropertyChanged("UI_Card_Pin");
            }
        }

        public ObservableCollection<Card> CardList
        {
            get
            {
                return cardList;
            }
            set
            {
                cardList = value;
                OnPropertyChanged("CardList");
            }
        }









        #endregion

        #region Constructor
        public TransactionOperation()
        {
            db = new EFCFContext();
            userList = new ObservableCollection<User>();
            cardList = new ObservableCollection<Card>();
            _searchcmd = new RelayCommand(Search, CanSearch);
            _checkbalance = new RelayCommand(CheckBalance);
           _balanceenquiry = new RelayCommand(BalanceEnquiry);
            _checkprevioushistory = new RelayCommand(CheckPreviousHistory);
            _previoushistory = new RelayCommand(PreviousHistory);
        }

        #endregion

        #region Command

        private ICommand _searchcmd;
        public ICommand SearchCommand
        {
            get { return _searchcmd; }
        }

        private ICommand _checkbalance;
        public ICommand CheckBalanceCommand
        {
            get { return _checkbalance; }
        }
        private ICommand _balanceenquiry;
        public ICommand BalanceEnquiryCommand
        {
            get { return _balanceenquiry; }
        }

        private ICommand _checkprevioushistory;
        public ICommand CheckPreviousHistoryCommand
        {
            get { return _checkprevioushistory; }
        }

        private ICommand _previoushistory;
        public ICommand PreviousHistoryCommand
        {
            get { return _previoushistory; }
        }

        public void PreviousHistory(Object obj)
        {
            long cardno = long.Parse(LoginUserForm.instance.card_no.Text);
            var data = db.Cards.OrderByDescending(x=> x.CardNo == cardno).Take(3).ToList();
            CardList = new ObservableCollection<Card>(data);
            if(CardList.Count > 0)
            {
                this.UI_TransactionId = CardList[0].Transaction_Id.ToString();
                this.UI_TransactionDate = CardList[0].Transaction_Date.ToString();
                this.UI_TransactionMode = CardList[0].Transaction_Mode;
                this.UI_Card_CardNo = CardList[0].CardNo.ToString();
                this.UI_AccountType = CardList[0].Account_Type;
                this.UI_Ammount = CardList[0].Ammount.ToString();
                this.UI_Card_Pin = CardList[0].Pin.ToString();
            }


        }
        public void CheckPreviousHistory(Object obj)
        {
            PreviousHistoryForm previousHistoryForm = new PreviousHistoryForm();
            previousHistoryForm.Show();
        }

        public void BalanceEnquiry(Object obj)
        {
            
            long cardno = long.Parse(LoginUserForm.instance.card_no.Text);
            User user = db.Users.SingleOrDefault(p => p.CardNo == cardno);
            if (user != null)
            {
                this.UI_Balance = user.Balance.ToString();

            }

        }

        public void CheckBalance(Object obj)
        {
            BalanceEnquiryForm balanceEnquiryForm = new BalanceEnquiryForm();
            balanceEnquiryForm.Show();
        }

        public bool CanSearch(Object obj)
        {
            if ((this.UI_CardNo != string.Empty) && (this.UI_Pin != String.Empty))
            {
                if ((long.Parse(this.UI_CardNo) > 0) && (int.Parse(this.UI_Pin) > 0))
                    return true;
            }
            return false;
        }

        public void Search(Object obj)
        {
            long cardno = long.Parse(this.UI_CardNo);
            int pin = int.Parse(this.UI_Pin);
            User user = db.Users.SingleOrDefault(p => p.CardNo == cardno && p.Pin == pin);
            if (user != null)
            {
                MessageBox.Show("Login successfull");
                MessageBox.Show("Welcome to HDFC ATM Machine");
                TransactionModeForm transactionModeForm = new TransactionModeForm();
                transactionModeForm.Show();
                

            }
            else
            {
                MessageBox.Show("Invalid cardno and password");
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


    }
}
