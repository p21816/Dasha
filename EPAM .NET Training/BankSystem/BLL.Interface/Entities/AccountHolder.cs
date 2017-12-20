﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class AccountHolder
    {
        #region Fields

        private int id;
        private string firstName;
        private string lastName;

        #endregion


        #region Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        #endregion

        public AccountHolder() { }
        public AccountHolder(int id, string fn, string ln)
        {
            this.id = id;
            this.firstName = fn;
            this.lastName = ln;
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
