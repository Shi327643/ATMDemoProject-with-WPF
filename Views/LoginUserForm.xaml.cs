using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ATMDemoWithWPF.Views
{
    
        
    /// <summary>
    /// Interaction logic for LoginUserForm.xaml
    /// </summary>
    public partial class LoginUserForm : Window
    {
        public static LoginUserForm instance;
        public TextBox card_no;
        public static string SetValueForCardno = "";
        public LoginUserForm()
        {
            InitializeComponent();
            SetValueForCardno = txtCardNo.Text;
            instance = this;
            card_no = txtCardNo;
        }
    }
}
