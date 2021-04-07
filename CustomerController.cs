using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankingLib;
using Banking.Models;
using System.Threading;

namespace Banking.Controllers
{
    public class CustomerController : Controller
    {

        // GET: Customer
        public ActionResult Index()
        {
            var rm = (RegisterModel)Session["User"];

            ViewBag.User = rm.Account_Name;
            return View(rm);
        }
        public ActionResult FundTransfer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FundTransfer(TransactionModel tranMod)
        {
            var rm = (RegisterModel)Session["User"];
            TransactionDAL td = new TransactionDAL();
            BalanceDAL bd = new BalanceDAL();
            Transaction tr = new Transaction();
           
            tr.Sender_Acc = rm.Account_No;
            tr.Receiver_Acc = tranMod.Receiver_Acc;
            tr.Rec_IFSC = tranMod.Rec_IFSC;
            tr.Amount = tranMod.Amount;
            tr.Transaction_time = DateTime.Now;
            Double balance = bd.GetBalance(rm.Account_No);
            if (tr.Amount < balance)
            {
                td.UpdateTranDetails(tr);
                bd.UpdateBalance(rm.Account_No, balance - tr.Amount);
                Response.Write("Transfer Successful");
                
            }
            else
            {
                Response.Write("Insufficient Balance");
               

            }

            return View();
        }
    }
}