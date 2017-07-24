﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoyOI.OnlineJudge.Models
{
    public class JudgeStatusStateMachine
    {
        [ForeignKey("Status")]
        public Guid StatusId { get; set; }

        public virtual JudgeStatus Status { get; set; }

        [ForeignKey("StateMachine")]
        public Guid StateMachineId { get; set; }

        public virtual StateMachine StateMachine { get; set; }
    }
}
