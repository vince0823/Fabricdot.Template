﻿using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ProjectName.Domain.Aggregates.UserAggregate;

namespace ProjectName.WebApi.Application.Commands.Users
{
    internal class ChangeUserStatusCommandHandler : ICommandHandler<ChangeUserStatusCommand>
    {
        private readonly UserManager<User> _userManager;

        public ChangeUserStatusCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(
            ChangeUserStatusCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            Guard.Against.Null(user, nameof(user));

            if (request.IsActive)
                user.Enable();
            else
                user.Disable();
            var res = await _userManager.UpdateAsync(user);
            res.EnsureSuccess();

            return Unit.Value;
        }
    }
}