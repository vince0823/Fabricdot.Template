﻿using System;
using System.ComponentModel.DataAnnotations;
using Fabricdot.Infrastructure.Commands;

namespace ProjectName.WebApi.Application.Commands.Users
{
    public class SetDefaultPasswordCommand : CommandBase
    {
        [Required]
        public Guid UserId { get; set; }
    }
}