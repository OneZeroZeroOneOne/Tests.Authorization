﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Authorization.Dal.Models
{
    public partial class UserAnswer
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? QuizId { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public DateTime? CreateDateTime { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Question Question { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
