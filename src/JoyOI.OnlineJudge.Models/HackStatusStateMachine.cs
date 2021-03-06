﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoyOI.OnlineJudge.Models
{
    /// <summary>
    /// Hack status state machine.
    /// </summary>
    public class HackStatusStateMachine
    {
        /// <summary>
        /// Gets or sets the status identifier.
        /// </summary>
        /// <value>The status identifier.</value>
        [ForeignKey("Status")]
        public Guid StatusId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public virtual HackStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the state machine identifier.
        /// </summary>
        /// <value>The state machine identifier.</value>
        [ForeignKey("StateMachine")]
        public Guid StateMachineId { get; set; }

        /// <summary>
        /// Gets or sets the state machine.
        /// </summary>
        /// <value>The state machine.</value>
        public virtual StateMachine StateMachine { get; set; }
    }
}
