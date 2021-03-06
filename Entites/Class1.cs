﻿using System;
using System.Collections.Generic;

namespace Entites
{
   public class BaseClass
    {

    }
    public class Person :BaseClass
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Contact> Contact { get; set; }
        public JobData JobData { get; set; }
        public int InsertBy { get; set; }
        public int UpdateBy { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    public class Contact : BaseClass
    {
        public int ContactId { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
    public class JobData : BaseClass
    {
        public int JobDataId { get; set; }
        public string JobTitle { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }

    }
}
