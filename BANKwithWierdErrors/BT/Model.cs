
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using BT;
public partial class Message
{
    virtual public void Process()
    {
        throw new InvalidOperationException("не могу обработать абстрактное сообщение");
    }
}

public partial class PaymentMessage : Message
{
    public override void Process()
    {
        //MessageBox.Show("получил деньги");
        MainWindow.DashkConn.Account.Load();
        var account = (from a in MainWindow.DashkConn.Account where a.AccountNumber == RecieverAccountId select a).FirstOrDefault();
        if (account != null)
        {
            account.Amount += Amount;
            ResultMessage rm = new ResultMessage() { RecieverBankId = SenderAccountId, Related = this, ResultCode = PaymentResult.OK, SenderBankId = 42 };
        }
        else
        {
            ResultMessage rm = new ResultMessage() { RecieverBankId = SenderAccountId, Related = this, ResultCode = PaymentResult.InvalidAccount, SenderBankId = 42 };
        }
        MainWindow.DashkConn.SaveChanges();

    }
}
public partial class ResultMessage : Message
{
    public override void Process()
    {
        MessageBox.Show("банк ответил");
    }
}




