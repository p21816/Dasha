
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

namespace BT
{

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
            List<ResultMessage> resMessages = new List<ResultMessage>();
            MainWindow.DashkConn.Account.Load();
            var account = (from a in MainWindow.DashkConn.Account where a.AccountNumber == RecieverAccountId select a).FirstOrDefault();

            if (account != null)
            {
                account.Amount += Amount;
                ResultMessage rm = new ResultMessage() { RecieverBankId = this.SenderBankId, Related = this, ResultCode = PaymentResult.OK, SenderBankId = 42 };
                //MainWindow.conn.Database.Log += (i) => { MessageBox.Show(i); };
                resMessages.Add(rm);
            }
            else
            {
                ResultMessage rm = new ResultMessage() { RecieverBankId = this.SenderBankId, Related = this, ResultCode = PaymentResult.InvalidAccount, SenderBankId = 42 };
                resMessages.Add(rm);
            }
            

            //var items = (from i in MainWindow.conn.MessageSet.OfType<ResultMessage>() where i.Id == 1071 select i).Count();
            foreach(var r in resMessages)
            {
                MainWindow.conn.MessageSet.Add(r);
            }
            MainWindow.DashkConn.SaveChanges();
            MainWindow.conn.SaveChanges();
        }
    }
    public partial class ResultMessage : Message
    {
        public override void Process()
        {
            //MessageBox.Show("банк ответил");

            switch (ResultCode)
            {
                case PaymentResult.OK:
                    {
                        PaymentMessage pm = Related as PaymentMessage;
                        var account = 
                            (from a in MainWindow.DashkConn.Account 
                             where a.AccountNumber == (pm).SenderAccountId
                             select a)
                            .FirstOrDefault();
                        account.Amount -= (pm).Amount;
                        MainWindow.DashkConn.SaveChanges();
                        break;
                    }
                case PaymentResult.InvalidAccount:
                        {
                            MessageBox.Show("Test");
                             break;
                        }
                case PaymentResult.NotEnoughFunds:
                        {
                            MessageBox.Show("Test");
                            break;
                        }
                case PaymentResult.UnknownError:
                        {
                            MessageBox.Show("Test");
                            break;
                        }
            }
        }
    }




}